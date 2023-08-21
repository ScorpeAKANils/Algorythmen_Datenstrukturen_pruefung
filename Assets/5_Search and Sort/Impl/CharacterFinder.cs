using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine.TextCore.Text;

namespace Search_Sort
{
    /// <summary>
    /// Implement all methods using your own binary search implementation!
    /// Total points: 4
    /// </summary>
    public class CharacterFinder : MonoBehaviour
    {
        private Character[] GetCharackter()
        {
            
            List<Character> ListToCheck = new List<Character>();
            foreach (Character c in characterSorter.Characters)
            {
                ListToCheck.Add(c);
            }
            Character[] charachterToCheck = new Character[ListToCheck.Count];
            int iteretation = 0;
            foreach(Character c in ListToCheck)
            {
                charachterToCheck[iteretation] = c;
                iteretation++; 
            }
            return charachterToCheck; 
        }
        [SerializeField]
        private CharacterSorter characterSorter;

        public Character[] BinarySearch(List<Character> arr, int searchedValue, string varName, int low, int high)
        {
            List<Character> list = new List<Character>();
            int mid;

            while (low <= high) 
            {
                mid = (low + high) / 2;
                Character characterRefOne = arr[mid];
                PropertyInfo property = typeof(Character).GetProperty(varName);
                int temp = (int)property.GetValue(characterRefOne);

                if (temp == searchedValue)
                {
                    list.Add(arr[mid]);
                    arr.RemoveAt(mid); 
                    high--; 
                }
                else
                {
                    if (temp < searchedValue)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }

            Character[] returnValue = list.ToArray();

            if (returnValue.Length == 0) 
            {
                Debug.LogError("x is not in the array!");
            }

            return returnValue;
        }




        /// <summary>
        /// Points: 2
        /// </summary>
        public Character[] FindCharactersWithAge(int age)
        {
            var characters = GetCharackter(); 
            characterSorter.SortCharactersByAge(characters);
            List<Character> ListToCheck = new List<Character>();
            foreach(Character c in characters)
            {
                ListToCheck.Add(c); 
            }
            return BinarySearch(ListToCheck, age, "Age", 0, ListToCheck.Count- 1); 
        }

     //  private void Start()
     //  {
     //      var lol = FindObjectsOfType<Character>();
     //      int random = Random.Range(0, lol.Length - 1); 
     //      var x = FindCharactersWithAge(lol[random].Age);
     //      foreach (Character c in x)
     //      {
     //          Debug.Log(c.Age + " eigentlich funktioniere ich!"); 
     //      }
     //  }
        /// <summary>
        /// Points: 2
        /// </summary>
        public Character[] FindCharactersWithHeight(int height)
        {
            var characters = GetCharackter();
            characterSorter.SortCharactersByHeight(characters);
            List<Character> ListToCheck = new List<Character>();
            foreach (Character c in characters)
            {
                ListToCheck.Add(c);
            }
            return BinarySearch(ListToCheck, height, "Height", 0, ListToCheck.Count - 1);
        }
    }
}