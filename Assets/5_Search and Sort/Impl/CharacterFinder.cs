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
        [SerializeField]
        private CharacterSorter characterSorter;

        public Character[] BinarySearch(List<Character> arr, int searchedValue, string varName, int low, int high)
        {
            List<Character> list = new List<Character>();
            int mid;

            while (low <= high) // Use <= instead of just <
            {
                mid = (low + high) / 2;
                Character characterRefOne = arr[mid];
                PropertyInfo property = typeof(Character).GetProperty(varName);
                int temp = (int)property.GetValue(characterRefOne);

                if (temp == searchedValue)
                {
                    list.Add(arr[mid]); // Use list.Add() instead of List[index] = arr[mid]
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

            Character[] returnValue = list.ToArray(); // Convert the list to an array

            if (returnValue.Length == 0) // Check the length of the array
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
            
            characterSorter.SortCharactersByAge(characterSorter.characters);
            List<Character> ListToCheck = new List<Character>(); 
            foreach(Character c in characterSorter.characters) 
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
            Character[] character = characterSorter.characters; 
            characterSorter.SortCharactersByHeight(character);
            List<Character> ListToCheck = new List<Character>();
            foreach (Character c in character)
            {
                ListToCheck.Add(c);
            }
            return BinarySearch(ListToCheck, height, "Height", 0, character.Length - 1);
        }
    }
}