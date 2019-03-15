using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class Program
    {
        /// <summary>
        /// Meghatározza egy adott számból (indexből), hogy hányadik szinten van
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int ComputeLevel(int n)
        {
            return (n < 0) ? -1 : Convert.ToInt32(Math.Floor(Math.Log(n + 1, 2)));
        }

        static void Hline(int len, char c = ' ')
        {
            for (int i = 0; i < len; i++)
                Console.Write(c);
        }

        static void printArray<T>(T[] t, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(t[i] + " ");
            }
        }
        static void printArrayAsBinaryTree(IShowAble[] t, int count, int start_y = 0)
        {
            int len = count;
            int totalLevels = ComputeLevel(len);
            int currentLevel = 1;

            for (int i = 0; i < len; i++)
            {
                currentLevel = ComputeLevel(i);
                //Console.SetCursorPosition(Console.CursorLeft, start_y + currentLevel);

                int Space_Left = Convert.ToInt32(Math.Pow(2, totalLevels - currentLevel));
                int Space_BTWSiblings = Convert.ToInt32(Math.Pow(2, totalLevels - currentLevel + 1)); //space beetween siblings

                //első elem ezen a szinten?
                if (currentLevel != ComputeLevel(i - 1))
                {
                    //ha új szint, akkor sortörés
                    Console.WriteLine();
                    Console.WriteLine();
                    Hline(Space_Left - 1);
                }

                // Console.Write(t[i].ToString());
                Console.Write(t[i].oneC());
                Hline(Space_BTWSiblings - 1);
            }
        }

        static void Main(string[] args)
        {

            PriorityQueueMin<Node<char>> PQmin = new PriorityQueueMin<Node<char>>(20);
            PriorityQueueMax<Node<char>> PQmax = new PriorityQueueMax<Node<char>>(20);


            PQmax.addArray(new Tuple<Node<char>, double>[10]
                 {
                        new Tuple<Node<char>, double>(new Node<char>('a'), 2),
                        new Tuple<Node<char>, double>(new Node<char>('b'), 1),
                        new Tuple<Node<char>, double>(new Node<char>('c'), 5),
                        new Tuple<Node<char>, double>(new Node<char>('d'), 3),
                        new Tuple<Node<char>, double>(new Node<char>('e'), 4),
                        new Tuple<Node<char>, double>(new Node<char>('f'), 9),
                        new Tuple<Node<char>, double>(new Node<char>('g'), 6),
                        new Tuple<Node<char>, double>(new Node<char>('h'), 10),
                        new Tuple<Node<char>, double>(new Node<char>('i'), 7),
                        new Tuple<Node<char>, double>(new Node<char>('j'), 8)
                }
            );




            do
            {
                Hline(25, '-');
                Console.WriteLine("count: " + PQmax.Count);
                printArray<double>(PQmax.Priorities, PQmax.Count);
                Console.WriteLine();
                printArrayAsBinaryTree(PQmax.Heap, PQmax.Count);
                Console.WriteLine("\n\npop item: {0}\n", PQmax.pop());
            }
            while (PQmax.Count > 0);




            //printArrayAsBinaryTree<double>(PQmax.Priorities, PQmax.Count);
            /*

            Console.WriteLine("\n\nAfter HeapSort: ");
            PQ.heapSort();

            PrintArrayAsBinaryTree<Node<char>>(PQ.Heap, PQ.Count);
            */

            Console.ReadLine();
        }

    }
}
