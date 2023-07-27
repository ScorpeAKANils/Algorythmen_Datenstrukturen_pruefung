using UnityEngine;

namespace Search_Sort
{
    [ExecuteAlways]
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private int age;

        [SerializeField]
        private string firstName;

        [SerializeField]
        private int height;

        [SerializeField]
        private string lastName;

        [SerializeField]
        private Sex sex;

        [SerializeField]
        private int soloTitanKills;

        [SerializeField]
        private int weight;

        public int Age { get => age; }
        public string FirstName { get => firstName; }
        public int Height { get => height; }
        public string LastName { get => lastName; }
        public Sex Sex { get => sex; }
        public int SoloTitanKills { get => soloTitanKills; }
        public int Weight { get => weight; }

        public void Randomize()
        {
            age = Random.Range(15, 60);
            height = Random.Range(150, 200);
            sex = (Sex)Random.Range(0, 2);
            soloTitanKills = Random.Range(0, 100);
            weight = Random.Range(50, 100);
            firstName = System.Guid.NewGuid().ToString();
            lastName = System.Guid.NewGuid().ToString();
            SetSize();
        }

        private void OnEnable()
        {
            SetSize();
        }

        private void SetSize()
        {
            transform.localScale = new Vector3(weight / 60f, height / 100f, 1);
            Vector3 pos = transform.localPosition;
            pos.y = transform.localScale.y;
            transform.localPosition = pos;
        }
    }
}