using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Search_Sort.Tests
{
    public class CharacterFinderTest
    {
        [UnityTest]
        public IEnumerator FindCharactersWithAge_Test()
        {
            CharacterSorter sorter = GameObject.FindObjectOfType<CharacterSorter>();
            CharacterFinder finder = GameObject.FindObjectOfType<CharacterFinder>();
            var objects = GameObject.FindObjectsOfType<Character>();
            sorter.SortCharactersByAge();
            Character[] characters = finder.FindCharactersWithAge(20);
            foreach (Character character in characters)
            {
                Assert.AreEqual(20, character.Age);
            }
            yield return null;
        }

        [UnityTest]
        public IEnumerator FindCharactersWithHeight_Test()
        {
            CharacterSorter sorter = GameObject.FindObjectOfType<CharacterSorter>();
            CharacterFinder finder = GameObject.FindObjectOfType<CharacterFinder>();
            sorter.SortCharactersByHeight();
            Character[] characters = finder.FindCharactersWithHeight(165);
            foreach (Character character in characters)
            {
                Assert.AreEqual(165, character.Height);
            }
            yield return null;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SceneManager.LoadScene("2_character finding", LoadSceneMode.Single);
        }
    }
}