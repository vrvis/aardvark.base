﻿namespace Aardvark.Geometry.Tests

open System
open NUnit.Framework
open FsUnit
open FsCheck
open FsCheck.NUnit

open Aardvark.Base
open Aardvark.Geometry

module Regression3dTests =
    
    module Gen =

        /// generates a float in [0,1]
        let uniformFloat =
            // choose two ints with 22/31 bits, create an uint64 from these and normalize to float.
            // this creates a full-precision float since float has 53 "effective" significand bits.
            (Gen.choose (0, 4194303), Gen.choose (0, Int32.MaxValue)) ||> Gen.map2 (fun a b ->
                let v = (uint64 a <<< 31) ||| uint64 b
                float v / 9007199254740991.0
            )                

        /// generates a float in [min, max]
        let uniform (min : float) (max : float) =
            uniformFloat |> Gen.map (fun v ->
                min + v * (max - min)
            )

        /// generates a float from N(avg, dev)
        let gauss (avg : float) (dev : float) =
            uniform -1.0 1.0 |> Gen.map (fun v ->
                let side = sign v
                let v = abs v |> max 1E-9
                let x = sqrt (-log v)
                let n01 = x * float side
                n01 * dev + avg
            )

        /// generates a normalized V3d direction
        let direction =
            gen {
                let! phi = uniform 0.0 Constant.PiTimesTwo
                let! z = uniform -1.0 1.0

                let xy = sqrt(1.0 - sqr z)

                return 
                    V3d(
                        cos phi * xy,
                        sin phi * xy,
                        z
                    )
            }

    type AtLeast<'d, 'a when 'd :> INatural>(value : 'a[]) =
        member x.Value = value
        override x.ToString() =
            sprintf "%d: %A" value.Length value

    type ZeroOneFloat =
        ZeroOneFloat of float
    type GaussFloat =
        GaussFloat of float


    type EuclideanGenerator private() =

        static member ZeroOneFloat =
            Gen.uniformFloat |> Gen.map ZeroOneFloat |> Arb.fromGen

        static member GaussFloat =
            Gen.gauss 0.0 1.0 |> Gen.map GaussFloat |> Arb.fromGen

        static member AtLeast<'d, 'a when 'd :> INatural>() =
            gen {
                let d = typeSize<'d>

                let! rest = Arb.generate<'a[]>
                let fin = Array.zeroCreate (rest.Length + d)


                let mutable oi = 0
                let rec exists (i : int) (v : 'a) =
                    if i >= oi then 
                        false
                    else    
                        if Unchecked.equals fin.[oi] v then true
                        else exists (i+1) v

                while oi < d do
                    let! v = Arb.generate<'a>
                    if not (exists 0 v) then
                        fin.[oi] <- v
                        oi <- oi + 1

                fin.[d..] <- rest

                return fin |> AtLeast<'d, 'a>
            }|> Arb.fromGen

        static member V2d =
            gen {
                let! x = Gen.gauss 0.0 500.0
                let! y = Gen.gauss 0.0 100.0
                return V2d(x,y)
            } |> Arb.fromGen
            
        static member Euclidean2d =
            gen {
                let! x = Gen.gauss 0.0 300.0
                let! y = Gen.gauss 0.0 300.0
                let! angle = Gen.uniform 0.0 Constant.PiTimesTwo

                return Euclidean2d(Rot2d angle, V2d(x,y))

            } |> Arb.fromGen
        static member Euclidean3d =
            gen {
                let! x = Gen.gauss 0.0 300.0
                let! y = Gen.gauss 0.0 300.0
                let! z = Gen.gauss 0.0 300.0

                let! axis = Gen.direction
                let! angle = Gen.uniform 0.0 Constant.PiTimesTwo

                let rot = Rot3d.FromAngleAxis(angle * axis)
                return Euclidean3d(rot, V3d(x,y,z))

            } |> Arb.fromGen

    let checkPlane (r : Regression3d) (points : V3d[]) =
        let plane = r.GetPlane()
        let error = points |> Array.map (plane.Height >> abs) |> Array.max
        error |> should be (lessThanOrEqualTo 1E-6)

    let checkTrafo (r : Regression3d) (points : V3d[]) =
        let trafo = r.GetTrafo()
        let error = points |> Array.map (fun p -> trafo.Backward.TransformPos(p).Z |> abs) |> Array.max
        error |> should be (lessThanOrEqualTo 1E-6)
        
    let check (points : V3d[]) (r : Regression3d) =
        checkPlane r points
        checkTrafo r points
        
    let checkPlane2d (r : Regression2d) (points : V2d[]) =
        let struct(plane, _) = r.GetPlaneAndConfidence()
        let error = points |> Array.map (plane.Height >> abs) |> Array.max
        error |> should be (lessThanOrEqualTo 1E-6)
        
    let checkTrafo2d (r : Regression2d) (points : V2d[]) =
        let trafo = r.GetTrafo()
        let error = points |> Array.map (fun p -> trafo.Backward.TransformPos(p).Y |> abs) |> Array.max
        error |> should be (lessThanOrEqualTo 1E-6)
        
    let check2d (points : V2d[]) (r : Regression2d) =
        checkPlane2d r points
        checkTrafo2d r points

    [<Property(Arbitrary = [| typeof<EuclideanGenerator> |])>]
    let ``Regression3d plane working`` (trafo : Euclidean3d) (points : AtLeast<8 N, V2d>) =
        let pts = 
            points.Value
            |> Array.map (fun p -> trafo.TransformPos(V3d(p, 0.0)))

        // add working
        pts |> Array.fold (+) Regression3d.empty |> check pts

        // ofArray/ofSeq working
        pts |> Regression3d.ofArray |> check pts
        pts |> Regression3d.ofSeq |> check pts

        // constructor working
        pts |> Regression3d |> check pts

        // regression addition working
        let n2 = pts.Length / 2
        Regression3d.ofArray pts.[..n2-1] + Regression3d.ofArray pts.[n2..] |> check pts

        // remove working
        pts |> Array.fold (+) (Regression3d V3d.Zero) |> Regression3d.remove V3d.Zero |> check pts
        

    [<Property(Arbitrary = [| typeof<EuclideanGenerator> |])>]
    let ``Regression2d plane working`` (trafo : Euclidean2d) (points : AtLeast<8 N, GaussFloat>) =
        let pts = points.Value |> Array.map (fun (GaussFloat v) -> trafo.TransformPos(V2d(v * 10.0, 0.0)))
        
        // add working
        pts |> Array.fold (+) Regression2d.empty |> check2d pts

        // ofArray/ofSeq working
        pts |> Regression2d.ofArray |> check2d pts
        pts |> Regression2d.ofSeq |> check2d pts

        // constructor working
        pts |> Regression2d |> check2d pts

        // regression addition working
        let n2 = pts.Length / 2
        Regression2d.ofArray pts.[..n2-1] + Regression2d.ofArray pts.[n2..] |> check2d pts

        // remove working
        pts |> Array.fold (+) (Regression2d V2d.Zero) |> Regression2d.remove V2d.Zero |> check2d pts