using System;
using UnityEngine;
namespace Iteration_VS_Recursion
{
    /// <summary>
    /// Total points: 5
    /// </summary>
    public static class ConvertToIteration
    {
        static int stepps = 0;
        static int i = 0;
        private const int MaxSteps = int.MaxValue;
        /// <summary>
        /// Implement MyAlgorithmRec as an iterative function.
        /// Points: 5
        /// </summary>
        public static int MyAlgorithmIt(int x)
        {
            /*
             wie die Recursive Funktion funktioniert:
             1.
            guckt ob x kleiner gleich 1
                  wenn ja: returne 1, kein erneuter aufruf -> ende
             wenn nicht, dann:
                       wird überprüft ob x % 2 == 0
                            wenn ja, multipliziere 2 mit  funktion mit x = x/2
                                      guckt ob x kleiner gleich 1
                                               wenn ja: returne 1, kein erneuter aufruf -> ende
                                                        wenn nicht, dann:
                                                             wird überprüft ob x % 2 == 0
                                                                     wenn ja, multipliziere 2 mit  funktion mit x = x/2
                                                                                        wenn nicht:
                                                                                             dann rechne
                                                                                                  3* Function(x*3+1)
                                                                                                     -etc
                    dann rechne
                        3* Function(x*3+1)
                       erneuter aufruf etc. 

            Ich bin mir actaully sehr unsicher, ob man das hier iterativ lösen kann und dabei auf die ergebnisse kommen kann, die hier erwartet werden, da hier ja die abbruch bedingung ist, dass x nicht mehr größer als eins ist(in einem While Loop, for loops würden hier, so denke ich, keinen Sinn machen, da x ja nicht hoch/runter gezählt werden soll und die anzahl an iterationen ja schlecht vorgegeben werden können.) und ich das hier iterativ nicht sehe. Vllt ist das hier so ein Ackermann ding, auch wenn ich gehört habe, dass dieser mal Iterative gelöst wurde, ich such mal den Link raus, war ne recht interessante Lösung
            **Nach dem stepps zählen auch keine nice Lösung war, noch mal von vorne: 
            *
            *
            *Da immer x = 1 raus kommt, möglicher weiße muss ich den multiplikator, also das war vor dem x * function(x*x oder x/x) Multiplikator miteinander multiplizieren und den zurüclkgeben 
            ...oder es ging halt nicht um x xD 
             
             */
            int reminder = 1;

            do
            {
                if (x <= 1)
                {
                    return 1;
                }
                if (x % 2 == 0)
                {
                    x = x / 2;
                    reminder *= 2;
                }
                else
                {
                    reminder *= 3;
                    x = x * 3 + 1;

                }
            } while (x > 1);
            return reminder;
        }

        public static int MyAlgorithmRec(int x)
        {
            if (x <= 1)
            {
                return 1;
            }
            if (x % 2 == 0)
            {

                return 2 * MyAlgorithmRec(x / 2);
            }
            else
            {
                return 3 * MyAlgorithmRec(x * 3 + 1);
            }
        }

        /*
         wenn: x kleiner gleich 1, gebe 1 zurück.
        ansonnsten, wenn der rest von x und 2 0 ist, dann:
         2 * (x / 2);, ansonnsten:
        3 * MyAlgorithmRec(x * 3 + 1);

        Abbruchbedingung: x ist kleiner oder gleich eins 


         bei x = 7
        3 * 7 * 3 +1

         
         */
    }
}