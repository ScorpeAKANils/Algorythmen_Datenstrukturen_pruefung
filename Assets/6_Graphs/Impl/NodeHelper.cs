using UnityEngine;

namespace Graphs
{
    public static class NodeHelper
    {
        public static float EstimateDistance(Node a, Node b)
        {
            return Vector2.Distance(a.transform.position, b.transform.position);
        }
    }
}