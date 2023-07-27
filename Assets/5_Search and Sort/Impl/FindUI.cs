using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Search_Sort
{
    public class FindUI : MonoBehaviour
    {
        [SerializeField]
        private InputField ageField;

        [SerializeField]
        private CharacterFinder characterFinder;

        [SerializeField]
        private InputField heightField;

        [SerializeField]
        private GameObject mark;

        public void FindCharactersWithAge()
        {
            Character[] characters = characterFinder.FindCharactersWithAge(int.Parse(ageField.text));
            SetMarks(characters);
        }

        public void FindCharactersWithHeight()
        {
            Character[] characters = characterFinder.FindCharactersWithHeight(int.Parse(heightField.text));
            SetMarks(characters);
        }

        private static void DestroyAllMarks()
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Mark"))
            {
                GameObject.Destroy(go);
            }
        }

        private void SetMarks(IEnumerable<Character> characters)
        {
            DestroyAllMarks();
            foreach (Character character in characters)
            {
                GameObject m = GameObject.Instantiate(mark);
                m.transform.position = character.transform.parent.position + Vector3.up * 4;
            }
        }
    }
}