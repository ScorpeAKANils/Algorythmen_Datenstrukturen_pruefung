using UnityEngine;

namespace Search_Sort
{
    public class CharacterGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject characterPrefab;

        [SerializeField]
        private uint count;

        private void Awake()
        {
            for (uint i = 0; i < count; i++)
            {
                GameObject go = GameObject.Instantiate(characterPrefab);
                Character c = go.GetComponentInChildren<Character>();
                c.Randomize();
            }
        }
    }
}