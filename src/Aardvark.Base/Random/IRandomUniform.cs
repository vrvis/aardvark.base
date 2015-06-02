using System.Collections.Generic;
using System.Linq;

namespace Aardvark.Base
{
    /// <summary>
    /// This interface enforces a common API for random number generators.
    /// </summary>
    public interface IRandomUniform
    {
        #region Info and Seeding

        /// <summary>
        /// Returns the number of random bits that the generator
        /// delivers. This many bits are actually random in the 
        /// doubles returned by <see cref="UniformDouble()"/>.
        /// </summary>
        int RandomBits { get; }

        /// <summary>
        /// Returns true if the doubles generated by this random
        /// generator contain 52 random mantissa bits.
        /// </summary>
        bool GeneratesFullDoubles { get; }

        /// <summary>
        /// Reinitializes the random generator with the specified seed.
        /// </summary>
        void ReSeed(int seed);

        #endregion

        #region Random Integers

        /// <summary>
        /// Returns a uniformly distributed integer in the interval
        /// [0, 2^31-1].
        /// </summary>
        int UniformInt();

        /// <summary>
        /// Returns a uniformly distributed integer in the interval
        /// [0, 2^32-1].
        /// </summary>
        uint UniformUInt();

        /// <summary>
        /// Returns a uniformly distributed integer in the interval
        /// [0, 2^63-1].
        /// </summary>
        long UniformLong();

        /// <summary>
        /// Returns a uniformly distributed integer in the interval
        /// [0, 2^64-1].
        /// </summary>
        ulong UniformULong();

        #endregion

        #region Random Floating Point Values

        /// <summary>
        /// Returns a uniformly distributed float in the half-open interval
        /// [0.0f, 1.0f).
        /// </summary>
        float UniformFloat();

        /// <summary>
        /// Returns a uniformly distributed float in the closed interval
        /// [0.0f, 1.0f].
        /// </summary>
        float UniformFloatClosed();

        /// <summary>
        /// Returns a uniformly distributed float in the open interval
        /// (0.0f, 1.0f).
        /// </summary>
        float UniformFloatOpen();

        /// <summary>
        /// Returns a uniformly distributed double in the half-open interval
        /// [0.0, 1.0). Note, that only RandomBits bits are guaranteed to be
        /// random.
        /// </summary>
        double UniformDouble();

        /// <summary>
        /// Returns a uniformly distributed double in the closed interval
        /// [0.0, 1.0]. Note, that only RandomBits bits are guaranteed to be
        /// random.
        /// </summary>
        double UniformDoubleClosed();

        /// <summary>
        /// Returns a uniformly distributed double in the open interval
        /// (0.0, 1.0). Note, that only RandomBits bits are guaranteed to be
        /// random.
        /// </summary>
        double UniformDoubleOpen();

        #endregion
    }

    public static class IRandomUniformExtensions
    {
        #region Random Bits

        /// <summary>
        /// Supply random bits one at a time. The currently unused bits are
        /// maintained in the supplied reference parameter. Before the first
        /// call randomBits must be 0.
        /// </summary>
        public static bool RandomBit(
               this IRandomUniform rnd, ref int randomBits)
        {
            if (randomBits <= 1)
            {
                randomBits = rnd.UniformInt();
                bool bit = (randomBits & 1) != 0;
                randomBits = 0x40000000 | (randomBits >> 1);
                return bit;
            }
            else
            {
                bool bit = (randomBits & 1) != 0;
                randomBits >>= 1;
                return bit;
            }
        }

        #endregion

        #region Random Integers

        /// <summary>
        /// Returns a uniformly distributed int in the interval [0, count-1].
        /// In order to avoid excessive aliasing, two random numbers are used
        /// when count is greater or equal 2^24 and the random generator
        /// delivers 32 random bits or less. The method thus works fairly
        /// decently for all integers.
        /// </summary>
        public static int UniformInt(this IRandomUniform rnd, int size)
        {
            if (rnd.GeneratesFullDoubles || size < 16777216)
                return (int)(rnd.UniformDouble() * size);
            else
                return (int)(rnd.UniformDoubleFull() * size);
        }

