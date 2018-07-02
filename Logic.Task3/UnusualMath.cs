using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Logic.Task3
{
    public static class UnusualMath
    {
        #region Public Methods
        /// <summary>
        /// Finds next number that consist of its numerals.
        /// </summary>
        /// <param name="value"> Value for finding</param>
        /// <param name="time"> Time of work </param>
        /// <returns> Next bigger number </returns>
        /// <exception cref="ArgumentException"> When value less than zero </exception>
        public static TimeSpan FindNextBiggerNumber(int value, ref int nextValue)
        {
            if (value < 0)
            {
                throw new ArgumentException("Argument x can't be less than 0!");
            }

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            int[] array = value.ToArray();

            int tale = array.Length - 1;

            int i = 0;
            int j = 0;
            bool isStop = false;

            while (tale > 0 && !isStop)
            {
                if (tale == j)
                {
                    j--;
                }

                i = tale - 1;
                while ((i >= j) && (i >= 0))
                {
                    if (array[i] < array[tale])
                    {
                        Swap(array, tale, i);

                        isStop = true;

                        break;
                    }

                    i--;
                }

                tale--;
                j++;
            }

            Array.Sort(array, ++i, array.Length - i);

            if (isStop)
            {
                nextValue = array.ToInt();
            }
            else
            {
                nextValue = -1;
            }

            return stopwatch.Elapsed;
        }

        /// <summary>
        /// Converts integer value to integer array.
        /// </summary>
        /// <param name="value"> Number </param>
        /// <returns> Array of numerals of number </returns>
        public static int[] ToArray(this int value)
        {
            if (value == 0)
            {
                return new int[1] { 0 };
            }

            var digits = new List<int>();

            while (value != 0)
            {
                digits.Add(value % 10);
                value /= 10;
            }

            int[] array = digits.ToArray();

            Array.Reverse(array);

            return array;
        }

        /// <summary>
        /// Converts integer array in integer value.
        /// </summary>
        /// <param name="array"> Array for converting </param>
        /// <returns> Integer value of concated values from array </returns>
        /// <exception cref="ArgumentException"> When length of array is more than integer max value size </exception>
        public static int ToInt(this int[] array)
        {
            if (array.Length > int.MaxValue)
            {
                throw new ArgumentException("Length of array can't be more than max value size of int!");
            }

            int result = 0;

            for (int temp = 0; temp < array.Length; temp++)
            {
                result *= 10;
                result += array[temp];
            }

            return result;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Swap elements of array
        /// </summary>
        private static void Swap(int[] array, int taleIndex, int i)
        {
            int temp = array[taleIndex];

            array[taleIndex] = array[i];
            array[i] = temp;
        }
        #endregion
    }
}
