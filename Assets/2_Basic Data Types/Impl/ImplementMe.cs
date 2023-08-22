
namespace BasicDataTypes
{
    /// <summary>
    /// Usage of other namespaces is not allowed for this class, except for <see cref="System.Math"/>.
    /// Total points: 9
    /// </summary>
    public static class ImplementMe
    {
        /// <summary>
        /// This function takes 2 bytes and combines their bits into a ushort.
        /// Example with 2 bits each (this is not the actual size of a byte!):
        /// left = 01
        /// right = 10
        /// Result: 0110
        /// Points: 2
        /// </summary>
        public static ushort Combine(byte left, byte right)
        {

            ushort output = (ushort)left;
            output = (ushort)(output << 8);
            output += right;
            return output;
        }

        /// <summary>
        /// This function takes 2 uint and combines their bits into a ulong.
        /// Points: 2
        /// </summary>
        public static ulong Combine(uint left, uint right)
        {
            ulong output = left;
            output = output << 32;
            output += right;
            return output;
        }

        /// <summary>
        /// Implement a function that compares 2 doubles for equality.
        /// Points: 2
        /// </summary>
        /// <returns>True if both doubles are equal.</returns>
        public static bool Compare(double a, double b, int testNum)
        {
            //unschön, wird eventuell ausgetauscht wenn ich einen besseren weg um die Rundungsfehler finde. Falls du das hier ließt, naja, kannst dir ja dann denken wie erfolgreich die suche war lol
            float toleranz = 0.00000001f;

            return (a - b) >= (0 - toleranz) && (a - b) <= toleranz; 
        }
        /// <summary>
        /// Count all the 1s in the BITS of "value".xw
        /// Example: 13 -> 1101 -> 3
        /// Points: 3
        /// </summary>
        public static int CountOnes(uint value)
        {
            int counter = 0;
            if (value == 0)
            {
                return 0;
            }
            string bits = string.Empty;

            while (value > 0)
            {
                uint remind = value % 2;
                bits = remind.ToString() + bits;
                value /= 2;
            }
            foreach (char bit in bits)
            {
                if (bit == '1')
                {
                    counter += 1;
                }
            }
            return counter;
        }
    }
}