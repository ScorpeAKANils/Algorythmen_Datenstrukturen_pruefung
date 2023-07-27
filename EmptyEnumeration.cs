using System;
using UnityEngine;
namespace ComplexDataTypes
{
    class EmptyEnumeration
    {
        int[] unsortedArray = new int[7] { 1, 9, 0, 4, 3, 10, 7 };
        int low = 0;
        int high;
        int x = 0;
        int mid;
        int sum;
        int i = 0;
        int index = int.MaxValue;
        // Start is called before the first frame update
        void Start()
        {
            high = unsortedArray.Length - 1;
            /* while (low <= high)
             {
                 //early out if x is not included 
                 if (sortedArray[0] > x || sortedArray[sortedArray.Length - 1] < x)
                 {
                     Debug.Log("X not found in the list!");
                     break;
                 }
                 i++;
                 Debug.Log("iteration: " + i);
                 mid = (low + high) / 2;
                 if (sortedArray[mid] == x)
                 {
                     Debug.Log(mid);
                     break;
                 }
                 else if (sortedArray[mid] < x)
                 {
                     low = mid + 1;
                 }
                 else if (sortedArray[mid] > x)
                 {
                     high = mid - 1;
                 }

             }*/
            BubbleSort(unsortedArray, unsortedArray.Length - 1);

        }
        int RecusiveBinearySearch(int[] array, int high, int low)
        {

            if (unsortedArray[0] > x || unsortedArray[unsortedArray.Length - 1] < x)
            {
                Debug.Log("X not found in the list!");
                return 0;
            }
            if (low > high)
            {
                return 0;
            }
            i++;
            Debug.Log("iteration: " + i);
            mid = (low + high) / 2;
            if (unsortedArray[mid] == x)
            {
                Debug.Log("der gesuchte index ist: " + mid);
                return mid;
            }
            else if (unsortedArray[mid] < x)
            {
                low = mid + 1;
                RecusiveBinearySearch(array, high, low);
            }
            else if (unsortedArray[mid] > x)
            {
                high = mid - 1;
                RecusiveBinearySearch(array, high, low);
            }

            return 0;
        }
        int Ackermann(int m, int n)
        {
            if (m == 0)
            {
                Debug.Log(n += 1); return n += 1;

            }
            else if (m > 0 && n == 0)
            {
                Debug.Log(Ackermann(m - 1, 1)); return Ackermann(m - 1, 1);
            }
            else if (m > 0 && n > 0)
            {
                Debug.Log(Ackermann(m - 1, Ackermann(m, n - 1))); return Ackermann(m - 1, Ackermann(m, n - 1));
            }
            Debug.Log(1);
            return 1;
        }
        void RecursiveFakultät(int x)
        {
            Debug.Log("Hallo");


            if (sum == 0)
            {
                sum = x;
            }
            else
            {
                sum *= x;
            }
            if (x > 1)
            {
                RecursiveFakultät(--x);
            }
        }

        void IterativeFakulität()
        {

            for (int y = 100; y > 0; y--)
            {
                if (sum == 0)
                {
                    sum = y;
                }
                else
                {
                    sum *= y;
                }
            }
            Debug.Log(sum);
        }


        int BubbleSort(int[] unsortedArray, int maxIndex)
        {
            int x;
            while (maxIndex > 0)
            {
                for (int i = 0; i < maxIndex; i++)
                {
                    x = i + 1;
                    if (unsortedArray[i] > unsortedArray[x])
                    {
                        swap(ref unsortedArray[i], ref unsortedArray[x]);
                    }
                }
                maxIndex -= 1;
            }

            if (maxIndex <= 0)
            {
                foreach (int value in unsortedArray)
                {
                    Debug.Log(value);
                }
                int randomSearchedIndex = Random.Range(0, unsortedArray.Length - 1);
                x = unsortedArray[randomSearchedIndex];
                Debug.Log("searched value: " + x);
                RecusiveBinearySearch(unsortedArray, unsortedArray.Length - 1, 0);
            }


            return 0;
        }

        void swap(ref int swap1, ref int swap2)
        {
            int refSwap1 = swap1;
            int refSwap2 = swap2;
            swap1 = refSwap2;
            swap2 = refSwap1;

        }

    }
}

