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
    class Node<T> : IComparable<Node<T>>, IShowAble
    {
        public T Value { get; set; }
        int cost;

        public Node(T val = default(T), int cost = 0 )
        {
            this.Value = val;
            this.cost = cost;
        }

        public int CompareTo(Node<T> other)
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

        public char oneC()
        {    
            return this.Value.GetType() == typeof(char) ? Convert.ToChar(this.Value) : '0';
        }
    }
}