        /// <summary>
        /// Returns a uniformly distributed long in the interval [0, size-1].
        /// NOTE: If count has more than about 48 bits, aliasing leads to 
        /// noticeable (greater 5%) shifts in the probabilities (i.e. one
        /// long has a probability of x and the other a probability of
        /// x * (2^(52-b)-1)/(2^(52-b)), where b is log(size)/log(2)).
        /// </summary>
        public static long UniformLong(this IRandomUniform rnd, long size)
        {
            if (rnd.GeneratesFullDoubles || size < 16777216)
                return (long)(rnd.UniformDouble() * size);
            else
                return (long)(rnd.UniformDoubleFull() * size);
        }

        /// <summary>
        /// Returns a uniform int which is guaranteed not to be zero.
        /// </summary>
        public static int UniformIntNonZero(this IRandomUniform rnd)
        {
            int r;
            do { r = rnd.UniformInt(); } while (r == 0);
            return r;
        }

        /// <summary>
        /// Returns a uniform long which is guaranteed not to be zero.
        /// </summary>
        public static long UniformLongNonZero(this IRandomUniform rnd)
        {
            long r;
            do { r = rnd.UniformLong(); } while (r == 0);
            return r;
        }

        #endregion

        #region Random Floating Point Values

        /// <summary>
        /// Returns a uniformly distributed double in the half-open interval
        /// [0.0, 1.0). Note, that two random values are used to make all 53
        /// bits random. If you use this repeatedly, consider using a 64-bit
        /// random generator, which can  provide such doubles directly using
        /// UniformDouble().
        /// </summary>
        public static double UniformDoubleFull(this IRandomUniform rnd)
        {
            if (rnd.GeneratesFullDoubles) return rnd.UniformDouble();
            long r = ((~0xfL & (long)rnd.UniformInt()) << 22)
                      | ((long)rnd.UniformInt() >> 5);
            return r * (1.0 / 9007199254740992.0);
        }

        /// <summary>
        /// Returns a uniformly distributed double in the closed interval
        /// [0.0, 1.0]. Note, that two random values are used to make all 53
        /// bits random.
        /// </summary>
        public static double UniformDoubleFullClosed(this IRandomUniform rnd)
        {
            if (rnd.GeneratesFullDoubles) return rnd.UniformDoubleClosed();
            long r = ((~0xfL & (long)rnd.UniformInt()) << 22)
                      | ((long)rnd.UniformInt() >> 5);
            return r * (1.0 / 9007199254740991.0);
        }

        /// <summary>
        /// Returns a uniformly distributed double in the open interval
        /// (0.0, 1.0). Note, that two random values are used to make all 53
        /// bits random.
        /// </summary>
        public static double UniformDoubleFullOpen(this IRandomUniform rnd)
        {
            if (rnd.GeneratesFullDoubles) return rnd.UniformDoubleOpen();
            long r;
            do
            {
                r = ((~0xfL & (long)rnd.UniformInt()) << 22)
                    | ((long)rnd.UniformInt() >> 5);
            }
            while (r == 0);
            return r * (1.0 / 9007199254740992.0);
        }

        #endregion

        #region Creating Randomly Filled Arrays

        /// <summary>
        /// Create a random array of doubles in the half-open interval
        /// [0.0, 1.0) of the specified length.
        /// </summary>
        public static double[] CreateUniformDoubleArray(
                this IRandomUniform rnd, long length)
        {
            var array = new double[length];
            rnd.FillUniform(array);
            return array;
        }

        /// <summary>
        /// Create a random array of full doubles in the half-open interval
        /// [0.0, 1.0) of the specified length.
        /// </summary>
        public static double[] CreateUniformDoubleFullArray(
            this IRandomUniform rnd, long length)
        {
            var array = new double[length];
            rnd.FillUniformFull(array);
            return array;
        }

        /// <summary>
        /// Fills the specified array with random ints in the interval
        /// [0, 2^31-1].
        /// </summary>
        public static void FillUniform(this IRandomUniform rnd, int[] array)
        {
            long count = array.LongLength;
            for (long i = 0; i < count; i++)
                array[i] = rnd.UniformInt();
        }

        /// <summary>
        /// Fills the specified array with random floats in the half-open
        /// interval [0.0f, 1.0f).
        /// </summary>
        public static void FillUniform(this IRandomUniform rnd, float[] array)
        {
            long count = array.LongLength;
            for (long i = 0; i < count; i++)
                array[i] = rnd.UniformFloat();
        }

