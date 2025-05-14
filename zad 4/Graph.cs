using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad_4
{
    internal class Graph
    {
        public Dictionary<string, List<(string neighbor, int distance)>> AdjacencyList = new();

        public void AddEdge(string from, string to, int distance)
        {
            if (!AdjacencyList.ContainsKey(from))
                AdjacencyList[from] = new List<(string, int)>();
            if (!AdjacencyList.ContainsKey(to))
                AdjacencyList[to] = new List<(string, int)>();

            AdjacencyList[from].Add((to, distance));
            AdjacencyList[to].Add((from, distance));
        }

        public int Dijkstra(string start, string end)
        {
            var distances = new Dictionary<string, int>();
            var priorityQueue = new PriorityQueue<string, int>();
            var visited = new HashSet<string>();

            foreach (var city in AdjacencyList.Keys)
                distances[city] = int.MaxValue;

            distances[start] = 0;
            priorityQueue.Enqueue(start, 0);

            while (priorityQueue.Count > 0)
            {
                var current = priorityQueue.Dequeue();

                if (visited.Contains(current))
                    continue;

                visited.Add(current);

                foreach (var (neighbor, weight) in AdjacencyList[current])
                {
                    int newDist = distances[current] + weight;
                    if (newDist < distances[neighbor])
                    {
                        distances[neighbor] = newDist;
                        priorityQueue.Enqueue(neighbor, newDist);
                    }
                }
            }

            return distances.ContainsKey(end) ? distances[end] : -1;
        }
    }
}
