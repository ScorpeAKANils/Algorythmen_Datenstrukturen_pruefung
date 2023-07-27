using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Search_Sort.Tests
{
    public class CharacterSorterTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            SceneManager.LoadScene("1_character sorting", LoadSceneMode.Single);
        }

        [UnityTest]
        public IEnumerator SortCharactersByAge_Test()
        {
            CharacterSorter sorter = GameObject.FindObjectOfType<CharacterSorter>();
            sorter.SortCharactersByAge();
            for (int i = 0; i < sorter.Characters.Count - 1; i++)
            {
                Assert.IsTrue(sorter.Characters[i].Age <= sorter.Characters[i + 1].Age);
            }
            yield return new WaitForSeconds(1);
        }

        [UnityTest]
        public IEnumerator SortCharactersByFirstName_Test()
        {
            CharacterSorter sorter = GameObject.FindObjectOfType<CharacterSorter>();
            sorter.SortCharactersByFirstName();
            for (int i = 0; i < sorter.Characters.Count - 1; i++)
            {
                Assert.IsTrue(sorter.Characters[i].FirstName[0] <= sorter.Characters[i + 1].FirstName[0]);
            }
            yield return new WaitForSeconds(1);
        }

        [UnityTest]
        public IEnumerator SortCharactersByHeight_Test()
        {
            CharacterSorter sorter = GameObject.FindObjectOfType<CharacterSorter>();
            sorter.SortCharactersByHeight();
            for (int i = 0; i < sorter.Characters.Count - 1; i++)
            {
                Assert.IsTrue(sorter.Characters[i].Height <= sorter.Characters[i + 1].Height);
            }
            yield return new WaitForSeconds(1);
        }

        [UnityTest]
        public IEnumerator SortCharactersByHeightThenByReversedAge_Test()
        {
            CharacterSorter sorter = GameObject.FindObjectOfType<CharacterSorter>();
            sorter.SortCharactersByHeightThenByReversedAge();
            for (int i = 0; i < sorter.Characters.Count - 1; i++)
            {
                Assert.IsTrue(sorter.Characters[i].Height <= sorter.Characters[i + 1].Height);
                if (sorter.Characters[i].Height == sorter.Characters[i + 1].Height)
                {
                    Assert.IsTrue(sorter.Characters[i].Age >= sorter.Characters[i + 1].Age);
                }
            }
            yield return new WaitForSeconds(1);
        }

        [UnityTest]
        public IEnumerator SortCharactersByKills_Test()
        {
            CharacterSorter sorter = GameObject.FindObjectOfType<CharacterSorter>();
            sorter.SortCharactersByKills();
            for (int i = 0; i < sorter.Characters.Count - 1; i++)
            {
                Assert.IsTrue(sorter.Characters[i].SoloTitanKills <= sorter.Characters[i + 1].SoloTitanKills);
            }
            yield return new WaitForSeconds(1);
        }

        [UnityTest]
        public IEnumerator SortCharactersByLastName_Test()
        {
            CharacterSorter sorter = GameObject.FindObjectOfType<CharacterSorter>();
            sorter.SortCharactersByLastName();
            for (int i = 0; i < sorter.Characters.Count - 1; i++)
            {
                Assert.IsTrue(sorter.Characters[i].LastName[0] <= sorter.Characters[i + 1].LastName[0]);
            }
            yield return new WaitForSeconds(1);
        }

        [UnityTest]
        public IEnumerator SortCharactersBySex_Test()
        {
            CharacterSorter sorter = GameObject.FindObjectOfType<CharacterSorter>();
            sorter.SortCharactersBySex();
            for (int i = 0; i < sorter.Characters.Count - 1; i++)
            {
                Assert.IsTrue(sorter.Characters[i].Sex <= sorter.Characters[i + 1].Sex);
            }
            yield return new WaitForSeconds(1);
        }

        [UnityTest]
        public IEnumerator SortCharactersByWeight_Test()
        {
            CharacterSorter sorter = GameObject.FindObjectOfType<CharacterSorter>();
            sorter.SortCharactersByWeight();
            for (int i = 0; i < sorter.Characters.Count - 1; i++)
            {
                Assert.IsTrue(sorter.Characters[i].Weight <= sorter.Characters[i + 1].Weight);
            }
            yield return new WaitForSeconds(1);
        }
    }
}