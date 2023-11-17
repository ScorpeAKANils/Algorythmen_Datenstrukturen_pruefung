using UnityEngine; 
namespace ComplexDataTypes
{
    /// <summary>
    /// Implement a Linked List. Assume every node is unique. You don't have to implement safety checks.
    /// Total points: 15
    /// </summary>
    public class LinkedList
    {

        public LinkedNode next;
        public int size;
        /*
         Theoretischer Ansatz:
        1. was ich brauche:
        Damit eine LinkedList Dynamisch ist, müssen die Elemente jeweils eine Pointer Refenrece auf das nächste Element haben, da erstens LinkedList nicht alle Daten beieinander speichern, sondern einfach da, wo gerade platz ist.
        Dadurch können LinkedList Dynamisch Wachsen, da anders als bei normalen Listen, keine Daten nebeneinander gespeichert werden und die Liste deswegen nicht im Speicher "umziehen" muss, sondern einfach ein neues Element erstellt und dann
        die Addresse von diesem Element speichert.

        Damit das alles funktioniert muss ich darauf achten, dass
        - Das ich das erste Element richtig festlege, sowie einen Pointer einrichte, welcher auf das nächste, bzw., letzte Element zeigt und anfangs null ist.

         Die größe der Liste sollte getracked werden um z.B. bei der Index Of Methode eine Lineare Search einzubauen, welche einmal durch die Liste iteriert und dabei die Objekte mit dem Object zu vergleichen um dann den Index auszugeben

        variablen die ich brauche 
        int size
        LinkedNode* nachbar
        */
        private LinkedNode root;
        public LinkedList(LinkedNode root)
        {
            this.root = root;
            this.next = null;
        }

        /// <summary>
        /// Points: 3
        /// </summary>
        public void AddToEnd(LinkedNode node)
        {
            LinkedNode reminder = root; 
            while (reminder.successor != null)
            {
                reminder = reminder.successor; 
            }
            reminder.successor = node; 
       

        }

        /// <summary>
        /// Points: 3
        /// </summary>
        public void AddToFront(LinkedNode node)
        {
            LinkedNode oldRoot = root;
            root = node;
            root.successor = oldRoot; 
        }

        /// <summary>
        /// Points: 3
        /// </summary>
        public int IndexOf(LinkedNode node)
        {
            int index = 0;
            LinkedNode reminder = root;
            while (true)
            {
                if (reminder.Equals(node))
                {
                    return index;
                }
                if (reminder.successor == null)
                {
                    break; 
                }
                reminder = reminder.successor;
                index++; 
            }
            throw new System.NullReferenceException("Node does not exist");
        }

        /// <summary>
        /// Points: 3
        /// </summary>
        public void InsertAfterX(LinkedNode x, LinkedNode node)
        {
            int iterationCounter = 0; 
            LinkedNode reminder = root;
            while (true)
            {
                if (reminder.Equals(x))
                {/*
                    1. speichere den pointer auf die aktuelle successor node
                    2. verweise die neue node als successor auf die aktuelle reminder node
                    3. neue node bekommt gespeicherte node als successor zugewiesem und wurde somit erfolgreich gespeichert.
                 */
                    var remindSuccessor = reminder.successor;
                    reminder.successor = node;
                    node.successor = remindSuccessor;
                    return;
                }
                else if (reminder.successor ==null)
                {
                    throw new System.NullReferenceException("Element x is not in the List");
                }
                else
                {
                    reminder = reminder.successor;
                }

                iterationCounter++; 
            }

        }

        /// <summary>
        /// Points: 3
        /// </summary>
        public void Remove(LinkedNode node)
        {
            LinkedNode reminder = root;
            while (true)
            {
                if (reminder.successor.Equals(node))
                {
                    reminder.successor = reminder.successor.successor;
                    break; 
                }
            }
        }
    }
}