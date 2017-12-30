using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    /// <summary>
    /// PriorityQueue implementation with max-heap representation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class PriorityQueueMax<T>
    {
        T[] heap;
        double[] priorities;

        int count;
        int capacity;

        public PriorityQueueMax(int capacity = 10)
        {
            this.heap = new T[capacity];
            this.priorities = new double[capacity];
            this.count = 0;
            this.capacity = capacity;
        }

        public T[] Heap
        {
            get { return this.heap; }
        }

        public double[] Priorities
        {
            get { return this.priorities; }
        }

        public T pop()
        {
            T node = heap[0];
            swap(0, count - 1);
            count -= 1;
            heapify(0);

            return node;
        }

        public void add(T item, double priority)
        {
            if (count >= capacity)
                throw new Exception("Count exceeds the maximum capacity!");

            int position = count++;
            this.heap[position] = item;
            this.priorities[position] = priority;
            this.moveUp(position);
        }

        public void addArray(Tuple<T, double>[] items)
        {
            foreach (var pair in items)
            {
                // Item1 = Node, Item 2 = priority(double)
                this.add(pair.Item1, pair.Item2);
            }
        }

        private void swap(int index_a, int index_b)
        {
            T temp = heap[index_a];
            heap[index_a] = heap[index_b];
            heap[index_b] = temp;

            //also swap the priorities
            double prio = priorities[index_a];
            priorities[index_a] = priorities[index_b];
            priorities[index_b] = prio;
        }

        private int parent(int position)
        {
            return (int)((position - 1) / 2);
        }

        private int leftChild(int position)
        {
            return 2 * position + 1;
        }

        private int rightChild(int position)
        {
            return 2 * position + 2;
        }

        private void moveUp(int position)
        {
            while ((position > 0) && (priorities[parent(position)] < priorities[position]))
            {
                //Debug.WriteLine("entered while loop");
                int original_parent_pos = parent(position);
                swap(position, original_parent_pos);
                position = original_parent_pos;
            }
        }

        private void heapify(int i)
        {
            int right = this.rightChild(i);
            int left = this.leftChild(i);
            int max;

            if (left < count && priorities[left] > priorities[i])
                max = left;
            else
                max = i;

            if (right < count && priorities[right] > priorities[max])
                max = right;

            if (max != i)
            {

                this.swap(max, i);
                //this.swap(i, max);

                heapify(max);
            }

        }

        private void buildHeap()
        {
            for (int i = count / 2; i >= 0; i--)
            {
                this.heapify(i);
            }
        }

        public int Count
        {
            get { return this.count; }
        }

        public void heapSort()
        {
            buildHeap();
            for (int i = count - 1; i > 0; i--)
            {
                swap(0, i);
                this.heapify(i);
            }
        }



    }
}
