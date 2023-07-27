using UnityEngine;
using System;
using System.Collections;

namespace ComplexDataTypes
{
    /// <summary>
    /// Total points: 14
    /// </summary>
    public static class Arrays
    {
        /// <summary>
        /// Reinterpret the given byte array as a uint array. If the last entries do not fit into the new data type, ignore them.
        /// Points: 4
        /// </summary>
        public static uint[] AsUIntArray(byte[] array)
        {
            /* Internethilfen: 
             * https://stackoverflow.com/questions/33369320/c-sharp-signed-unsigned-cast-issues
             * https://learn.microsoft.com/de-de/dotnet/api/system.bitconverter?view=net-7.0
             * 
             */
            int uintSizeInBytes = sizeof(uint);
            int numUInts = array.Length / uintSizeInBytes;

            uint[] uintArray = new uint[numUInts];
            int iteration = 0;
            Debug.Log(uintSizeInBytes + " size: " + numUInts);
            while (iteration < numUInts)
            {
                int startIndex = iteration * uintSizeInBytes;
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(array, startIndex, uintSizeInBytes);
                }
                uintArray[iteration] = BitConverter.ToUInt32(array, startIndex);
                iteration++;
            }
            return uintArray;
        }


        /// <summary>
        /// Reinterpret the given byte array as a ushort array. If the last entries do not fit into the new data type, ignore them.
        /// Example 1: array = {1,2} (0001,0010) => res = {18} (00010010)
        /// Example 2: array = {1,2,5} (0001,0010,0101) => res = {18} (00010010)
        /// Points: 4
        /// </summary>
        public static ushort[] AsUShortArray(byte[] array)
        {
            int uintSizeInBytes = sizeof(ushort);
            int numUInts = array.Length / uintSizeInBytes;
            Debug.Log(uintSizeInBytes + " size: " + numUInts);
            ushort[] uushortArr = new ushort[numUInts];
            int iteration = 0;
            while (iteration < numUInts)
            {
                int startIndex = iteration * uintSizeInBytes;
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(array, startIndex, uintSizeInBytes);
                }
                uushortArr[iteration] = BitConverter.ToUInt16(array, startIndex);
                iteration++;
            }
            return uushortArr;
        }

        /// <summary>
        /// Return an array that contains the arrays a and b.
        /// Example: a = {w,x}, b = {y,z} => res = {w,x,y,z}
        /// Points: 4
        /// </summary>
        public static string[] Concat(string[] a, string[] b)
        {
            //hier hab ich nachgeschlagenw was nochmal war xD: https://www.geeksforgeeks.org/c-sharp-string-concat-with-examples-set-2/
            int i = 0;
            string[] concart = new string[a.Length + b.Length];
            foreach (string s in a)
            {
                concart[i] = s;
                i++;
            }

            foreach (string s in b)
            {
                concart[i] = s;
                i++;
            }
            return concart;
        }

        /// <summary>
        /// Implement a linear search that finds "element" in "array".
        /// Return the index of the element or -1 if the element is not present.
        /// Points: 2
        /// </summary>
        public static int FindElement(string[] array, string element)
        {

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    Debug.Log("the elemt " + element + " is in the array");
                    return i;
                }
            }
            Debug.Log("the elemt " + element + " is not in the array");
            return -1;
        }
    }
}