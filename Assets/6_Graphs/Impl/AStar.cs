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
    /// https://learn.unity.com/project/a-36369ng?uv=2021.3
    /// https://www.youtube.com/watch?v=-L-WgKMFuhE
    /// https://www.youtube.com/watch?v=mZfyt03LDH4
    /// </summary>
    public class AStar : MonoBehaviour
    {
        private Action<Node[]> callback;
        private bool fastForward;
        public Node from;
        private bool isGenerating;
        private bool step;
        public Node to;
        public bool startGenerating; 
        public bool IsGenerating => isGenerating;
        public LineRenderer pathLineRenderer;


        private void Update()
        {
            if (startGenerating)
            {
                if (from != null && to != null)
                {
                    GeneratePath(from, to, callback); 
                }
            }
        }
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
                    smallest.cost = min; 
                }
            }
            return smallest; 
        }
        /// <summary>
        /// Implement A* here.
        /// </summary>
        private IEnumerator DoGeneratePath()
        {
            List<Node> path = new List<Node>();
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
                    if (current == to)
                    {
                        path.Add(current);
                        Node prev = current.predecessor;
                        while (prev != null)
                        {
                            path.Insert(0, prev);
                            prev = prev.predecessor;
                        }

                        Vector3[] pathPositions = new Vector3[path.Count];
                        for (int i = 0; i < path.Count; i++)
                        {
                            pathPositions[i] = path[i].gameObject.transform.position;
                        }

                        pathLineRenderer.positionCount = path.Count;
                        pathLineRenderer.SetPositions(pathPositions);

                        callback(path.ToArray());
                        isGenerating = false;
                        yield break;
                    }
                }

                foreach (Node node in current.Neighbours)
                {
                    float newCost = current.cost + NodeHelper.EstimateDistance(current, node);

                    if (open.Contains(node) && node.cost <= newCost)
                    {
                        continue;
                    }

                    if (closed.Contains(node) && node.cost <= newCost)
                    {
                        continue;
                    }

                    if (!open.Contains(node) && !closed.Contains(node))
                    {
                        open.Add(node);
                    }

                    node.cost = newCost;
                    node.predecessor = current;
                }

                if (step)
                {
                    step = false;
                    yield return new WaitForEndOfFrame();
                }
                else if (fastForward)
                {
                    yield return new WaitForEndOfFrame();
                }
                else
                {
                    yield return null;
                }
            }

            Debug.LogErrorFormat("Kein Pfad gefunden");
            callback(null);
            isGenerating = false;
        }


    }
}