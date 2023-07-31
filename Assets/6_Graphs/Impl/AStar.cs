using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
namespace Graphs
{
    /// <summary>
    /// Implement the A* algorithm for 2D nodes. Use the <see cref="NodeHelper"/> to get distances between nodes. Use <see cref="NodeHelper.EstimateDistance(Node, Node)"/> for estimated and real distances.
    /// Implement the algorithm in such a way that you can go through all its steps one at a time and visualize those steps (i.e. paths that are currently looked at) using <see cref="Gizmos"/> or <see cref="LineRenderer"/> or whatever visualization method you fancy.
    /// REMINDER: You may use an existing implementation of the A* algorithm and adjust it as necessary. Remember to link your references.
    /// Total points: 10
    ///
    /// https://docs.google.com/presentation/d/1r1-HsvNncRdZ2ZudhwOBAbhun1Pbl3rW/edit#slide=id.p34
    /// </summary>
    public class AStar : MonoBehaviour
    {
        private Action<Node[]> callback;
        private bool fastForward;
        private Node from;
        private bool isGenerating;
        private bool step;
        private Node to;
        public bool IsGenerating => isGenerating;


        /// <summary>
        /// Go through all the steps of the calculation.
        /// </summary>
        public void FastForward()
        {
            fastForward = true;
        }

        public void GeneratePath(Node from, Node to, Action<Node[]> callback)
        {
            this.from = from;
            this.to = to;
            this.callback = callback;
            isGenerating = true;
            step = false;
            fastForward = false;
            StartCoroutine(DoGeneratePath());
        }

        /// <summary>
        /// Go through one step of the calculation.
        /// </summary>
        public void Step()
        {
            step = true;
        }

        private Node GetLowestCost(List<Node> nodeList)
        {
            Node smallest = null;
            float min = float.MaxValue;
            foreach (Node node in nodeList)
            {
                if (NodeHelper.EstimateDistance(node, to) < min)
                {
                    min = NodeHelper.EstimateDistance(node, to);
                    smallest = node; 
                }
            }
            return smallest; 
        }
        /// <summary>
        /// Implement A* here.
        /// </summary>
        private IEnumerator DoGeneratePath()
        {
            Node current;
            List<Node> open = new List<Node>();
            List<Node> closed = new List<Node>();
            open.Add(from);

            while (open.Count > 0)
            {
                current = GetLowestCost(open);
                closed.Add(current);
                open.Remove(current);
                if (current == to)
                {
                    yield return new(); 
                }
            }
                //callback(path);
                //isGenerating = false;
                yield return new WaitForEndOfFrame(); 
        }
    }
}