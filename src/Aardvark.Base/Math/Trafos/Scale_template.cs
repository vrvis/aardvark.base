﻿using System;
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
    //# Action endl = () => Out(Environment.NewLine);
    //# Action add = () => Out(" + ");
    //# Action and = () => Out(" && ");
    //# Action or = () => Out(" || ");
    //# Action andLit = () => Out(" and ");
    //# var fields = new[] {"X", "Y", "Z", "W"};
    //# foreach (var isDouble in new[] { false, true }) {
    //# for (int d = 2; d <= 3; d++) {
    //#   var d1 = d + 1;
    //#   var ftype = isDouble ? "double" : "float";
    //#   var xyz = "XYZW".Substring(0, d);
    //#   var tc = isDouble ? "d" : "f";
    //#   var tc2 = isDouble ? "f" : "d";
    //#   var type = "Scale" + d + tc;
    //#   var type2 = "Scale" + d + tc2;
    //#   var trafodt = "Trafo" + d + tc;
    //#   var affinedt = "Affine" + d + tc;
    //#   var euclideandt = "Euclidean" + d + tc;
    //#   var rotdt = "Rot" + d + tc;
    //#   var shiftdt = "Shift" + d + tc;
    //#   var similaritydt = "Similarity" + d + tc;
    //#   var mddt = "M" + d + d + tc;
    //#   var md1d1t = "M" + d1 + d1 + tc;
    //#   var vdt = "V" + d + tc;
    //#   var vdt2 = "V" + d + tc2;
    //#   var dfields = fields.Take(d).ToArray();
    //#   var fd = fields[d];
    //#   var eps = isDouble ? "1e-12" : "1e-5f";
    #region __type__

    /// <summary>
    /// A __d__-dimensional scaling transform with different scaling values
    /// in each dimension.
    /// </summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct __type__
    {
        [DataMember]
        public __vdt__ V;

        #region Constructors

        /// <summary>
        /// Constructs a <see cref="__type__"/> transformation from __d__ __ftype__s.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(/*# dfields.ForEach(f => { */__ftype__ s__f__/*# }, comma); */)
        {
            V = new __vdt__(/*# dfields.ForEach(f => { */s__f__/*# }, comma); */);
        }

        /// <summary>
        /// Constructs a <see cref="__type__"/> from __d__ scaling factors provided as <see cref="__vdt__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__vdt__ scalingFactors)
        {
            V = scalingFactors;
        }

        /// <summary>
        /// Constructs a <see cref="__type__"/> transformation from a uniform __ftype__ value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__ftype__ uniform)
        {
            V = new __vdt__(/*# dfields.ForEach(f => { */uniform/*# }, comma); */);
        }

        /// <summary>
        /// Constructs a copy of a <see cref="__type__"/> transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__type__ scale)
        {
            V = scale.V;
        }

        /// <summary>
        /// Constructs a <see cref="__type__"/> transformation from a __ftype__-array.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__ftype__[] array)
        {
            V = new __vdt__(array);
        }

        /// <summary>
        /// Constructs a <see cref="__type__"/> transformation from a __ftype__-array starting from the given index.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__ftype__[] array, int start)
        {
            V = new __vdt__(array, start);
        }

        #endregion

        #region Properties

        //# dfields.ForEach(f => {
        /// <summary>
        /// Gets and sets the __f__ coordinate.
        /// </summary>
        public __ftype__ __f__
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return V.__f__; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { V.__f__ = value; }
        }

        //# });
        /// <summary>
        /// Gets the inverse of this <see cref="__type__"/> transformation.
        /// </summary>
        public __type__ Inverse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(/*# dfields.ForEach(f => { */1 / __f__/*# }, comma); */);
        }

        #endregion

        #region Constants

        /// <summary>
        /// Gets the identity <see cref="__type__"/> transformation.
        /// </summary>
        public static __type__ Identity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(/*# dfields.ForEach(f => { */1/*# }, comma); */);
        }

        /// <summary>
        /// Gets a <see cref="__type__"/> transformation with all components set to zero.
        /// </summary>
        public static __type__ Zero
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(/*# dfields.ForEach(f => { */0/*# }, comma); */);
        }

        //# dfields.ForEach((fi, i) => {
        /// <summary>
        /// Gets a <see cref="__type__"/> transformation with scaling factors (/*# dfields.ForEach((fj, j) => { var val = (i != j) ? "0" : "1"; */__val__/*# }, comma); */).
        /// </summary>
        public static __type__ __fi__Axis
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(/*# dfields.ForEach((fj, j) => { var val = (i != j) ? "0" : "1"; */__val__/*# }, comma); */);
        }

        //# });
        #endregion

        #region Arithmetic Operators

        /// <summary>
        /// Negates the values of a <see cref="__type__"/> transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator -(__type__ scale)
        {
            return new __type__(/*# dfields.ForEach(f => { */-scale.__f__/*# }, comma); */);
        }

        #region Scale / Scalar

        /// <summary>
        /// Multiplies a <see cref="__type__"/> transformation with a __ftype__ scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ scale, __ftype__ scalar)
        {
            return new __type__(/*# dfields.ForEach(f => { */scale.__f__ * scalar/*# }, comma); */);
        }

        /// <summary>
        /// Multiplies a __ftype__ scalar with a <see cref="__type__"/> transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__ftype__ scalar, __type__ scale)
        {
            return new __type__(/*# dfields.ForEach(f => { */scale.__f__ * scalar/*# }, comma); */);
        }

        /// <summary>
        /// Divides a <see cref="__type__"/> transformation by a __ftype__ scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator /(__type__ scale, __ftype__ scalar)
        {
            return new __type__(/*# dfields.ForEach(f => { */scale.__f__ / scalar/*# }, comma); */);
        }

        /// <summary>
        /// Divides a __ftype__ scalar by a <see cref="__type__"/> transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator /(__ftype__ scalar, __type__ scale)
        {
            return new __type__(/*# dfields.ForEach(f => { */scalar / scale.__f__/*# }, comma); */);
        }

        #endregion

        #region Scale / Vector Multiplication

        /// <summary>
        /// Multiplies a <see cref="__type__"/> transformation with a <see cref="__vdt__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vdt__ operator *(__type__ scale, __vdt__ vector)
        {
            return new __vdt__(/*# dfields.ForEach(f => { */vector.__f__ * scale.__f__/*# }, comma); */);
        }

        #endregion

        #region Scale / Scale Multiplication

        //# for (int n = 2; n <= 3; n++) {
        //# var r = (d > n) ? d : n;
        //# var m = (d < n) ? d : n;
        //# var mfields = fields.Take(m);
        //# var rem = r - m;
        //# var ntype = "Scale" + n + tc;
        //# var rtype = "Scale" + r + tc;
        /// <summary>
        /// Multiplies a <see cref="__type__"/> transformation with a <see cref="__ntype__"/> transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __rtype__ operator *(__type__ a, __ntype__ b)
            => new __rtype__(/*# mfields.ForEach(f => {*/a.__f__ * b.__f__/*# }, comma);
                if (r > m) {*/, /*# rem.ForEach(i => {
                var x = (d > n) ? "a" : "b";
                var f = fields[m + i]; */__x__.__f__/*#}, comma); } */);

        //# }
        #endregion

        #region Scale / Matrix Multiplication

        //# for (int n = d; n <= d+1; n++) {
        //# for (int m = n; m <= (n + 1) && m <= d+1; m++) {
        //#     var mat = "M" + n + m + tc;
        //#     var nfields = dfields.Take(n);
        //#     var mfields = dfields.Take(m);
        //#     var nrem = n - d;
        //#     var mrem = m - d;
        /// <summary>
        /// Multiplies a <see cref="__type__"/> transformation (as a __n__x__n__ matrix) with a <see cref="__mat__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __mat__ operator *(__type__ scale, __mat__ matrix)
        {
            return new __mat__(/*# nfields.ForEach((fi, i) => { */
                /*# m.ForEach(j => { */scale.__fi__ * matrix.M__i____j__/*# }, comma); }, comma);
                 if (nrem > 0) {*/, /*# nrem.ForEach(i => { */
                /*# var ipd = i + d; m.ForEach(j => { */matrix.M__ipd____j__/*# }, comma); }, comma); }*/);
        }

        //# var rem = m - d;
        /// <summary>
        /// Multiplies a <see cref="__mat__"/> with a <see cref="__type__"/> transformation (as a __m__x__m__ matrix).
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __mat__ operator *(__mat__ matrix, __type__ scale)
        {
            return new __mat__(/*# n.ForEach(i => { */
                /*# mfields.ForEach((fj, j) => { */matrix.M__i____j__ * scale.__fj__/*# }, comma);
                  if (mrem > 0) {*/, /*# mrem.ForEach(j => {
                  var jpd = j + d; */matrix.M__i____jpd__/*# }, comma); } }, comma);*/);
        }

        //# } }
        #endregion

        #region Scale / Rot, Shift Multiplication

        /// <summary>
        /// Multiplies a <see cref="__type__"/> transformation with a <see cref="__rotdt__"/> transformation.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __affinedt__ operator *(__type__ a, __rotdt__ b)
            => new __affinedt__((__mddt__)a * (__mddt__)b);

        /// <summary>
        /// Multiplies a <see cref="__type__"/> transformation with a <see cref="__shiftdt__"/> transformation.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __affinedt__ operator *(__type__ a, __shiftdt__ b)
            => new __affinedt__((__mddt__)a, a * b.V);

        #endregion

        #endregion

        #region Comparison Operators

        /// <summary>
        /// Checks whether two <see cref="__type__"/> transformations are equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(__type__ s0, __type__ s1)
            => /*# dfields.ForEach(f => {*/s0.__f__ == s1.__f__/*# }, and);*/;

        /// <summary>
        /// Checks whether two <see cref="__type__"/> transformations are different.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(__type__ s0, __type__ s1)
            => /*# dfields.ForEach(f => {*/s0.__f__ != s1.__f__/*# }, or);*/;

        #endregion

        #region Static Creators

        /// <summary>
        /// Creates a <see cref="__type__"/> transformation from a scaling <see cref="__mddt__"/> matrix.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ From__mddt__(__mddt__ m, __ftype__ epsilon = (__ftype__)1e-6)
        {
            if (!(/*# d.ForEach(i => {*/Fun.IsTiny(m.C__i__ * __vdt__./*#
                      d.ForEach(j => { var x = (i == j) ? "O" : "I"; */__x__/*# });*/, epsilon)/*# }, and);*/))
                throw new ArgumentException("Matrix is not a pure scaling matrix.");

            return new __type__(/*# d.ForEach(i => {*/m.M__i____i__/*# }, comma);*/);
        }

        /// <summary>
        /// Creates a <see cref="__type__"/> transformation from a scaling <see cref="__md1d1t__"/> matrix.
        /// The matrix has to be homogeneous and must not contain perspective components.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ From__md1d1t__(__md1d1t__ m, __ftype__ epsilon = (__ftype__)1e-6)
        {
            if (!(/*# d.ForEach(i => {*/Fun.IsTiny(m.C__i__.__xyz__ * __vdt__./*#
                      d.ForEach(j => { var x = (i == j) ? "O" : "I"; */__x__/*# });*/, epsilon)/*# }, and);*/))
                throw new ArgumentException("Matrix is not a pure scaling matrix.");

            if (!(/*#d.ForEach(j => {*/m.M__d____j__.IsTiny(epsilon)/*# }, and);*/))
                throw new ArgumentException("Matrix contains perspective components.");

            if (!m.C__d__.__xyz__.IsTiny(epsilon))
                throw new ArgumentException("Matrix contains translational component.");

            if (m.M__d____d__.IsTiny(epsilon))
                throw new ArgumentException("Matrix is not homogeneous.");

            return new __type__(/*# d.ForEach(i => {*/m.M__i____i__ / m.M__d____d__/*# }, comma);*/);
        }

        /// <summary>
        /// Creates a <see cref="__type__"/> transformation from a <see cref="__similaritydt__"/>.
        /// The transformation <paramref name="similarity"/> must only consist of a scaling.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ From__similaritydt__(__similaritydt__ similarity, __ftype__ epsilon = __eps__)
        {
            if (!similarity.Trans.IsTiny(epsilon))
                throw new ArgumentException("Similarity transformation contains translational component");

            if (!similarity.Rot.ApproximateEquals(__rotdt__.Identity, epsilon))
                throw new ArgumentException("Similarity transformation contains rotational component");

            return new __type__(similarity.Scale);
        }

        /// <summary>
        /// Creates a <see cref="__type__"/> transformation from an <see cref="__affinedt__"/>.
        /// The transformation <paramref name="affine"/> must only consist of a scaling.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ From__affinedt__(__affinedt__ affine, __ftype__ epsilon = __eps__)
            => From__md1d1t__((__md1d1t__)affine, epsilon);

        /// <summary>
        /// Creates a <see cref="__type__"/> transformation from a <see cref="__trafodt__"/>.
        /// The transformation <paramref name="trafo"/> must only consist of a scaling.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ From__trafodt__(__trafodt__ trafo, __ftype__ epsilon = __eps__)
            => From__md1d1t__(trafo.Forward, epsilon);

        #endregion

        #region Conversion

        //# for (int n = 2; n <= 4; n++) {
        //# for (int m = n; m <= (n+1) && m <= 4; m++) {
        //#     var mat = "M" + n + m + tc;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __mat__(__type__ s)
        {
            return new __mat__(/*# n.ForEach(i => { */
                /*# m.ForEach(j => {
                   var x = (i == j) ? ((i < d) ? "s." + fields[i] : "1  ") : "0  ";
                */__x__/*# }, comma); }, comma);*/);
        }

        //# } }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __affinedt__(__type__ s)
            => new __affinedt__((__mddt__)s, __vdt__.Zero);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __trafodt__(__type__ s)
            => new __trafodt__((__md1d1t__)s, (__md1d1t__)s.Inverse);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __type2__(__type__ s)
            => new __type2__((__vdt2__)s.V);

        /// <summary>
        /// Returns all values of a <see cref="__type__"/> instance
        /// in a __ftype__[] array.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __ftype__[](__type__ s)
            => (__ftype__[])s.V;

        #endregion

        #region Indexing

        public __ftype__ this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                switch (index)
                {
                    /*# dfields.ForEach((f, i) => {*/case __i__: return V.__f__;
                    /*# });*/default: throw new IndexOutOfRangeException();
                }
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                switch (index)
                {
                    /*# dfields.ForEach((f, i) => {*/case __i__: V.__f__ = value; return;
                    /*# });*/default: throw new IndexOutOfRangeException();
                }
            }
        }

        #endregion

        #region Overrides

        public override int GetHashCode()
        {
            return V.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(__type__ other)
            => /*# dfields.ForEach(f => {*/__f__.Equals(other.__f__)/*# }, and);*/;

        public override bool Equals(object other)
            => (other is __type__ o) ? Equals(o) : false;

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "[/*# d.ForEach(i => {*/{__i__}/*# }, comma);*/]", /*# dfields.ForEach(f => {*/__f__/*#}, comma);*/);
        }

        public static __type__ Parse(string s)
        {
            var x = s.NestedBracketSplitLevelOne().ToArray();
            return new __type__(/*# d.ForEach(i => {*/
                __ftype__.Parse(x[__i__], CultureInfo.InvariantCulture)/*# }, comma);*/
            );
        }

        #endregion
    }

    public static partial class Scale
    {
        #region Invert

        /// <summary>
        /// Returns the inverse of a <see cref="__type__"/> transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Inverse(__type__ scale)
            => scale.Inverse;

        /// <summary>
        /// Inverts a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Invert(this ref __type__ scale)
        {
            //# dfields.ForEach(f => {
            scale.V.__f__ = 1 / scale.V.__f__;
            //# });
        }

        #endregion

        #region Transformations

        //# for (int n = d; n <= 4; n++) {
        //# var vec = "V" + n + tc;
        //# var rem = n - d;
        //# var constfields = fields.Skip(d).Take(rem);
        //# var isare = (rem > 1) ? "are" : "is";
        /// <summary>
        /// Transforms a <see cref="__vec__"/> vector by a <see cref="__type__"/> transformation./*# if (rem > 0) { */
        /// /*# constfields.ForEach(f => {*/v.__f__/*# }, andLit); */ __isare__ not modified./*# }*/
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vec__ Transform(this __type__ s, __vec__ v)
            => new __vec__(/*# dfields.ForEach(f => {*/v.__f__ * s.__f__/*# }, comma);
                if (rem > 0) {*/, /*# rem.ForEach(i => {
                var f = fields[d + i]; */v.__f__/*#}, comma); } */);

        /// <summary>
        /// Transforms a <see cref="__vec__"/> vector by the inverse of a <see cref="__type__"/> transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vec__ InvTransform(this __type__ s, __vec__ v)
            => new __vec__(/*# dfields.ForEach(f => {*/v.__f__ / s.__f__/*# }, comma);
                if (rem > 0) {*/, /*# rem.ForEach(i => {
                var f = fields[d + i]; */v.__f__/*#}, comma); } */);

        //# }
        #endregion
    }

    public static partial class Fun
    {
        #region ApproximateEquals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ApproximateEquals(this __type__ s0, __type__ s1)
        {
            return ApproximateEquals(s0.V, s1.V, Constant<__ftype__>.PositiveTinyValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ApproximateEquals(this __type__ s0, __type__ s1, __ftype__ tolerance)
        {
            return ApproximateEquals(s0.V, s1.V, tolerance);
        }

        #endregion
    }

    #endregion

    //# } }
}
