using System.Collections.Generic;

namespace ComplexDataTypes
{
    public class LinkedNode
    {
        public string name;
        public LinkedNode successor;

        public LinkedNode(string name)
        {
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is LinkedNode node &&
                   name == node.name;
        }

        public override int GetHashCode()
        {
            return 363513814 + EqualityComparer<string>.Default.GetHashCode(name);
        }
    }
}