        /// <summary>
        /// Fills the specified array with random doubles in the half-open
        /// interval [0.0, 1.0).
        /// </summary>
        public static void FillUniform(
                this IRandomUniform rnd, double[] array)
        {
            long count = array.LongLength;
            for (long i = 0; i < count; i++)
                array[i] = rnd.UniformDouble();
        }

        /// <summary>
        /// Fills the specified array with fully random doubles (53 random
        /// bits) in the half-open interval [0.0, 1.0).
        /// </summary>
        public static void FillUniformFull(
                this IRandomUniform rnd, double[] array)
        {
            long count = array.LongLength;
            if (rnd.GeneratesFullDoubles)
            {
                for (long i = 0; i < count; i++)
                    array[i] = rnd.UniformDoubleFull();
            }
            else
            {
                for (long i = 0; i < count; i++)
                    array[i] = rnd.UniformDouble();
            }
        }

        /// <summary>
        /// Creates an array that contains a random permutation of the
        /// ints in the interval [0, count-1].
        /// </summary>
        public static int[] CreatePermutationArray(
                this IRandomUniform rnd, int count)
        {
            var p = new int[count].SetByIndex(i => i);
            rnd.Randomize(p);
            return p;
        }

        /// <summary>
        /// Creates an array that contains a random permutation of the
        /// numbers in the interval [0, count-1].
        /// </summary>
        public static long[] CreatePermutationArrayLong(
                this IRandomUniform rnd, long count)
        {
            var p = new long[count].SetByIndexLong(i => i);
            rnd.Randomize(p);
            return p;
        }

        #endregion

        #region Creationg a Random Subset (while maintaing order)

        /// <summary>
        /// Returns a random subset of an array with a supplied number of
        /// elements (subsetCount). The elements in the subset are in the
        /// same order as in the original array. O(count).
        /// NOTE: this method needs to generate one random number for each
        /// element of the original array. If subsetCount is signficantly
        /// smaller than count, it is more efficient to use
        /// <see cref="CreateSmallRandomSubsetIndexArray"/> or
        /// <see cref="CreateSmallRandomSubsetIndexArrayLong"/> or
        /// <see cref="CreateSmallRandomOrderedSubsetIndexArray"/> or
        /// <see cref="CreateSmallRandomOrderedSubsetIndexArrayLong"/>.
        /// </summary>
        public static T[] CreateRandomSubsetOfSize<T>(
                this T[] array, long subsetCount, IRandomUniform rnd)
        {
            long count = array.LongLength;
            Requires.That(subsetCount >= 0 && subsetCount <= count);
            var subset = new T[subsetCount];
            long si = 0;
            for (int ai = 0; ai < count && si < subsetCount; ai++)
            {
                var p = (double)(subsetCount - si) / (double)(count - ai);
                if (rnd.UniformDouble() <= p) subset[si++] = array[ai];
            }
            return subset;
        }

        /// <summary>
        /// Creates an unordered array of subsetCount long indices that
        /// constitute a subset of all longs in the range  [0, count-1].
        /// O(subsetCount) for subsetCount &lt;&lt; count.
        /// NOTE: It is assumed that subsetCount is significantly smaller
        /// than count. If this is not the case, use
        /// <see cref="CreateRandomSubsetOfSize"/> instead.
        /// WARNING: As subsetCount approaches count execution time
        /// increases significantly.
        /// </summary>
        public static long[] CreateSmallRandomSubsetIndexArrayLong(
                this IRandomUniform rnd, long subsetCount, long count)
        {
            Requires.That(subsetCount >= 0 && subsetCount <= count);
            var subsetIndices = new LongSet(subsetCount);
            for (int i = 0; i < subsetCount; i++)
            {
                long index;
                do { index = rnd.UniformLong(count); }
                while (!subsetIndices.TryAdd(index));
            }
            return subsetIndices.ToArray();
        }

        /// <summary>
        /// Creates an ordered array of subsetCount long indices that
        /// constitute a subset of all longs in the range [0, count-1].
        /// O(subsetCount * log(subsetCount)) for subsetCount &lt;&lt; count.
        /// NOTE: It is assumed that subsetCount is significantly smaller
        /// than count. If this is not the case, use
        /// <see cref="CreateRandomSubsetOfSize"/> instead.
        /// WARNING: As subsetCount approaches count execution time
        /// increases significantly.
        /// </summary>
        public static long[] CreateSmallRandomOrderedSubsetIndexArrayLong(
                this IRandomUniform rnd, long subsetCount, long count)
        {
            var subsetIndexArray = rnd.CreateSmallRandomSubsetIndexArrayLong(subsetCount, count);
            subsetIndexArray.QuickSortAscending();
            return subsetIndexArray;
        }

