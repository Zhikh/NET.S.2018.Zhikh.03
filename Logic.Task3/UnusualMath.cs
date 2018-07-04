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
        /// <returns> Next bigger number </returns>
        /// <exception cref="ArgumentException"> When value less than zero </exception>
        public static int FindNextBiggerNumber(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Argument x can't be less than 0!");
            }
            
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

                i = TryExchange(array, tale, j, ref isStop);

                tale--;
                j++;
            }

            Array.Sort(array, ++i, array.Length - i);

            if (isStop)
            {
                return array.ToInt();
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Finds next number that consist of its numerals.
        /// </summary>
        /// <param name="value"> Value for finding</param>
        /// <param name="time"> Time of work </param>
        /// <returns> Next bigger number </returns>
        /// <exception cref="ArgumentException"> When value less than zero </exception>
        public static int FindNextBiggerNumber(int value, out TimeSpan time)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            int result = FindNextBiggerNumber(value);

            stopwatch.Stop();
            time = stopwatch.Elapsed;

            return result;
        }

        #endregion

        #region Private methods
        private static int TryExchange(int[] array, int tale, int j, ref bool isStop)
        {
            int i = tale - 1;

            while ((i >= j) && (i >= 0))
            {
                if (array[i] < array[tale])
                {
                    Swap(ref array[i], ref array[tale]);

                    isStop = true;

                    break;
                }

                i--;
            }

            return i;
        }

        // Converts integer value to integer array.
        private static int[] ToArray(this int value)
        {
            try
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        // Converts integer array in integer value.
        private static int ToInt(this int[] array)
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
        
        // Swap elements of array
        private static void Swap(ref int firstValue, ref int secondValue)
        {
            int temp = firstValue;

            firstValue = secondValue;
            secondValue = temp;
        }
        #endregion
    }
}
