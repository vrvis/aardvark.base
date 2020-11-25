﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Aardvark.Base
{
    // AUTOGENERATED CODE - DO NOT CHANGE!

    //# Action comma = () => Out(", ");
    //# Action commaln = () => Out("," + Environment.NewLine);
    //# Action add = () => Out(" + ");
    //# Action and = () => Out(" && ");
    //# Action or = () => Out(" || ");
    //# Action andLit = () => Out(" and ");
    //# var qfields = new[] {"W", "X", "Y", "Z"};
    //# var qfieldsL = new[] {"w", "x", "y", "z"};
    //# foreach (var isDouble in new[] { false, true }) {
    //#   var ftype = isDouble ? "double" : "float";
    //#   var ftype2 = isDouble ? "float" : "double";
    //#   var tc = isDouble ? "d" : "f";
    //#   var tc2 = isDouble ? "f" : "d";
    //#   var tccaps = tc.ToUpper();
    //#   var tccaps2 = tc2.ToUpper();
    //#   var type = "Quaternion" + tccaps;
    //#   var type2 = "Quaternion" + tccaps2;
    //#   var v3t = "V3" + tc;
    //#   var v4t = "V4" + tc;
    //#   var m44t = "M44" + tc;
    //#   var rot3t = "Rot3" + tc;
    //#   var rot3t2 = "Rot3" + tc2;
    //#   var getptr = "&" + qfields[0];
    //#   var half = isDouble ? "0.5" : "0.5f";
    //#   var pi = isDouble ? "Constant.Pi" : "ConstantF.Pi";
    //#   var piHalf = isDouble ? "Constant.PiHalf" : "ConstantF.PiHalf";
    #region __type__

    /// <summary>
    /// Struct for general quaternions, for rotations in 3-dimensional space use <see cref="Rot3__tc__"/>.
    /// </summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct __type__
    {
        /// <summary>
        /// Scalar (real) part of the quaternion.
        /// </summary>
        [DataMember]
        public __ftype__ W;

        /// <summary>
        /// First component of vector (imaginary) part of the quaternion.
        /// </summary>
        [DataMember]
        public __ftype__ X;

        /// <summary>
        /// Second component of vector (imaginary) part of the quaternion.
        /// </summary>
        [DataMember]
        public __ftype__ Y;

        /// <summary>
        /// Third component of vector (imaginary) part of the quaternion.
        /// </summary>
        [DataMember]
        public __ftype__ Z;

        #region Constructors

        /// <summary>
        /// Creates a <see cref="__type__"/> (a, (a, a, a)).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__ftype__ a)
        {
            W = a;
            X = a; Y = a; Z = a;
        }

        /// <summary>
        /// Creates a <see cref="__type__"/> (w, (x, y, z)).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__ftype__ w, __ftype__ x, __ftype__ y, __ftype__ z)
        {
            W = w;
            X = x; Y = y; Z = z;
        }

        /// <summary>
        /// Creates a <see cref="__type__"/> (v.x, (v.y, v.z, v.w)).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__v4t__ v)
        {
            W = v.X;
            X = v.Y; Y = v.Z; Z = v.W;
        }

        /// <summary>
        /// Creates a <see cref="__type__"/> (w, (v.x, v.y, v.z)).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__ftype__ w, __v3t__ v)
        {
            W = w;
            X = v.X; Y = v.Y; Z = v.Z;
        }

        /// <summary>
        /// Creates a copy of the given <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__type__ q)
        {
            /*# qfields.ForEach(f => {*/__f__ = q.__f__; /*# });*/
        }

        /// <summary>
        /// Creates a <see cref="__type__"/> from the given <see cref="__type2__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__type2__ q)
        {
            /*# qfields.ForEach(f => {*/__f__ = (__ftype__)q.__f__; /*# });*/
        }

        /// <summary>
        /// Creates a <see cref="__type__"/> from the given <see cref="__rot3t__"/> transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__rot3t__ r)
        {
            /*# qfields.ForEach(f => {*/__f__ = r.__f__; /*# });*/
        }

        /// <summary>
        /// Creates a <see cref="__type__"/> from the given <see cref="__rot3t2__"/> transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__rot3t2__ r)
        {
            /*# qfields.ForEach(f => {*/__f__ = (__ftype__)r.__f__; /*# });*/
        }

        /// <summary>
        /// Creates a <see cref="__type__"/> from an array.
        /// (w = a[0], (x = a[1], y = a[2], z = a[3])).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__ftype__[] a)
        {
            W = a[0];
            X = a[1]; Y = a[2]; Z = a[3];
        }

        /// <summary>
        /// Creates a <see cref="__type__"/> from an array starting at specified index.
        /// (w = a[start], (x = a[start+1], y = a[start+2], z = a[start+3])).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public __type__(__ftype__[] a, int start)
        {
            W = a[start];
            X = a[start + 1]; Y = a[start + 2]; Z = a[start + 3];
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the vector part (x, y, z) of this <see cref="__type__"/>.
        /// </summary>
        [XmlIgnore]
        public __v3t__ V
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new __v3t__(X, Y, Z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { X = value.X; Y = value.Y; Z = value.Z; }
        }

        /// <summary>
        /// Gets the squared norm (or squared length) of this <see cref="__type__"/>.
        /// </summary>
        public __ftype__ NormSquared
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => /*# qfields.ForEach(f => {*/__f__ * __f__/*# }, add);*/;
        }

        /// <summary>
        /// Gets the norm (or length) of this <see cref="__type__"/>.
        /// </summary>
        public __ftype__ Norm
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => NormSquared.Sqrt();
        }

        /// <summary>
        /// Gets normalized (unit) quaternion from this <see cref="__type__"/>
        /// </summary>
        public __type__ Normalized
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var rs = new __type__(this);
                rs.Normalize();
                return rs;
            }
        }

        /// <summary>
        /// Gets the (multiplicative) inverse of this <see cref="__type__"/>.
        /// The zero quaternion is returned, if this quaternion is zero.
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

        /// <summary>
        /// Gets the conjugate of this <see cref="__type__"/>.
        /// For unit quaternions this is the same as its inverse.
        /// </summary>
        public __type__ Conjugated
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(W, -V);
        }

        /// <summary>
        /// Gets if this <see cref="__type__"/> is zero.
        /// </summary>
        public bool IsZero
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => /*# qfields.ForEach(f => {*/(__f__ == 0)/*# }, and);*/;
        }

        #endregion

        #region Constants

        /// <summary>
        /// Gets a <see cref="__type__"/> with (0, (0, 0, 0)).
        /// </summary>
        public static __type__ Zero
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(0);
        }

        /// <summary>
        /// Gets a <see cref="__type__"/> with (1, (0, 0, 0)).
        /// </summary>
        public static __type__ One
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(1, 0, 0, 0);
        }

        /// <summary>
        /// Gets the identity <see cref="__type__"/> with (1, (0, 0, 0)).
        /// </summary>
        public static __type__ Identity
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(1, 0, 0, 0);
        }

        /// <summary>
        /// Gets a <see cref="__type__"/> with (0, (1, 0, 0)).
        /// </summary>
        public static __type__ I
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(0, 1, 0, 0);
        }

        /// <summary>
        /// Gets a <see cref="__type__"/> with (0, (0, 1, 0)).
        /// </summary>
        public static __type__ J
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(0, 0, 1, 0);
        }

        /// <summary>
        /// Gets a <see cref="__type__"/> with (0, (0, 0, 1)).
        /// </summary>
        public static __type__ K
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(0, 0, 0, 1);
        }

        #endregion

        #region Arithmetic Operators

        /// <summary>
        /// Returns the component-wise negation of a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator -(__type__ q)
            => new __type__(/*# qfields.ForEach(f => {*/-q.__f__/*# }, comma);*/);

        /// <summary>
        /// Returns the sum of two <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator +(__type__ a, __type__ b)
            => new __type__(/*# qfields.ForEach(f => {*/a.__f__ + b.__f__/*# }, comma);*/);

        /// <summary>
        /// Returns the sum of a <see cref="__type__"/> and a real scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator +(__type__ q, __ftype__ s)
            => new __type__(q.W + s, q.X, q.Y, q.Z);

        /// <summary>
        /// Returns the sum of a real scalar and a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator +(__ftype__ s, __type__ q)
            => new __type__(q.W + s, q.X, q.Y, q.Z);

        /// <summary>
        /// Returns the difference between two <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator -(__type__ a, __type__ b)
            => new __type__(/*# qfields.ForEach(f => {*/a.__f__ - b.__f__/*# }, comma);*/);

        /// <summary>
        /// Returns the difference between a <see cref="__type__"/> and a real scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator -(__type__ q, __ftype__ s)
            => new __type__(q.W - s, q.X, q.Y, q.Z);

        /// <summary>
        /// Returns the difference between a real scalar and a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator -(__ftype__ s, __type__ q)
            => new __type__(s - q.W, -q.X, -q.Y, -q.Z);

        /// <summary>
        /// Returns the product of a <see cref="__type__"/> and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ q, __ftype__ s)
            => new __type__(/*# qfields.ForEach(f => {*/q.__f__ * s/*# }, comma);*/);

        /// <summary>
        /// Returns the product of a scalar and a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__ftype__ s, __type__ q)
            => new __type__(/*# qfields.ForEach(f => {*/q.__f__ * s/*# }, comma);*/);

        /// <summary>
        /// Multiplies two <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __type__ b)
        {
            return new __type__(
                a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z,
                a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y,
                a.W * b.Y + a.Y * b.W + a.Z * b.X - a.X * b.Z,
                a.W * b.Z + a.Z * b.W + a.X * b.Y - a.Y * b.X);
        }

        /// <summary>
        /// Divides two <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator /(__type__ a, __type__ b)
            => a * b.Inverse;

        /// <summary>
        /// Divides a <see cref="__type__"/> by a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator /(__type__ q, __ftype__ s)
            => new __type__(/*# qfields.ForEach(f => {*/q.__f__ / s/*# }, comma);*/);

        /// <summary>
        /// Divides a scalar by a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator /(__ftype__ s, __type__ q)
            => new __type__(/*# qfields.ForEach(f => {*/s / q.__f__/*# }, comma);*/);

        #endregion

        #region Comparison Operators

        /// <summary>
        /// Checks whether two <see cref="__type__"/> are equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(__type__ q0, __type__ q1)
            => /*# qfields.ForEach(f => {*/q0.__f__ == q1.__f__/*# }, and);*/;

        /// <summary>
        /// Checks whether two <see cref="__type__"/> are different.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(__type__ q0, __type__ q1)
            => /*# qfields.ForEach(f => {*/q0.__f__ != q1.__f__/*# }, or);*/;

        #endregion

        #region Conversions

        /// <summary>
        /// Conversion from a <see cref="__type__"/> to a <see cref="__type2__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __type2__(__type__ q)
            => new __type2__(q);

        /// <summary>
        /// Returns this <see cref="__type__"/> as a 4x4 matrix. Quaternions are represented as matrices in such
        /// a way that quaternion multiplication and addition is equivalent to matrix multiplication and addition.
        /// Note that there are 48 distinct such matrix representations for a single quaternion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __m44t__(__type__ q)
        {
            return new __m44t__(
                q.W, -q.X, -q.Y, -q.Z,
                q.X,  q.W, -q.Z,  q.Y,
                q.Y,  q.Z,  q.W, -q.X,
                q.Z, -q.Y,  q.X,  q.W);
        }

        /// <summary>
        /// Returns this <see cref="__type__"/> as a <see cref="__v4t__"/> vector.
        /// Note that the components are ordered (w, x, y, z).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __v4t__(__type__ q)
            => new __v4t__(/*# qfields.ForEach(f => {*/q.__f__/*# }, comma);*/);

        /// <summary>
        /// Returns all values of a <see cref="__type__"/> instance
        /// in a __ftype__[] array.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __ftype__[](__type__ q)
        {
            __ftype__[] array = new __ftype__[__qfields.Length__];
            /*# qfields.ForEach((f, i) => {*/array[__i__] = q.__f__;
            /*# });*/return array;
        }

        #endregion

        #region Indexing

        /// <summary>
        /// Gets or sets the <paramref name="i"/>-th component of the <see cref="__type__"/> with components (w, (x, y, z)).
        /// </summary>
        public unsafe __ftype__ this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (__ftype__* ptr = __getptr__) { return ptr[i]; }
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                fixed (__ftype__* ptr = __getptr__) { ptr[i] = value; }
            }
        }

        #endregion

        #region Overrides

        public override int GetHashCode()
        {
            return HashCode.GetCombined(W, X, Y, Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(__type__ other)
            => /*# qfields.ForEach(f => {*/__f__.Equals(other.__f__)/*# }, and);*/;

        public override bool Equals(object other)
            => (other is __type__ o) ? Equals(o) : false;

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "[{0}, {1}, {2}, {3}]", W, X, Y, Z);
        }

        public static __type__ Parse(string s)
        {
            var x = s.NestedBracketSplitLevelOne().ToArray();
            return new __type__(/*# 4.ForEach(i => {*/__ftype__.Parse(x[__i__], CultureInfo.InvariantCulture)/*# }, comma);*/);
        }

        #endregion
    }

    public static partial class Quaternion
    {
        #region Invert, Normalize, Conjugate, Dot

        /// <summary>
        /// Returns the inverse of a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Inverse(__type__ q)
            => q.Inverse;

        /// <summary>
        /// Inverts a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Invert(this ref __type__ q)
        {
            var norm = q.NormSquared;
            if (norm > 0)
            {
                var scale = 1 / norm;
                q.W *= scale;
                q.X *= -scale;
                q.Y *= -scale;
                q.Z *= -scale;
            }
        }

        /// <summary>
        /// Returns a normalized copy of a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Normalized(__type__ q)
            => q.Normalized;

        /// <summary>
        /// Normalizes a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normalize(this ref __type__ q)
        {
            var norm = q.Norm;
            if (norm > 0)
            {
                var scale = 1 / norm;
                q.W *= scale;
                q.X *= scale;
                q.Y *= scale;
                q.Z *= scale;
            }
        }

        /// <summary>
        /// Returns the conjugate of a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Conjugated(__type__ q)
            => q.Conjugated;

        /// <summary>
        /// Conjugates a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Conjugate(this ref __type__ q)
        {
            q.X = -q.X;
            q.Y = -q.Y;
            q.Z = -q.Z;
        }

        /// <summary> 
        /// Returns the dot product of two <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __ftype__ Dot(this __type__ a, __type__ b)
        {
            return a.W * b.W + a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        #endregion

        #region Norm

        /// <summary>
        /// Gets the squared norm (or length) of a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __ftype__ NormSquared(__type__ q)
            => q.NormSquared;

        /// <summary>
        /// Gets the norm (or length) of a <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __ftype__ Norm(__type__ q)
            => q.Norm;

        #endregion

        #region Spherical Linear Interpolation

        /// <summary>
        /// Spherical linear interpolation.
        ///
        /// Assumes q1 and q2 are normalized and that t in [0,1].
        ///
        /// This method interpolates along the shortest arc between q1 and q2.
        /// </summary>
        public static __type__ SlerpShortest(this __type__ q1, __type__ q2, __ftype__ t)
        {
            __type__ q3 = q2;
            __ftype__ cosomega = Dot(q1, q3);

            if (cosomega < 0)
            {
                cosomega = -cosomega;
                q3 = -q3;
            }

            if (cosomega >= 1)
            {
                // Special case: q1 and q2 are the same, so just return one of them.
                // This also catches the case where cosomega is very slightly > 1.0
                return q1;
            }

            __ftype__ sinomega = Fun.Sqrt(1 - cosomega * cosomega);

            __type__ result;

            if (sinomega * __ftype__.MaxValue > 1)
            {
                __ftype__ omega = Fun.Acos(cosomega);
                __ftype__ s1 = Fun.Sin((1 - t) * omega) / sinomega;
                __ftype__ s2 = Fun.Sin(t * omega) / sinomega;

                result = new __type__(s1 * q1 + s2 * q3);
            }
            else if (cosomega > 0)
            {
                // omega == 0
                __ftype__ s1 = 1 - t;
                __ftype__ s2 = t;

                result = new __type__(s1 * q1 + s2 * q3);
            }
            else
            {
                // omega == -pi
                result = new __type__(q1.Z, -q1.Y, q1.X, -q1.W);

                __ftype__ s1 = Fun.Sin((__half__ - t) * __pi__);
                __ftype__ s2 = Fun.Sin(t * __pi__);

                result = new __type__(s1 * q1 + s2 * result);
            }

            return result;
        }

        #endregion
    }

    public static partial class Fun
    {
        #region ApproximateEquals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ApproximateEquals(this __type__ q0, __type__ q1)
        {
            return ApproximateEquals(q0, q1, Constant<__ftype__>.PositiveTinyValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ApproximateEquals(this __type__ q0, __type__ q1, __ftype__ tolerance)
        {
            return /*# qfields.ForEach(f => {*/ApproximateEquals(q0.__f__, q1.__f__, tolerance)/*# }, and);*/;
        }

        #endregion
    }

    #endregion

    //# }
}