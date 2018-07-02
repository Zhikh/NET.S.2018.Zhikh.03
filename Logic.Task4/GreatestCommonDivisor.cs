using System;

namespace Logic.Task4
{
    public static class GreatestCommonDivisor
    {
        public static int Time { get; private set; }

        #region Public methods
        #region Euclidean
        /// <summary>
        /// Finds greatest common divisor for two values by Euclidean's algorithm.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <returns> Greatest common divisor </returns>
        public static int FindGCDEuclidean(int firstValue, int secondValue)
        {
            System.Diagnostics.Stopwatch _watch = System.Diagnostics.Stopwatch.StartNew();
            
            int temp;

            while (firstValue != 0)
            {
                temp = firstValue;
                firstValue = secondValue % firstValue;
                secondValue = temp;
            }

            Time = _watch.Elapsed.Milliseconds;

            return Math.Abs(secondValue);
        }

        // TODO: do with me smth
        #region Common
        /// <summary>
        /// Finds greatest common divisor for three values by Euclidean's algorithm.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="thirdValue"> Third value </param>
        /// <returns> Greatest common divisor </returns>
        public static int FindGCDEuclidean(int firstValue, int secondValue, int thirdValue)
        {
            System.Diagnostics.Stopwatch _watch = System.Diagnostics.Stopwatch.StartNew();

            int gcd = FindGCDEuclidean(firstValue, secondValue);
            int result = FindGCDEuclidean(gcd, thirdValue);

            Time = _watch.Elapsed.Milliseconds;

            return result;
        }

        /// <summary>
        /// Finds greatest common divisor for four values by Euclidean's algorithm.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="thirdValue"> Third value </param>
        /// <param name="fourthValue"> Fourth value </param>
        /// <returns> Greatest common divisor </returns>
        public static int FindGCDEuclidean(int firstValue, int secondValue, int thirdValue, int fourthValue)
        {
            System.Diagnostics.Stopwatch _watch = System.Diagnostics.Stopwatch.StartNew();

            int gcd = FindGCDEuclidean(firstValue, secondValue, thirdValue);
            int result = FindGCDEuclidean(gcd, fourthValue);

            Time = _watch.Elapsed.Milliseconds;

            return result;
        }

        /// <summary>
        /// Finds greatest common divisor for n values by Euclidean's algorithm.
        /// </summary>
        /// <param name="values"> Params </param>
        /// <returns> Greatest common divisor </returns>
        public static int FindGCDEuclidean(params int[] values)
        {
            System.Diagnostics.Stopwatch _watch = System.Diagnostics.Stopwatch.StartNew();

            int gcd = 0;

            foreach (var value in values)
            {
                gcd = FindGCDEuclidean(gcd, value);
            }

            Time = _watch.Elapsed.Milliseconds;

            return gcd;
        }
        #endregion
        #endregion

        #region Stein
        /// <summary>
        /// Finds greatest common divisor for two values by Stein's algorithm.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <returns> Greatest common divisor </returns>
        public static int FindGCDStein(int firstValue, int secondValue)
        {
            int startTime = DateTime.Now.Millisecond;

            if (firstValue == 0)
            {
                return secondValue;
            }

            if (secondValue == 0)
            {
                return firstValue;
            }

            int shift = 0;
            while (((firstValue | secondValue) & 1) == 0)
            {
                firstValue >>= 1;
                secondValue >>= 1;

                shift++;
            }

            firstValue = RemoveFactors(firstValue);

            do
            {
                secondValue = RemoveFactors(secondValue);

                if (firstValue > secondValue)
                {
                    Swap(ref firstValue, ref secondValue);
                }

                secondValue = secondValue - firstValue;
            }
            while (secondValue != 0);

            Time = DateTime.Now.Millisecond - startTime;

            return firstValue << shift;
        }

        // TODO: do with me smth
        #region Common
        /// <summary>
        /// Finds greatest common divisor for three values by Stein's algorithm.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="thirdValue"> Third value </param>
        /// <returns> Greatest common divisor </returns>
        public static int FindGCDStein(int firstValue, int secondValue, int thirdValue)
        {
            int startTime = DateTime.Now.Millisecond;

            int gcd = FindGCDStein(firstValue, secondValue);
            int result = FindGCDStein(gcd, thirdValue);

            Time = DateTime.Now.Millisecond - startTime;

            return result;
        }

        /// <summary>
        /// Finds greatest common divisor for four values by Stein's algorithm.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="thirdValue"> Third value </param>
        /// <param name="fourthValue"> Fourth value </param>
        /// <returns> Greatest common divisor </returns>
        public static int FindGCDStein(int firstValue, int secondValue, int thirdValue, int fourthValue)
        {
            int startTime = DateTime.Now.Millisecond;

            int gcd = FindGCDStein(firstValue, secondValue, thirdValue);
            int result = FindGCDStein(gcd, fourthValue);

            Time = DateTime.Now.Millisecond - startTime;

            return result;
        }

        /// <summary>
        /// Finds greatest common divisor for n values by Stein's algorithm.
        /// </summary>
        /// <param name="values"> Params </param>
        /// <returns> Greatest common divisor </returns>
        public static int FindGCDStein(params int[] values)
        {
            int startTime = DateTime.Now.Millisecond;

            int gcd = 0;

            foreach (var value in values)
            {
                gcd = FindGCDStein(gcd, value);
            }

            Time = DateTime.Now.Millisecond - startTime;

            return gcd;
        }
        #endregion
        #endregion
        #endregion

        #region Private methods
        private static void Swap(ref int firstValue, ref int secondValue)
        {
            int temp = secondValue;

            secondValue = firstValue;
            firstValue = temp;
        }

        private static int RemoveFactors(int value)
        {
            while ((value & 1) == 0)
            {
                value >>= 1;
            }

            return value;
        }
        #endregion
    }
}
