using System;

namespace Logic.Task4
{
    public static class GreatestCommonDivisor
    {
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
            => FindGCD(firstValue, secondValue, thirdValue, FindGCDEuclidean);

        /// <summary>
        /// Finds greatest common divisor for four values.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="thirdValue"> Third value </param>
        /// <param name="fourthValue"> Fourth value </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCDEuclidean(int firstValue, int secondValue, int thirdValue, int fourthValue) 
            => FindGCD(firstValue, secondValue, thirdValue, fourthValue, FindGCDEuclidean);

        /// <summary>
        /// Finds greatest common divisor for n values.
        /// </summary>
        /// <param name="values"> Values for getting gcd </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCDEuclidean(params int[] values) 
            => FindGCD(FindGCDEuclidean, values);
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
            => FindGCD(firstValue, secondValue, thirdValue, FindGCDStein);

        /// <summary>
        /// Finds greatest common divisor for four values.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="thirdValue"> Third value </param>
        /// <param name="fourthValue"> Fourth value </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCDStein(int firstValue, int secondValue, int thirdValue, int fourthValue) 
            => FindGCD(firstValue, secondValue, thirdValue, fourthValue, FindGCDEuclidean);

        /// <summary>
        /// Finds greatest common divisor for n values.
        /// </summary>
        /// <param name="values"> Values for getting gcd </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCDStein(params int[] values) 
            => FindGCD(FindGCDStein, values);
        #endregion
        #endregion

        #region Private methods

        #region Common logic
        private static (int Value, int Time) FindGCD(int firstValue, int secondValue, int thirdValue, Func<int, int, (int Value, int Time)> callback)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = callback(firstValue, secondValue).Value;

            return (callback(gcd, thirdValue).Value, watch.Elapsed.Milliseconds);
        }

        private static (int Value, int Time) FindGCD(int firstValue, int secondValue, int thirdValue, int fourthValue, Func<int, int, (int Value, int Time)> callback)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = callback(firstValue, secondValue).Value;

            gcd = callback(gcd, thirdValue).Value;

            return (callback(gcd, fourthValue).Value, watch.Elapsed.Milliseconds);
        }

        private static (int Value, int Time) FindGCD(Func<int, int, (int Value, int Time)> callback, params int[] values)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = 0;

            foreach (var value in values)
            {
                gcd = callback(gcd, value).Value;
            }

            watch.Stop();
            return (gcd, watch.Elapsed.Milliseconds);
        }
        #endregion

        #region Addition methods
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
        #endregion
    }
}
