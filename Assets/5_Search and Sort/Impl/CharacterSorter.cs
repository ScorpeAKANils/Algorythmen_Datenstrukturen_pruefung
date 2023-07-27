using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.TextCore.Text;


namespace Search_Sort
{

    /*
     internet resourcen:
    //um schreib arbeit zu sparen(dachte ich xDDDD)
    https://learn.microsoft.com/en-us/dotnet/standard/generics/

     
     
     */
    /// <summary>
    /// Implement all sorting methods using your own quick sort or merge sort implementation!
    /// Total points: 18
    /// </summary>


    public class CharacterSorter : MonoBehaviour
    {
        public Character[] characters;

        public IReadOnlyList<Character> Characters => characters;
        //https://docs.google.com/presentation/d/1r1-HsvNncRdZ2ZudhwOBAbhun1Pbl3rW/edit#slide=id.p45
        /// <summary>
        /// Points: 2
        /// </summary>
        public void SortCharactersByAge()
        {

            
            bool isSorted = false;
            characters = FindObjectsOfType<Character>();
            if (characters.Length <= 1)
            {
                return;
            }
            MergeSort(characters, 0, characters.Length - 1, "Age", isInt: true);
            foreach (Character p in characters)
            {
                Debug.Log(p.Age);
            }
            Debug.Log("Fertig sortiert");
            UpdateCharacterPositions();
        }

        public void SortCharactersByAge(Character[] characters)
        {
            bool isSorted = false;
            characters = FindObjectsOfType<Character>();
            if (characters.Length <= 1)
            {
                return;
            }
            MergeSort(characters, 0, characters.Length - 1, "Age", isInt: true);
            foreach (Character p in characters)
            {
                Debug.Log(p.Age);
            }
            Debug.Log("Fertig sortiert");
            UpdateCharacterPositions();
        }
        public static void MergeSort(Character[] arr, int left, int right, string fieldName, bool isInt = false, bool isString = false, bool isSex = false, bool isReversed = false) 
        {
            if (left < right)
            {
                int m = left + (right - left) / 2;

                MergeSort(arr, left, m, fieldName, isInt, isString, isReversed);
                MergeSort(arr, m + 1, right, fieldName, isInt, isString, isReversed);

                Merge(arr, left, m, right, fieldName,isInt, isString, isReversed);
            }
        }

        public static void Merge(Character[] arr, int left, int middle, int right, string fieldName, bool isInt = false, bool isString = false, bool isReversed=false)
        {
            int leftArrLength = middle - left + 1;
            int rightArrLength = right - middle;

            Character[] leftArr = new Character[leftArrLength];
            Character[] rightArr = new Character[rightArrLength];

            int i, j;

            for (i = 0; i < leftArrLength; i++)
            {
                leftArr[i] = arr[left + i];
            }

            for (j = 0; j < rightArrLength; j++)
            {
                rightArr[j] = arr[middle + 1 + j];
            }

            i = 0;
            j = 0;
            int k = left;

            while (i < leftArrLength && j < rightArrLength)
            {
                //der Kommentar hier drunter ist nicht für die Prüfung relevant, er eine witzige erinnerung falls ich mal das Projekt random nach der Prüfung öffnen sollte
                /*bisschen doof mit den Booleans, aber ich hätte den Algorythmus sonnst 3x schreiben müssen, fänd ich nicht so cool. Zu dem wollte ich den Type T schon immer mal ausprobieren, 
                 * dass Arbeiten damit ist tatsächlich auch recht nervig, weil warum muss ich ne function haben, die den Wert returned nur um ihn zu vergleichen. Also klar, T könnte auch ein Script sein, dann wären <= vergleiche z.B
                 * schon recht unsinnig, aber was solls 
                 * Ich sehe deswegen und wegen den Bools, dass es irgendwo eine Badpractice ist. 
                 * (das habe ich anfangs nicht bedacht, dass ich die variable samt einsatzfall ja trotzdem irgendwo vorgeben müsste, und ich merke gerade, während ich das schreibe, dass ich dann auch einfach nur diese Checks verwendet haben könnte, und dann ganz normal mit den Variablen zuarbeiten, würde mir sogar Methodstack aufrufe sparen, aber dafür habe ich jetzt zulange nach einer Lösung für die fehlenden Vergleichsoperatoren gesucht, um hier abzubrechen. Das geht einfach nicht mehr). Das ist schon ziemlich bescheiden, weil naja, hab mich anfangs mit der Idee eigentlich recht schlau gefühlt und jetzt zweifel ich dran. Naja, aber immerhin wird sonnst keiner das so lösen und ich kann mich wie ein Special Unicorn oder so fühlen lol 
                 * 
                 * Ich stelle gerade fest, ich bin hochmotiviert viel dafür zu arbeiten, wege zu finden, um weniger zu Arbeiten. Den jetzt werfe ich nicht nur mehr den Generic Type T in den Ring, sondern auch noch Reflections. Auf die Idee bin ich duch diesen Stackoverflow beitrag gekommen: https://stackoverflow.com/questions/5053521/getting-variable-by-name-in-c-sharp
                 *und hier noch ein YouTube tutorial welches ich mir dazu angeschaut habe: https://www.youtube.com/watch?v=UdstAE72JRE 
                 *
                 *Den durch das Suchen der bestimmten Variable und dessen speicherung in eineer Lokalen variable, könnte ich die if abfragen auf die gängisten Daten Typen reduzieren(also anstelle von age, kills, vorname, nachname einfach int, string) und häte dafür eine Funktion, welche mit allen (gängigen) Datentypen kompatible wäre. Es ist zwar teuer, aber ziemlich faszinierend und definitv einen Versuch wert. Ich meine, es ist eine nützliche Theorie dahinter, welche es m.M.n (hoffentlich) wert ist, dass ich jetzt den 3. Abend damit verbringe eine Generische Merge Sort Funktion hinzukriegen. Aber ich mein, abseits von den Run Time tests bin ich fertig mit der Prüfung, also kann man mal machen hab ja noch n Monat lol. 
                 */
                if (isInt)
                {
                    if (!isReversed)
                    {
                        Character characterRefOne = leftArr[i];
                        Character characterRefTwo = rightArr[j];
                        PropertyInfo property = typeof(Character).GetProperty(fieldName);
                        var temp1 = (int)property.GetValue(characterRefOne);
                        var temp2 = (int)property.GetValue(characterRefTwo);
                        if (temp1 <= temp2)
                        {
                            arr[k++] = leftArr[i++];
                        }
                        else
                        {
                            arr[k++] = rightArr[j++];
                        }
                    }
                    else
                    {
                        Character characterRefOne = leftArr[i];
                        Character characterRefTwo = rightArr[j];
                        PropertyInfo property = typeof(Character).GetProperty(fieldName);
                        int temp1 = (int)property.GetValue(characterRefOne);
                        int temp2 = (int)property.GetValue(characterRefTwo);
                        if (temp1 > temp2)
                        {
                            arr[k++] = leftArr[i++];
                        }
                        else
                        {
                            arr[k++] = rightArr[j++];
                        }
                    }
                }
                else if (isString)
                {
                    Character characterRefOne = leftArr[i];
                    Character characterRefTwo = rightArr[j];
                    PropertyInfo property = typeof(Character).GetProperty(fieldName);
                    string temp1 = (string)property.GetValue(characterRefOne);
                    string temp2 = (string)property.GetValue(characterRefTwo);
                    if (temp1[0] <= temp2[0])
                    {
                        arr[k++] = leftArr[i++];
                    }
                    else
                    {
                        arr[k++] = rightArr[j++];
                    }
                }
            }

            while (i < leftArrLength)
            {
                arr[k++] = leftArr[i++];
            }

            while (j < rightArrLength)
            {
                arr[k++] = rightArr[j++];
            }
        }

