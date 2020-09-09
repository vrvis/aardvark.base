﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

namespace Aardvark.Base
{
    // AUTOGENERATED CODE - DO NOT CHANGE!

    //# Action comma = () => Out(", ");
    //# Action commaln = () => Out("," + Environment.NewLine);
    //# Action add = () => Out(" + ");
    //# Action and = () => Out(" && ");
    //# var fields = new[] {"X", "Y", "Z", "W"};
    //# foreach (var isDouble in new[] { false, true }) {
    //# for (int n = 2; n <= 3; n++) {
    //#   var ftype = isDouble ? "double" : "float";
    //#   var tc = isDouble ? "d" : "f";
    //#   var tc2 = isDouble ? "f" : "d";
    //#   var m = n + 1;
    //#   var type = "Affine" + n + tc;
    //#   var type2 = "Affine" + n + tc2;
    //#   var trafont = "Trafo" + n + tc;
    //#   var euclideannt = "Euclidean" + n + tc;
    //#   var rotnt = "Rot" + n + tc;
    //#   var scalent = "Scale" + n + tc;
    //#   var shiftnt = "Shift" + n + tc;
    //#   var similaritynt = "Similarity" + n + tc;
    //#   var mnnt = "M" + n + n + tc;
    //#   var mnnt2 = "M" + n + n + tc2;
    //#   var mnmt = "M" + n + m + tc;
    //#   var mmmt = "M" + m + m + tc;
    //#   var vnt = "V" + n + tc;
    //#   var vnt2 = "V" + n + tc2;
    //#   var vmt = "V" + m + tc;
    //#   var nfields = fields.Take(n).ToArray();
    //#   var mfields = fields.Take(m).ToArray();
    //#   var fn = fields[n];
    //#   var eps = isDouble ? "1e-12" : "1e-5f";
    #region __type__

    /// <summary>
    /// Struct to represent an affine transformation in __n__-dimensional space. It consists of
    /// a linear tranformation (invertible __n__x__n__ matrix) and a translational component (__n__d vector).
    /// </summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential)]
    public struct __type__ : IValidity
    {
        [DataMember]
        public __mnnt__ Linear;
        [DataMember]
        public __vnt__ Trans;

        #region Constructors

        /// <summary>
        /// Constructs a copy of an <see cref="__type__"/> transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__type__ affine)
        {
            Linear = affine.Linear;
            Trans = affine.Trans;
        }

        /// <summary>
        /// Constructs a <see cref="__type__"/> transformation from a <see cref="__type2__"/> transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__type2__ affine)
        {
            Linear = (__mnnt__)affine.Linear;
            Trans = (__vnt__)affine.Trans;
        }

        /// <summary>
        /// Constructs an affine transformation from a linear map and a translation.
        /// The matrix <paramref name="linear"/> must be invertible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__mnnt__ linear, __vnt__ translation)
        {
            Debug.Assert(linear.Invertible);
            Linear = linear;
            Trans = translation;
        }

        /// <summary>
        /// Constructs an affine transformation from a linear map and a translation.
        /// The matrix <paramref name="linear"/> must be invertible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__mnnt__ linear, /*# nfields.ForEach(f => { */__ftype__ t__f__/*# }, comma); */)
        {
            Debug.Assert(linear.Invertible);
            Linear = linear;
            Trans = new __vnt__(/*# nfields.ForEach(f => { */t__f__/*# }, comma); */);
        }

        /// <summary>
        /// Constructs an affine transformation from a linear map.
        /// The matrix <paramref name="linear"/> must be invertible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__mnnt__ linear)
        {
            Debug.Assert(linear.Invertible);
            Linear = linear;
            Trans = __vnt__.Zero;
        }

        #endregion

        #region Constants

        /// <summary>
        /// Gets the identity transformation.
        /// </summary>
        public static __type__ Identity
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(__mnnt__.Identity);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets if this affine transformation is valid, i.e. if the linear map is invertible.
        /// </summary>
        public bool IsValid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Linear.Invertible;
        }

