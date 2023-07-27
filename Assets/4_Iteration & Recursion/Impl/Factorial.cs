using UnityEngine; 
namespace Iteration_VS_Recursion
{
    /// <summary>
    /// Total points: 6
    /// </summary>
    public static class Factorial
    {
        /// <summary>
        /// Implement an iterative algorithm that calculates the factorial of x (x!).
        /// Points: 3
        /// </summary>
        public static uint FacIt(uint x)
        {
            uint reminder = 1;
            for (uint i = x; i > 0; i--)
            {
                reminder *= i;
            }
            return reminder;
        }

        /// <summary>
        /// Implement a recursive algorithm that calculates the factorial of x (x!).
        /// Points: 3
        /// </summary>
        public static uint FacRec(uint x)
        {

            if (x == 0)
            {
                return 1;
            }
            return x *= FacRec(x - 1);



        }
    }
}