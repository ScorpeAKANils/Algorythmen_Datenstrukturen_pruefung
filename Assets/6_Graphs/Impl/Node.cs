using System.Collections.Generic;
using UnityEngine;

namespace Graphs
{
    [ExecuteAlways]
    public class Node : MonoBehaviour
    {
        [SerializeField]
        private List<Node> neighbours;
        public List<Node> Neighbours => neighbours; 
        public float cost;
        public Node predecessor; 

        private void OnDrawGizmos()
        {
            Color oldColor = Gizmos.color;
            Gizmos.color = Color.green;
            foreach (Node node in neighbours)
            {
                if (node != null)
                {
                    Gizmos.DrawLine(transform.position, node.transform.position);
                }
            }
            Gizmos.color = oldColor;
        }

        private void OnValidate()
        {
            foreach (Node node in neighbours)
            {
                if (!node.neighbours.Contains(this))
                {
                    node.neighbours.Add(this);
                }
            }
        }
    }
}