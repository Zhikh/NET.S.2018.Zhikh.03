using System;

namespace Logic.Task2
{
    /// <summary>
    /// This class provides extensions for double.
    /// </summary>
    public static class AdditionalMathPack
    {
        #region Constants
        private const double DefaultValue = 0;
        private const double ZeroRoot = 1;
        #endregion

        #region Public methods (extensions for double)
        /// <summary>
        /// This method finds n-root with getting precision.
        /// </summary>
        /// <param name="rootDegree"> Degree </param>
        /// <param name="eps"> Precision </param>
        /// <returns> N-root of value </returns>
        /// <exception cref="ArgumentException"> If rootDegree is less than zero </exception>
        /// <exception cref="ArgumentException"> If eps is less than zero </exception>
        /// <exception cref="ArgumentException"> If value is less than zero and rootDegree is odd number </exception>
        public static double FindNthRoot(this double value, int rootDegree, double eps)
        {
            if (rootDegree < 0)
            {
                throw new ArgumentException("Argument degree can't be less than 0!");
            }

            if ((eps > 0) || (eps < 1))
            {
                throw new ArgumentException("Argument eps can't be less than 0!");
            }

            if ((value < 0) && (rootDegree % 2 == 0))
            {
                throw new ArgumentException("It is impossible to extract odd degree root of a negative number!");
            }

            if ((value == DefaultValue) || (value == 1))
            {
                return value;
            }

            if (rootDegree == 0)
            {
                return ZeroRoot;
            }

            if (rootDegree == 1)
            {
                return value;
            }

            return FindNewtonZeros(value, rootDegree, eps);
        }
        #endregion

        #region Private methods
        // This method calculates Newton's expression for finding root.
        private static double CalcNewtonExpression(double value, int rootDegree, double previousValue)
        {
            double result = (rootDegree - 1) * previousValue;

            result += value / Math.Pow(previousValue, rootDegree - 1);
            result /= rootDegree;

            return result;
        }
        
        // This method finds root using Newton's method.
        private static double FindNewtonZeros(double value, int rootDegree, double eps)
        {
            double comparingValue = value / rootDegree;
            double result = CalcNewtonExpression(value, rootDegree, comparingValue);

            while (Math.Abs(result - comparingValue) > eps)
            {
                comparingValue = result;
                result = CalcNewtonExpression(value, rootDegree, comparingValue);
            }
            
            return result;
        }
        #endregion
    }
}