        /// <summary>
        /// Gets if this affine transformation is invalid, i.e. if the linear map is singular.
        /// </summary>
        public bool IsInvalid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => !IsValid;
        }

        /// <summary>
        /// Gets the inverse of this affine transformation.
        /// </summary>
        public __type__ Inverse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var rs = new __type__(this);
                rs.Invert();
                return rs;
            }
        }

        #endregion

        #region Arithmetic Operators

        /// <summary>
        /// Multiplies two affine transformations.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __type__ b)
        {
            return new __type__(a.Linear * b.Linear, a.Linear * b.Trans + a.Trans);
        }

        /// <summary>
        /// Transforms a <see cref="__vmt__"/> vector by an affine transformation.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vmt__ operator *(__type__ a, __vmt__ v)
        {
            return new __vmt__(/*# nfields.ForEach((fi, i) => { */
                /*# mfields.ForEach((fj, j) => {
                var aij = (j < n) ? "a.Linear.M" + i + j : "a.Trans." + fi;
                */__aij__ * v.__fj__/*# }, add); }, comma);*/, 
                v.__fn__);
        }

        /// <summary>
        /// Multiplies a <see cref="__type__"/> (as a __m__x__m__ matrix) and a <see cref="__mmmt__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __mmmt__ operator *(__type__ a, __mmmt__ m)
        {
            return new __mmmt__(/*# nfields.ForEach((fi, i) => { mfields.ForEach((fj, j) => { */
                /*# mfields.ForEach((fk, k) => {
                var aik = (k < n) ? "a.Linear.M" + i + k : "a.Trans." + fi;
                */__aik__ * m.M__k____j__/*# }, add); }, comma); }, commaln);*/,

                /*# mfields.ForEach((f, i) => { */m.M__n____i__/*# }, comma);*/);
        }

        /// <summary>
        /// Multiplies a <see cref="__mmmt__"/> and a <see cref="__type__"/> (as a __m__x__m__ matrix).
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __mmmt__ operator *(__mmmt__ m, __type__ a)
        {
            return new __mmmt__(/*# mfields.ForEach((fi, i) => { nfields.ForEach((fj, j) => { */
                /*# nfields.ForEach((fk, k) => {
                */m.M__i____k__ * a.Linear.M__k____j__/*# }, add); }, comma);*/,
                /*# nfields.ForEach((fk, k) => {
                */m.M__i____k__ * a.Trans.__fk__/*# }, add);*/ + m.M__i____n__/*# }, commaln);*/);
        }

        /// <summary>
        /// Multiplies a <see cref="__type__"/> (as a __n__x__m__ matrix) and a <see cref="__mnnt__"/> (as a __m__x__m__ matrix).
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __mnmt__ operator *(__type__ a, __mnnt__ m)
            => new __mnmt__(a.Linear * m, a.Trans);

        /// <summary>
        /// Multiplies a <see cref="__mnnt__"/> and a <see cref="__type__"/> (as a __n__x__m__ matrix).
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __mnmt__ operator *(__mnnt__ m, __type__ a)
            => new __mnmt__(m * a.Linear, m * a.Trans);

        /// <summary>
        /// Multiplies a <see cref="__type__"/> (as a __n__x__m__ matrix) and a <see cref="__mnmt__"/> (as a __m__x__m__ matrix).
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __mnmt__ operator *(__type__ a, __mnmt__ m)
        {
            return new __mnmt__(/*# nfields.ForEach((fi, i) => { nfields.ForEach((fj, j) => { */
                /*# n.ForEach(k => {
                */a.Linear.M__i____k__ * m.M__k____j__/*# }, add); }, comma);*/,
                a.Trans.__fi__ + /*# n.ForEach(k => {*/a.Linear.M__i____k__ * m.M__k____n__/*# }, add); }, commaln);*/);
        }

        /// <summary>
        /// Multiplies a <see cref="__mnmt__"/> and a <see cref="__type__"/> (as a __m__x__m__ matrix).
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __mnmt__ operator *(__mnmt__ m, __type__ a)
        {
            return new __mnmt__(/*# nfields.ForEach((fi, i) => { nfields.ForEach((fj, j) => { */
                /*# nfields.ForEach((fk, k) => {
                */m.M__i____k__ * a.Linear.M__k____j__/*# }, add); }, comma);*/,
                /*# nfields.ForEach((fk, k) => {
                */m.M__i____k__ * a.Trans.__fk__/*# }, add);*/ + m.M__i____n__/*# }, commaln);*/);
        }

        /// <summary>
        /// Multiplies a <see cref="__type__"/> and a <see cref="__euclideannt__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __euclideannt__ e)
            => a * (__type__)e;

        /// <summary>
        /// Multiplies a <see cref="__euclideannt__"/> and a <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__euclideannt__ e, __type__ a)
            => (__type__)e * a;

        /// <summary>
        /// Multiplies a <see cref="__type__"/> and a <see cref="__rotnt__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __rotnt__ r)
            => new __type__(a.Linear * r, a.Trans);

        /// <summary>
        /// Multiplies a <see cref="__rotnt__"/> and a <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__rotnt__ r, __type__ a)
            => new __type__(r * a.Linear, r * a.Trans);

        /// <summary>
        /// Multiplies a <see cref="__type__"/> and a <see cref="__scalent__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __scalent__ s)
        {
            return new __type__(new __mnnt__(/*# nfields.ForEach((fi, i) => { */
                /*# nfields.ForEach((fj, j) => { */a.Linear.M__i____j__ * s.__fj__/*# }, comma); }, comma);*/),
                a.Trans);
        }

        /// <summary>
        /// Multiplies a <see cref="__scalent__"/> and a <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__scalent__ s, __type__ a)
        {
            return new __type__(new __mnnt__(/*# nfields.ForEach((fi, i) => { */
                /*# nfields.ForEach((fj, j) => { */a.Linear.M__i____j__ * s.__fi__/*# }, comma); }, comma);*/),
                a.Trans * s.V);
        }

        /// <summary>
        /// Multiplies a <see cref="__type__"/> and a <see cref="__shiftnt__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __shiftnt__ s)
        {
            return new __type__(a.Linear, a.Linear * s.V + a.Trans);
        }

        /// <summary>
        /// Multiplies a <see cref="__shiftnt__"/> and a <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__shiftnt__ s, __type__ a)
        {
            return new __type__(a.Linear, a.Trans + s.V);
        }

        /// <summary>
        /// Multiplies a <see cref="__type__"/> and a <see cref="__similaritynt__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __similaritynt__ s)
            => a * (__type__)s;

        /// <summary>
        /// Multiplies a <see cref="__similaritynt__"/> and a <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__similaritynt__ s, __type__ a)
            => (__type__)s * a;

        #endregion

        #region Comparison Operators

        /// <summary>
        /// Checks whether two <see cref="__type__"/> transformations are equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(__type__ a0, __type__ a1)
            => (a0.Linear == a1.Linear) && (a0.Trans == a1.Trans); 

        /// <summary>
        /// Checks whether two <see cref="__type__"/> transformations are different.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(__type__ a0, __type__ a1)
            => (a0.Linear != a1.Linear) || (a0.Trans != a1.Trans);

        #endregion

        #region Static Creators

        /// <summary>
        /// Creates an affine transformation from a __n__x__m__ matrix.
        /// The left __n__x__n__ submatrix of <paramref name="matrix"/> must be invertible.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ From__mnmt__(__mnmt__ matrix, __ftype__ epsilon = __eps__)
        {
            var linear = (__mnnt__)matrix;
            var trans = new __vnt__(/*# n.ForEach(i => { */matrix.M__i____n__/*# }, comma); */);

            if (linear.Determinant.IsTiny(epsilon))
                throw new ArgumentException("Matrix must be invertible");

            return new __type__(linear, trans);
        }

        /// <summary>
        /// Creates an affine transformation from a __m__x__m__ matrix.
        /// The matrix <paramref name="m"/> has to be homogeneous and must not contain perspective components and its upper left __n__x__n__ submatrix must be invertible.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ From__mmmt__(__mmmt__ m, __ftype__ epsilon = __eps__)
        {
            if (!(/*#n.ForEach(j => {*/m.M__n____j__.IsTiny(epsilon)/*# }, and);*/))
                throw new ArgumentException("Matrix contains perspective components.");

            if (m.M__n____n__.IsTiny(epsilon))
                throw new ArgumentException("Matrix is not homogeneous.");

            var linear = ((__mnnt__)m) / m.M__n____n__;
            var trans = new __vnt__(/*# n.ForEach(i => { */m.M__i____n__/*# }, comma); */) / m.M__n____n__;

            if (linear.Determinant.IsTiny(epsilon))
                throw new ArgumentException("Matrix must be invertible");

            return new __type__(linear, trans);
        }

        /// <summary>
        /// Creates an affine transformation from a <see cref="__trafont__"/>.
        /// The transformation <paramref name="trafo"/> must represent a valid affine transformation (e.g. it does not contain perspective components).
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ From__trafont__(__trafont__ trafo, __ftype__ epsilon = __eps__)
            => From__mmmt__(trafo.Forward, epsilon);

        #region Translation

        /// <summary>
        /// Creates an <see cref="__type__"/> transformation with the translational component given by __n__ scalars.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Translation(/*# nfields.ForEach(f => { */__ftype__ t__f__/*# }, comma); */)
            => new __type__(__mnnt__.Identity, /*# nfields.ForEach(f => { */t__f__/*# }, comma); */);

        /// <summary>
        /// Creates an <see cref="__type__"/> transformation with the translational component given by a <see cref="__vnt__"/> vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Translation(__vnt__ vector)
            => new __type__(__mnnt__.Identity, vector);

        /// <summary>
        /// Creates an <see cref="__type__"/> transformation with the translational component given by a <see cref="__shiftnt__"/> vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Translation(__shiftnt__ shift)
            => new __type__(__mnnt__.Identity, shift.V);

        #endregion

        #region Scale

        /// <summary>
        /// Creates a scaling transformation using a uniform scaling factor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Scale(__ftype__ scaleFactor)
            => new __type__(__mnnt__.Scale(/*# nfields.ForEach(f => { */scaleFactor/*# }, comma); */));

        /// <summary>
        /// Creates a scaling transformation using __n__ scalars as scaling factors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Scale(/*# nfields.ForEach(f => { */__ftype__ s__f__/*# }, comma); */)
            => new __type__(__mnnt__.Scale(/*# nfields.ForEach(f => { */s__f__/*# }, comma); */));

        /// <summary>
        /// Creates a scaling transformation using a <see cref="__vnt__"/> as scaling factor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Scale(__vnt__ scaleFactors)
            => new __type__(__mnnt__.Scale(scaleFactors));

        /// <summary>
        /// Creates a scaling transformation using a <see cref="__scalent__"/> as scaling factor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Scale(__scalent__ scale)
            => new __type__(__mnnt__.Scale(scale));

        #endregion

        #region Rotation

        /// <summary>
        /// Creates a rotation transformation from a <see cref="__rotnt__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Rotation(__rotnt__ rot)
            => new __type__(__mnnt__.Rotation(rot));

        //# if (n == 2) {
        /// <summary>
        /// Creates a rotation transformation with the specified angle in radians.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Rotation(__ftype__ angleInRadians)
            => new __type__(__mnnt__.Rotation(angleInRadians));

        /// <summary>
        /// Creates a rotation transformation with the specified angle in degrees.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationInDegrees(__ftype__ angleInDegrees)
            => Rotation(angleInDegrees.RadiansFromDegrees());

        //# } else if (n == 3) {
        /// <summary>
        /// Creates a rotation transformation from an axis vector and an angle in radians.
        /// The axis vector has to be normalized.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Rotation(__vnt__ normalizedAxis, __ftype__ angleRadians)
            => new __type__(__mnnt__.Rotation(normalizedAxis, angleRadians));

        /// <summary>
        /// Creates a rotation transformation from an axis vector and an angle in degrees.
        /// The axis vector has to be normalized.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationInDegrees(__vnt__ normalizedAxis, __ftype__ angleDegrees)
            => Rotation(normalizedAxis, angleDegrees.RadiansFromDegrees());

        /// <summary>
        /// Creates a rotation transformation from roll (X), pitch (Y), and yaw (Z) in radians. 
        /// The rotation order is: Z, Y, X.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationEuler(__ftype__ rollInRadians, __ftype__ pitchInRadians, __ftype__ yawInRadians)
            => new __type__(__mnnt__.RotationEuler(rollInRadians, pitchInRadians, yawInRadians));

        /// <summary>
        /// Creates a rotation transformation from roll (X), pitch (Y), and yaw (Z) in degrees. 
        /// The rotation order is: Z, Y, X.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationEulerInDegrees(__ftype__ rollInDegrees, __ftype__ pitchInDegrees, __ftype__ yawInDegrees)
            => RotationEuler(
                rollInDegrees.RadiansFromDegrees(),
                pitchInDegrees.RadiansFromDegrees(),
                yawInDegrees.RadiansFromDegrees());

        /// <summary>
        /// Creates a rotation transformation from roll (X), pitch (Y), and yaw (Z) vector in radians.
        /// The rotation order is: Z, Y, X.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationEuler(__vnt__ rollPitchYawInRadians)
            => RotationEuler(rollPitchYawInRadians.X, rollPitchYawInRadians.Y, rollPitchYawInRadians.Z);

        /// <summary>
        /// Creates a rotation transformation from roll (X), pitch (Y), and yaw (Z) vector in degrees.
        /// The rotation order is: Z, Y, X.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationEulerInDegrees(__vnt__ rollPitchYawInDegrees)
            => RotationEulerInDegrees(
                rollPitchYawInDegrees.X,
                rollPitchYawInDegrees.Y,
                rollPitchYawInDegrees.Z);

        /// <summary>
        /// Creates a rotation transformation which rotates one vector into another.
        /// The input vectors have to be normalized.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotateInto(__vnt__ from, __vnt__ into)
            => new __type__(__mnnt__.RotateInto(from, into));

        /// <summary>
        /// Creates a rotation transformation by <paramref name="angleRadians"/> radians around the x-axis.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationX(__ftype__ angleRadians)
            => new __type__(__mnnt__.RotationX(angleRadians));

        /// <summary>
        /// Creates a rotation transformation for <paramref name="angleDegrees"/> degrees around the x-axis.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationXInDegrees(__ftype__ angleDegrees)
            => RotationX(angleDegrees.RadiansFromDegrees());

        /// <summary>
        /// Creates a rotation transformation by <paramref name="angleRadians"/> radians around the y-axis.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationY(__ftype__ angleRadians)
            => new __type__(__mnnt__.RotationY(angleRadians));

        /// <summary>
        /// Creates a rotation transformation for <paramref name="angleDegrees"/> degrees around the y-axis.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationYInDegrees(__ftype__ angleDegrees)
            => RotationY(angleDegrees.RadiansFromDegrees());

        /// <summary>
        /// Creates a rotation transformation by <paramref name="angleRadians"/> radians around the z-axis.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationZ(__ftype__ angleRadians)
            => new __type__(__mnnt__.RotationZ(angleRadians));

        /// <summary>
        /// Creates a rotation transformation for <paramref name="angleDegrees"/> degrees around the z-axis.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationZInDegrees(__ftype__ angleDegrees)
            => RotationZ(angleDegrees.RadiansFromDegrees());

        //# }
        #endregion

        //# if (n == 3) {
        #region Shear

        /// <summary>
        /// Creates a shear transformation along the z-axis.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ ShearXY(__ftype__ factorX, __ftype__ factorY)
            => new __type__(__mnnt__.ShearXY(factorX, factorY));

        /// <summary>
        /// Creates a shear transformation along the y-axis.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ ShearXZ(__ftype__ factorX, __ftype__ factorZ)
            => new __type__(__mnnt__.ShearXZ(factorX, factorZ));

        /// <summary>
        /// Creates a shear transformation along the x-axis.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ ShearYZ(__ftype__ factorY, __ftype__ factorZ)
            => new __type__(__mnnt__.ShearYZ(factorY, factorZ));

        #endregion

        //# }
        #endregion

        #region Conversions

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __mnmt__(__type__ a)
            => new __mnmt__(a.Linear, a.Trans);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __mnnt__(__type__ a)
            => a.Linear;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __mmmt__(__type__ a)
            => new __mmmt__((__mnmt__)a);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __trafont__(__type__ a)
        {
            Debug.Assert(a.Linear.Invertible);
            var t = (__mmmt__)a;
            return new __trafont__(t, t.Inverse);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __type2__(__type__ a)
            => new __type2__((__mnnt2__)a.Linear, (__vnt2__)a.Trans);

        #endregion

        #region Overrides

        public override int GetHashCode()
        {
            return HashCode.GetCombined(Linear, Trans);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(__type__ other)
            => Linear.Equals(other.Linear) && Trans.Equals(other.Trans);

        public override bool Equals(object other)
            => (other is __type__ o) ? Equals(o) : false;

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "[{0}, {1}]", Linear, Trans);
        }

        public static __type__ Parse(string s)
        {
            var x = s.NestedBracketSplitLevelOne().ToArray();
            return new __type__(__mnnt__.Parse(x[0]), __vnt__.Parse(x[1]));
        }

        #endregion
    }

    public static partial class Affine
    {
        #region Invert

        /// <summary>
        /// Returns the inverse of an <see cref="__type__"/> transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Inverse(__type__ a)
            => a.Inverse;

        /// <summary>
        /// Inverts the given affine transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Invert(this ref __type__ a)
        {
            Debug.Assert(a.Linear.Invertible);
            a.Linear.Invert();
            a.Trans = -a.Linear * a.Trans;
        }

        #endregion

        #region Transformations

        /// <summary>
        /// Transforms a <see cref="__vmt__"/> by an <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vmt__ Transform(this __type__ a, __vmt__ v)
            => a * v;

        /// <summary>
        /// Transforms a <see cref="__vnt__"/> position vector (v.__fn__ is presumed 1) by an <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vnt__ TransformPos(this __type__ a, __vnt__ v)
        {
            return new __vnt__(/*# nfields.ForEach((fi, i) => { */
                /*# nfields.ForEach((fj, j) => { */a.Linear.M__i____j__ * v.__fj__/*# }, add);
                */ + a.Trans.__fi__/*# }, comma);*/);
        }

        /// <summary>
        /// Transforms a <see cref="__vnt__"/> direction vector (v.__fn__ is presumed 0) by an <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vnt__ TransformDir(this __type__ a, __vnt__ v)
        {
            return new __vnt__(/*# nfields.ForEach((fi, i) => { */
                /*# nfields.ForEach((fj, j) => { */a.Linear.M__i____j__ * v.__fj__/*# }, add); }, comma);*/);
        }

        /// <summary>
        /// Transforms a <see cref="__vmt__"/> by the transpose of an <see cref="__type__"/> (as a __m__x__m__ matrix).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vmt__ TransposedTransform(this __type__ a, __vmt__ v)
        {
            return new __vmt__(/*# nfields.ForEach((fi, i) => { */
                /*# nfields.ForEach((fj, j) => { */v.__fj__ * a.Linear.M__j____i__/*# }, add); }, comma);*/,
                /*# nfields.ForEach((f, i) => { */v.__f__ * a.Trans.__f__/*# }, add);*/ + v.__fn__);
        }

        /// <summary>
        /// Transforms a <see cref="__vnt__"/> by the transpose of an <see cref="__type__"/> (as a __m__x__m__ matrix).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vnt__ TransposedTransform(this __type__ a, __vnt__ v)
        {
            return new __vnt__(/*# nfields.ForEach((fi, i) => { */
                /*# nfields.ForEach((fj, j) => { */v.__fj__ * a.Linear.M__j____i__/*# }, add); }, comma);*/);
        }

        /// <summary>
        /// Transforms a <see cref="__vnt__"/> position vector (v.__fn__ is presumed 1) by the transpose of an <see cref="__type__"/> (as a __m__x__m__ matrix).
        /// Projective transform is performed. Perspective Division is performed.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vnt__ TransposedTransformPosProj(this __type__ a, __vnt__ v)
        {
            var s = /*# nfields.ForEach(f => {*/v.__f__ * a.Trans.__f__/*# }, add);*/ + 1;
            return TransposedTransform(a, v) * (1 / s);
        }

        #endregion
    }

    public static partial class Fun
    {
        #region ApproximateEquals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ApproximateEquals(this __type__ a0, __type__ a1)
        {
            return ApproximateEquals(a0, a1, Constant<__ftype__>.PositiveTinyValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ApproximateEquals(this __type__ a0, __type__ a1, __ftype__ tolerance)
        {
            return ApproximateEquals(a0.Linear, a1.Linear, tolerance) && ApproximateEquals(a0.Trans, a1.Trans, tolerance);
        }

        #endregion
    }

    #endregion

    //# }
    //# }
}