using UnityEngine;

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

        public Character[] BinarySearch(Character[] arr, int searchedValue, int low, int high)
        {
            int index = 0;
            Character[] returnVal = null;
            int mid; 
            while (low < high)
            {
                mid = (low + high) / 2;
                if (arr[mid].Age == searchedValue)
                {
                    returnVal[index] = arr[mid];
                    Debug.Log("found x");
                    index++;
                }
                else
                {
                    if (arr[mid].Age < searchedValue)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }
            if (returnVal == null)
            {
                Debug.LogError("x is not in the array!"); 
            }

                return returnVal; 
        }
  

        /// <summary>
        /// Points: 2
        /// </summary>
        public Character[] FindCharactersWithAge(int age)
        {
            Character[] character = GameObject.FindObjectsOfType<Character>();  
            characterSorter.SortCharactersByAge(character);
            return BinarySearch(character, age, 0, character.Length - 1); 
        }

        private void Start()
        {
            var lol = FindObjectsOfType<Character>();
            int random = Random.Range(0, lol.Length - 1); 
            var x = FindCharactersWithAge(lol[random].Age);
            foreach (Character c in x)
            {
                Debug.Log(c.Age + " eigentlich funktioniere ich!"); 
            }
        }
        /// <summary>
        /// Points: 2
        /// </summary>
        public Character[] FindCharactersWithHeight(int height)
        {
            throw new System.NotImplementedException();
        }
    }
}