using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    /// <summary>
    /// Simple Node class.
    /// </summary>
    class Node : IComparable<Node>
    {
        int cost;

        public Node(int cost)
        {
            this.cost = cost;
        }
        public int CompareTo(Node other)
        {
            return Cost > other.Cost ? 1 : Cost == other.Cost ? 0 : -1;
        }

        public int Cost
        {
            get { return this.cost; }
        }

        public override string ToString()
        {
            return this.cost.ToString();

        }
    }
}