        /// <summary>
        /// Creates an unordered array of subsetCount int indices that
        /// constitute a subset of all ints in the range [0, count-1].
        /// O(subsetCount) for subsetCount &lt;&lt; count.
        /// NOTE: It is assumed that subsetCount is significantly smaller
        /// than count. If this is not the case, use
        /// <see cref="CreateRandomSubsetOfSize"/> instead.
        /// WARNING: As subsetCount approaches count execution time
        /// increases significantly.
        /// </summary>
        public static int[] CreateSmallRandomSubsetIndexArray(
                this IRandomUniform rnd, int subsetCount, int count)
        {
            Requires.That(subsetCount >= 0 && subsetCount <= count);
            var subsetIndices = new IntSet(subsetCount);
            for (int i = 0; i < subsetCount; i++)
            {
                int index;
                do { index = rnd.UniformInt(count); }
                while (!subsetIndices.TryAdd(index));
            }
            return subsetIndices.ToArray();
        }

        /// <summary>
        /// Creates an ordered array of subsetCount int indices that
        /// constitute a subset of all ints in the range [0, count-1].
        /// O(subsetCount * log(subsetCount)) for subsetCount &lt;&lt; count.
        /// NOTE: It is assumed that subsetCount is significantly smaller
        /// than count. If this is not the case, use
        /// <see cref="CreateRandomSubsetOfSize"/> instead.
        /// WARNING: As subsetCount approaches count execution time
        /// increases significantly.
        /// </summary>
        public static int[] CreateSmallRandomOrderedSubsetIndexArray(
                this IRandomUniform rnd, int subsetCount, int count)
        {
            var subsetIndexArray = rnd.CreateSmallRandomSubsetIndexArray(subsetCount, count);
            subsetIndexArray.QuickSortAscending();
            return subsetIndexArray;
        }

        #endregion

        #region Randomizing Existing Arrays

        /// <summary>
        /// Randomly permute the first count elements of the
        /// supplied array. This does work with counts of up
        /// to about 2^50. 
        /// </summary>
        public static void Randomize<T>(
                this IRandomUniform rnd, T[] array, long count)
        {
            if (count <= (long)int.MaxValue)
            {
                int intCount = (int)count;
                for (int i = 0; i < intCount; i++)
                    array.Swap(i, rnd.UniformInt(intCount));
            }
            else
            {
                for (long i = 0; i < count; i++)
                    array.Swap(i, rnd.UniformLong(count));
            }
        }

        /// <summary>
        /// Randomly permute the elements of the supplied array. This does
        /// work with arrays up to a length of about 2^50. 
        /// </summary>
        public static void Randomize<T>(
            this IRandomUniform rnd, T[] array)
        {
            rnd.Randomize(array, array.LongLength);
        }

        /// <summary>
        /// Randomly permute the elements of the supplied list.
        /// </summary>
        public static void Randomize<T>(
            this IRandomUniform rnd, List<T> list)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
                list.Swap(i, rnd.UniformInt(count));
        }

        /// <summary>
        /// Randomly permute the specified number of elements in the supplied
        /// array starting at the specified index.
        /// </summary>
        public static void Randomize<T>(
            this IRandomUniform rnd, T[] array, int start, int count)
        {
            for (int i = start, e = start + count; i < e; i++)
                array.Swap(i, start + rnd.UniformInt(count));
        }

        /// <summary>
        /// Randomly permute the specified number of elements in the supplied
        /// array starting at the specified index.
        /// </summary>
        public static void Randomize<T>(
            this IRandomUniform rnd, T[] array, long start, long count)
        {
            for (long i = start, e = start + count; i < e; i++)
                array.Swap(i, start + rnd.UniformLong(count));
        }

        /// <summary>
        /// Randomly permute the specified number of elements in the supplied
        /// list starting at the specified index.
        /// </summary>
        public static void Randomize<T>(
            this IRandomUniform rnd, List<T> list, int start, int count)
        {
            for (int i = start; i < start + count; i++)
                list.Swap(i, start + rnd.UniformInt(count));
        }

        #endregion

        #region V2d

