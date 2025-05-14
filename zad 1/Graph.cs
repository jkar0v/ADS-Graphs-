using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad_1
{
    internal class Graph
    {
        private List<int>[] adjacencyList;

        public Graph(int numberOfVertices)
        {
            adjacencyList = new List<int>[numberOfVertices];

            for (int i = 0; i < numberOfVertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int vertex1, int vertex2)
        {
            adjacencyList[vertex1].Add(vertex2);
            adjacencyList[vertex2].Add(vertex1); // За неориентиран граф
        }

        public void RemoveEdge(int vertex1, int vertex2)
        {
            adjacencyList[vertex1].Remove(vertex2);
            adjacencyList[vertex2].Remove(vertex1); // За неориентиран граф
        }

        public void PrintGraph()
        {
            for (int i = 0; i < adjacencyList.Length; i++)
            {
                Console.Write($"Връх {i}: ");

                foreach (int neighbor in adjacencyList[i])
                {
                    Console.Write($"{neighbor} ");
                }

                Console.WriteLine();
            }
        }
    }
}
