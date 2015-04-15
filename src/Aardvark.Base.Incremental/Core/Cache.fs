﻿namespace Aardvark.Base.Incremental

open System.Collections.Generic
open Aardvark.Base

/// <summary>
/// Cache represents a cached function which can be 
/// invoked and revoked. invoke increments the reference
/// count for a specific argument (possibly causing the 
/// function to be executed) whereas revoke decreases the
/// reference count and removes the cache entry whenever
/// the reference count is 0.
/// </summary>
type Cache<'a, 'b>(scope : Ag.Scope, f : 'a -> 'b) =  
    let cache = Dictionary<obj, 'b * ref<int>>()
    let mutable nullCache = None

    /// <summary>
    /// Clear removes all entries from the Cache and
    /// executes a function for all removed cache entries.
    /// this function is helpful if the contained values
    /// are (for example) disposable resources.
    /// </summary>
    member x.Clear(remove : 'b -> unit) =
        for (KeyValue(_,(v,_))) in cache do remove v
        cache.Clear()
        match nullCache with
            | Some (v,_) -> 
                remove v
                nullCache <- None
            | None -> ()

    /// <summary>
    /// invoke returns the function value associated
    /// with the given argument (possibly executing the function)
    /// and increases the associated reference count.
    /// </summary>
    member x.Invoke (v : 'a) =
        if (v :> obj) = null then
            match nullCache with
                | Some (r, ref) -> 
                    ref := !ref + 1
                    r
                | None ->
                    let r = Ag.useScope scope (fun () -> f v)
                    nullCache <- Some(r, ref 1)
                    r
        else
            match cache.TryGetValue v with
                | (true, (r, ref)) -> 
                    ref := !ref + 1
                    r
                | _ ->
                    let r = Ag.useScope scope (fun () -> f v)
                    cache.[v] <- (r, ref 1)
                    r
    /// <summary>
    /// revoke returns the function value associated
    /// with the given argument and decreases its reference count.
    /// </summary>
    member x.Revoke (v : 'a) =
        if (v :> obj) = null then
            match nullCache with
                | Some (r, ref) -> 
                    ref := !ref - 1
                    if !ref = 0 then
                        nullCache <- None
                    r
                | None -> failwithf "cannot revoke null"
        else
            match cache.TryGetValue v with
                | (true, (r, ref)) -> 
                    ref := !ref - 1
                    if !ref = 0 then
                        cache.Remove v |> ignore
                    r
                | _ -> failwithf "cannot revoke unknown value: %A" v