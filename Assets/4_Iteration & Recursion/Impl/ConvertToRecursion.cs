using System.Collections.Generic;

namespace Iteration_VS_Recursion
{
    /// <summary>
    /// Total points: 5
    /// </summary>
    public static class ConvertToRecursion
    {
        public static List<int> MyAlgorithmIt(List<int> list)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    res.Add(list[i] * 3);
                }
                else
                {
                    if (i + 1 < list.Count)
                    {
                        res.Add(list[i] + list[i + 1]);
                    }
                    else
                    {
                        res.Add(list[i]);
                    }
                }
            }
            return res;
        }

        /*
         Der Algorythmus itereriert einmal durch die ganze Liste, d.H. die Abbruch bedingung muss sein, wenn x == anzahl an Items in der Liste, returne resultListe

        Was im Code passiert;

        wenn der Wert in der Liste an Index i gerade ist, dann soll der aktuelle das item anstelle I*3 der ResultListe hinzugefügt werden

        andernfalls soll, wenn der aktuelle Index +1 kleiner als die größe der Liste ist das Item anstelle von List[i] + List[i+1] der ResultListe hinzugefügt werden

        ansonnsten: füge das Item anstelle der aktuellen iteretion der ResultListe hinzu. 
         
         
         */


        public static List<int> MyAlgorithmRec(List<int> list)
        {
            List<int> res = new List<int>();
            MyAlgorithmRec(list, res, 0);
            return res;
        }

        /// <summary>
        /// Implement MyAlgorithmIt as a recursive method.
        /// Points: 5
        /// </summary>
        private static void MyAlgorithmRec(List<int> list, List<int> res, int index)
        {
            //throw new System.NotImplementedException();
            if (index < list.Count)
            {
                if (list[index] % 2 == 0)
                {
                    res.Add(list[index] * 3);
                    MyAlgorithmRec(list, res, index += 1);
                }
                else
                {
                    if (index + 1 < list.Count)
                    {
                        res.Add(list[index] + list[index + 1]);
                        MyAlgorithmRec(list, res, index += 1);
                    }
                    else
                    {
                        res.Add(list[index]);
                        MyAlgorithmRec(list, res, index += 1);
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}