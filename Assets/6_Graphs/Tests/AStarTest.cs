using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Graphs.Tests
{
    public class AStarTest
    {
        private Node[] path;

        [UnityTest]
        public IEnumerator AStar_Test()
        {
            AStar astar = GameObject.FindObjectOfType<AStar>();
            Node n = GameObject.Find("N").GetComponent<Node>();
            Node c = GameObject.Find("C").GetComponent<Node>();
            astar.GeneratePath(n, c, Callback);
            astar.FastForward();
            int i = 0;
            while (astar.IsGenerating)
            {
                yield return null;
                i++;
                if (i > 100000)
                {
                    Assert.Fail("This took too long.");
                }
            }
            Assert.AreEqual("N", path[0].name);
            Assert.AreEqual("A", path[1].name);
            Assert.AreEqual("C", path[2].name);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SceneManager.LoadScene("1_pathfinding", LoadSceneMode.Single);
        }

        private void Callback(Node[] path)
        {
            this.path = path;
        }
    }
}