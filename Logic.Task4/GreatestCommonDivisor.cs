using System;

namespace Logic.Task4
{
    public static class GreatestCommonDivisor
    {
        #region Public methods
        /// <summary>
        /// Finds greatest common divisor for three values.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="isEuclidean"> Set default algorithm </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCD(int firstValue, int secondValue, bool isEuclidean = true)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            if (isEuclidean)
            {
                return (FindGCDEuclidean(firstValue, secondValue), watch.Elapsed.Milliseconds);
            }
            else
            {
                return (FindGCDStein(firstValue, secondValue), watch.Elapsed.Milliseconds);
            }
        }

        /// <summary>
        /// Finds greatest common divisor for three values.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="thirdValue"> Third value </param>
        /// <param name="isEuclidean"> Set default algorithm </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCD(int firstValue, int secondValue, int thirdValue, bool isEuclidean = true)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd;

            if (isEuclidean)
            {
                gcd = FindGCDEuclidean(firstValue, secondValue);

                return (FindGCDEuclidean(gcd, thirdValue), watch.Elapsed.Milliseconds);
            }
            else
            {
                gcd = FindGCDStein(firstValue, secondValue);

                return (FindGCDStein(gcd, thirdValue), watch.Elapsed.Milliseconds);
            }
        }

        /// <summary>
        /// Finds greatest common divisor for four values.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="thirdValue"> Third value </param>
        /// <param name="fourthValue"> Fourth value </param>
        /// <param name="isEuclidean"> Set default algorithm </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCD(int firstValue, int secondValue, int thirdValue, int fourthValue, bool isEuclidean = true)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = FindGCD(firstValue, secondValue, thirdValue, isEuclidean).Value;

            if (isEuclidean)
            {
                return (FindGCDEuclidean(gcd, fourthValue), watch.Elapsed.Milliseconds);
            }
            else
            {
                return (FindGCDStein(gcd, fourthValue), watch.Elapsed.Milliseconds);
            }
        }

        /// <summary>
        /// Finds greatest common divisor for n values.
        /// </summary>
        /// <param name="values"> Params </param>
        /// <param name="isEuclidean"> Set default algorithm </param>
        /// <returns> Greatest common divisor and time of work </returns>
        public static (int Value, int Time) FindGCD(bool isEuclidean = true, params int[] values)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int gcd = 0;

            if (isEuclidean)
            {
                foreach (var value in values)
                {
                    gcd = FindGCDEuclidean(gcd, value);
                }
            }
            else
            {
                foreach (var value in values)
                {
                    gcd = FindGCDStein(gcd, value);
                }
            }

            watch.Stop();

            return (gcd, watch.Elapsed.Milliseconds);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Finds greatest common divisor for two values by Euclidean's algorithm.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <returns> Greatest common divisor </returns>
        private static int FindGCDEuclidean(int firstValue, int secondValue)
        {
            int temp;

            while (firstValue != 0)
            {
                temp = firstValue;
                firstValue = secondValue % firstValue;
                secondValue = temp;
            }

            return Math.Abs(secondValue);
        }

        /// <summary>
        /// Finds greatest common divisor for two values by Stein's algorithm.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <returns> Greatest common divisor </returns>
        private static int FindGCDStein(int firstValue, int secondValue)
        {
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

            return firstValue << shift;
        }

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
