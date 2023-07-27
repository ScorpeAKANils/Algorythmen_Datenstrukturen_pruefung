using System;
using System.Collections;
using UnityEngine;

namespace Graphs
{
    /// <summary>
    /// Implement the A* algorithm for 2D nodes. Use the <see cref="NodeHelper"/> to get distances between nodes. Use <see cref="NodeHelper.EstimateDistance(Node, Node)"/> for estimated and real distances.
    /// Implement the algorithm in such a way that you can go through all its steps one at a time and visualize those steps (i.e. paths that are currently looked at) using <see cref="Gizmos"/> or <see cref="LineRenderer"/> or whatever visualization method you fancy.
    /// REMINDER: You may use an existing implementation of the A* algorithm and adjust it as necessary. Remember to link your references.
    /// Total points: 10
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

        /// <summary>
        /// Implement A* here.
        /// </summary>
        private IEnumerator DoGeneratePath()
        {
            throw new System.NotImplementedException();
            //callback(path);
            //isGenerating = false;
        }
    }
}