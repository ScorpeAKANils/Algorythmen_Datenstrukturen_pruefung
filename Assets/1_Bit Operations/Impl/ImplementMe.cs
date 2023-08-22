namespace BitOperations
{
    /// <summary>
    /// Usage of other namespaces is not allowed for this class, except for <see cref="System.Math"/>.
    /// Total points: 10
    /// </summary>
    public static class ImplementMe
    {

        public static uint PowerOfX(int exponent)
        {
            uint result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= 2;
            }
            return result;
        }
        /// <summary>
        /// Interpret both integers as bits and combine them with an AND operation!
        /// Points: 2
        /// </summary>
        ///
        public static int BitwiseAnd(int a, int b)
        {
            return a & b;
        }

        /// <summary>
        /// Convert the given string of bits into an integer.
        /// Points: 2
        /// </summary>
        public static uint ConvertToDecimal(string bits)
        {
            int power = 0;
            uint dezVal = 0;
            for (int i = bits.Length - 1; i >= 0; i--)
            {
                char bit = bits[i];
                int bitVal = bit - '0';
                dezVal += (uint)bitVal * PowerOfX(power);
                power++;
            }
            return dezVal;
        }

        /// <summary>
        /// Divide "value" by 2 (rounded down) using ONLY shift operators!
        /// Points: 2
        /// </summary>
        public static int DivideBy2(int value)
        {
            int retVal = value >> 1;
            return retVal;
        }

        /// <summary>
        /// Multiply "value" by 2 using ONLY shift operators!
        /// Points: 2
        /// </summary>
        public static int MultiplyBy2(int value)
        {
            int retVal = value << 1;
            return retVal;
        }

        /// <summary>
        /// Multiply "value" by 8 using ONLY shift operators!
        /// Points: 2
        /// </summary>
        public static int MultiplyBy8(int value)
        {
            int retVal = value << 3;
            return retVal;
        }
    }
}