        public static V2d UniformV2d(this IRandomUniform rnd)
        {
            return new V2d(rnd.UniformDouble(),
                           rnd.UniformDouble());
        }

        public static V2d UniformV2dOpen(this IRandomUniform rnd)
        {
            return new V2d(rnd.UniformDoubleOpen(),
                           rnd.UniformDoubleOpen());
        }

        public static V2d UniformV2dClosed(this IRandomUniform rnd)
        {
            return new V2d(rnd.UniformDoubleClosed(),
                           rnd.UniformDoubleClosed());
        }

        public static V2d UniformV2dFull(this IRandomUniform rnd)
        {
            return new V2d(rnd.UniformDoubleFull(),
                           rnd.UniformDoubleFull());
        }

        public static V2d UniformV2dFullOpen(this IRandomUniform rnd)
        {
            return new V2d(rnd.UniformDoubleFullOpen(),
                           rnd.UniformDoubleFullOpen());
        }

        public static V2d UniformV2dFullClosed(this IRandomUniform rnd)
        {
            return new V2d(rnd.UniformDoubleFullClosed(),
                           rnd.UniformDoubleFullClosed());
        }

        public static V2d UniformV2d(this IRandomUniform rnd, Box2d box)
        {
            return new V2d(box.Min.X + rnd.UniformDouble() * (box.Max.X - box.Min.X),
                           box.Min.Y + rnd.UniformDouble() * (box.Max.Y - box.Min.Y));

        }

        public static V2d UniformV2dOpen(this IRandomUniform rnd, Box2d box)
        {
            return new V2d(box.Min.X + rnd.UniformDoubleOpen() * (box.Max.X - box.Min.X),
                           box.Min.Y + rnd.UniformDoubleOpen() * (box.Max.Y - box.Min.Y));

        }

        public static V2d UniformV2dClosed(this IRandomUniform rnd, Box2d box)
        {
            return new V2d(box.Min.X + rnd.UniformDoubleClosed() * (box.Max.X - box.Min.X),
                           box.Min.Y + rnd.UniformDoubleClosed() * (box.Max.Y - box.Min.Y));

        }

        public static V2d UniformV2dFull(this IRandomUniform rnd, Box2d box)
        {
            return new V2d(box.Min.X + rnd.UniformDoubleFull() * (box.Max.X - box.Min.X),
                           box.Min.Y + rnd.UniformDoubleFull() * (box.Max.Y - box.Min.Y));

        }

        public static V2d UniformV2dFullOpen(this IRandomUniform rnd, Box2d box)
        {
            return new V2d(box.Min.X + rnd.UniformDoubleFullOpen() * (box.Max.X - box.Min.X),
                           box.Min.Y + rnd.UniformDoubleFullOpen() * (box.Max.Y - box.Min.Y));

        }

        public static V2d UniformV2dFullClosed(this IRandomUniform rnd, Box2d box)
        {
            return new V2d(box.Min.X + rnd.UniformDoubleFullClosed() * (box.Max.X - box.Min.X),
                           box.Min.Y + rnd.UniformDoubleFullClosed() * (box.Max.Y - box.Min.Y));

        }

        public static V2d UniformV2dDirection(this IRandomUniform rnd)
        {
            double phi = rnd.UniformDouble() * Constant.PiTimesTwo;
            return new V2d(System.Math.Cos(phi),
                           System.Math.Sin(phi));
        }

        #endregion

        #region C3f

        public static C3f UniformC3f(this IRandomUniform rnd)
        {
            return new C3f(rnd.UniformFloat(),
                           rnd.UniformFloat(),
                           rnd.UniformFloat());
        }

        public static C3f UniformC3fOpen(this IRandomUniform rnd)
        {
            return new C3f(rnd.UniformFloatOpen(),
                           rnd.UniformFloatOpen(),
                           rnd.UniformFloatOpen());
        }

        public static C3f UniformC3fClosed(this IRandomUniform rnd)
        {
            return new C3f(rnd.UniformFloatClosed(),
                           rnd.UniformFloatClosed(),
                           rnd.UniformFloatClosed());
        }

        #endregion

        #region V3d

        public static V3d UniformV3d(this IRandomUniform rnd)
        {
            return new V3d(rnd.UniformDouble(),
                           rnd.UniformDouble(),
                           rnd.UniformDouble());
        }