        /// <summary>
        /// Points: 2´
        /// </summary
        public void SortCharactersByFirstName()
        {
            MergeSort(characters, 0, characters.Length - 1, "FirstName", isString: true); 
            UpdateCharacterPositions();
        }

        /// <summary>
        /// Points: 2
        /// </summary>
        public void SortCharactersByHeight()
        {
            MergeSort(characters, 0, characters.Length - 1, "Height", isInt: true); 
            UpdateCharacterPositions();
        }

        /// <summary>
        /// Points: 4
        /// </summary>
        public void SortCharactersByHeightThenByReversedAge()
        {
            bool heightSorted = false;

            MergeSort(characters, 0, characters.Length - 1, "Height", isInt: true);
            heightSorted = true;
            if (heightSorted)
            {
                MergeSort(characters, characters.Length - 1, 0,  "Age", isInt: true, isReversed: true);
            }
            UpdateCharacterPositions();
            
            foreach (Character i in characters)
            {
                Debug.Log(i.Age); 
            }
        }

        /// <summary>
        /// Points: 2
        /// </summary>
        public void SortCharactersByKills()
        {
            MergeSort(characters, 0, characters.Length - 1, "SoloTitanKills", isInt: true); 
            UpdateCharacterPositions();
        }

        /// <summary>
        /// Points: 2
        /// </summary>
        public void SortCharactersByLastName()
        {
            MergeSort(characters, 0, characters.Length - 1, "LastName", isString: true);
            UpdateCharacterPositions();
        }

        /// <summary>
        /// Points: 2
        /// </summary>
        public void SortCharactersBySex()
        {
            MergeSort(characters, 0, characters.Length - 1, "Sex", isInt: true);
            UpdateCharacterPositions();
        }

        /// <summary>
        /// Points: 2
        /// </summary>
        public void SortCharactersByWeight()
        {
            MergeSort(characters, 0, characters.Length - 1, "Weight", isInt: true); 

            UpdateCharacterPositions();
        }

        private void SetCharacterAtPosition(Character character, int position)
        {
            Transform parent = character.transform.parent;
            parent.position = new Vector3((position % 12) * 2, 0, (position / 12) * 2);
        }

        private void Start()
        {
            characters = GameObject.FindObjectsOfType<Character>();
        }

        private void UpdateCharacterPositions()
        {
            for (int i = 0; i < characters.Length; i++)
            {
                SetCharacterAtPosition(characters[i], i);

            }
        }
    }
}