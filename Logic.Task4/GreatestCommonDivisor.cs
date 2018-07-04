using System;

namespace Logic.Task4
{
    public static class GreatestCommonDivisor
    {
        private delegate int FindTwo(int x, int y);
        private delegate int FindThree(int x, int y, int z);

        #region Public methods
        #region Euclidean
        /// <summary>
        /// Finds greatest common divisor for three values.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCDEuclidean(int firstValue, int secondValue)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int temp;

            while (firstValue != 0)
            {
                temp = firstValue;
                firstValue = secondValue % firstValue;
                secondValue = temp;
            }

            return (Math.Abs(secondValue), watch.Elapsed.Milliseconds);
        }

        /// <summary>
        /// Finds greatest common divisor for three values.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="thirdValue"> Third value </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCDEuclidean(int firstValue, int secondValue, int thirdValue)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = FindGCDEuclidean(firstValue, secondValue).Value;

            return (FindGCDEuclidean(gcd, thirdValue).Value, watch.Elapsed.Milliseconds);
        }

        /// <summary>
        /// Finds greatest common divisor for four values.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="thirdValue"> Third value </param>
        /// <param name="fourthValue"> Fourth value </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCDEuclidean(int firstValue, int secondValue, int thirdValue, int fourthValue)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = FindGCDEuclidean(firstValue, secondValue, thirdValue).Value;
            
            return (FindGCDEuclidean(gcd, fourthValue).Value, watch.Elapsed.Milliseconds);
        }

        /// <summary>
        /// Finds greatest common divisor for n values.
        /// </summary>
        /// <param name="values"> Params </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCDEuclidean(params int[] values)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = 0;

            foreach (var value in values)
            {
                gcd = FindGCDEuclidean(gcd, value).Value;
            }
            
            watch.Stop();
            return (gcd, watch.Elapsed.Milliseconds);
        }
        #endregion

        #region Stein
        /// <summary>
        /// Finds greatest common divisor for three values.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCDStein(int firstValue, int secondValue)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            if (firstValue == 0)
            {
                return (secondValue, watch.Elapsed.Milliseconds);
            }

            if (secondValue == 0)
            {
                return (firstValue, watch.Elapsed.Milliseconds);
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

            return (firstValue << shift, watch.Elapsed.Milliseconds);
        }

        /// <summary>
        /// Finds greatest common divisor for three values.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="thirdValue"> Third value </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCDStein(int firstValue, int secondValue, int thirdValue)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = FindGCDStein(firstValue, secondValue).Value;

            return (FindGCDStein(gcd, thirdValue).Value, watch.Elapsed.Milliseconds);
        }

        /// <summary>
        /// Finds greatest common divisor for four values.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="thirdValue"> Third value </param>
        /// <param name="fourthValue"> Fourth value </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCDStein(int firstValue, int secondValue, int thirdValue, int fourthValue)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = FindGCDStein(firstValue, secondValue, thirdValue).Value;

            return (FindGCDStein(gcd, fourthValue).Value, watch.Elapsed.Milliseconds);
        }

        public static (int Value, int Time) FindGCDStein(params int[] values)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = 0;

            foreach (var value in values)
            {
                gcd = FindGCDStein(gcd, value).Value;
            }

            watch.Stop();
            return (gcd, watch.Elapsed.Milliseconds);
        }
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