        public static V3d UniformV3dOpen(this IRandomUniform rnd)
        {
            return new V3d(rnd.UniformDoubleOpen(),
                           rnd.UniformDoubleOpen(),
                           rnd.UniformDoubleOpen());
        }

        public static V3d UniformV3dClosed(this IRandomUniform rnd)
        {
            return new V3d(rnd.UniformDoubleClosed(),
                           rnd.UniformDoubleClosed(),
                           rnd.UniformDoubleClosed());
        }

        public static V3d UniformV3dFull(this IRandomUniform rnd)
        {
            return new V3d(rnd.UniformDoubleFull(),
                           rnd.UniformDoubleFull(),
                           rnd.UniformDoubleFull());
        }

        public static V3d UniformV3dFullOpen(this IRandomUniform rnd)
        {
            return new V3d(rnd.UniformDoubleFullOpen(),
                           rnd.UniformDoubleFullOpen(),
                           rnd.UniformDoubleFullOpen());
        }

        public static V3d UniformV3dFullClosed(this IRandomUniform rnd)
        {
            return new V3d(rnd.UniformDoubleFullClosed(),
                           rnd.UniformDoubleFullClosed(),
                           rnd.UniformDoubleFullClosed());
        }

        public static V3d UniformV3d(this IRandomUniform rnd, Box3d box)
        {
            return box.Lerp(rnd.UniformDouble(),
                            rnd.UniformDouble(),
                            rnd.UniformDouble());
        }

        public static V3d UniformV3dOpen(this IRandomUniform rnd, Box3d box)
        {
            return box.Lerp(rnd.UniformDoubleOpen(),
                            rnd.UniformDoubleOpen(),
                            rnd.UniformDoubleOpen());
        }

        public static V3d UniformV3dClosed(this IRandomUniform rnd, Box3d box)
        {
            return box.Lerp(rnd.UniformDoubleClosed(),
                            rnd.UniformDoubleClosed(),
                            rnd.UniformDoubleClosed());
        }

        public static V3d UniformV3dFull(this IRandomUniform rnd, Box3d box)
        {
            return box.Lerp(rnd.UniformDoubleFull(),
                            rnd.UniformDoubleFull(),
                            rnd.UniformDoubleFull());
        }

        public static V3d UniformV3dFullOpen(this IRandomUniform rnd, Box3d box)
        {
            return box.Lerp(rnd.UniformDoubleFullOpen(),
                            rnd.UniformDoubleFullOpen(),
                            rnd.UniformDoubleFullOpen());
        }

        public static V3d UniformV3dFullClosed(this IRandomUniform rnd, Box3d box)
        {
            return box.Lerp(rnd.UniformDoubleFullClosed(),
                            rnd.UniformDoubleFullClosed(),
                            rnd.UniformDoubleFullClosed());
        }

        /// <summary>
        /// Returns a uniformly distributed vecctor (corresponds to a
        /// uniformly distributed point on the unit sphere). Note however,
        /// that the returned vector will never be equal to [0, 0, -1].
        /// </summary>
        public static V3d UniformV3dDirection(this IRandomUniform rnd)
        {
            double phi = rnd.UniformDouble() * Constant.PiTimesTwo;
            double z = 1.0 - rnd.UniformDouble() * 2.0;
            double s = System.Math.Sqrt(1.0 - z * z);
            return new V3d(System.Math.Cos(phi) * s, System.Math.Sin(phi) * s, z);
        }

        public static V3d UniformV3dFullDirection(this IRandomUniform rnd)
        {
            double phi = rnd.UniformDoubleFull() * Constant.PiTimesTwo;
            double z = 1.0 - rnd.UniformDoubleFull() * 2.0;
            double s = System.Math.Sqrt(1.0 - z * z);
            return new V3d(System.Math.Cos(phi) * s, System.Math.Sin(phi) * s, z);
        }

        #endregion
    }

    public static class IRandomEnumerableExtensions
    {
        #region Random Order

        /// <summary>
        /// Enumerates elements in random order.
        /// </summary>
        public static IEnumerable<T> RandomOrder<T>(this IEnumerable<T> self, IRandomUniform rnd = null)
        {
            var tmp = self.ToArray();
            if (rnd == null) rnd = new RandomSystem();
            var perm = rnd.CreatePermutationArray(tmp.Length);
            return perm.Select(index => tmp[index]);
        }

        #endregion
    }
}
