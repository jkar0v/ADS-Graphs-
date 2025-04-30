namespace zad_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many nodes do you want?");
            int node = int.Parse(Console.ReadLine());
            List<List<int>> adj = new List<List<int>>(node);
            for (int i = 0; i < node; i++)
            {
                adj.Add(new List<int>());
            }
            AddEdge(adj, 1, 2);
            AddEdge(adj, 0, 3);
            AddEdge(adj, 0, 3);
            AddEdge(adj, 1, 2, 4);
            Console.WriteLine("Adjacency List Representation:");
            DisplayAdjList(adj);


        }
        // Add an edge between two vertices
        // Method to add an edge between two vertices
        public static void AddEdge(List<List<int>> adj, int i, int j)
        {
            adj[i].Add(j);
            adj[j].Add(i); // Undirected
        }
        // Method to display the adjacency list
        public static void DisplayAdjList(List<List<int>> adj)
        {
            for (int i = 0; i < adj.Count; i++)
            {
                Console.Write($"{i}: "); // Print the vertex
                foreach (int j in adj[i])
                {
                    Console.Write($"{j} "); // Print its adjacent
                }
                Console.WriteLine();
            }
        }
        static void DFS(Dictionary<int, List<int>> graph, int start)
        {
            var visited = new HashSet<int>();
            var stack = new Stack<int>();
            stack.Push(start);
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                if (!visited.Contains(node))
                {
                    Console.WriteLine("Посетен връх: " + node);
                    visited.Add(node);
                    // Добавяме съседите в стека
                    foreach (var neighbor in graph[node])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            stack.Push(neighbor);
                        }
                    }
                }
            }
        }

    }
}
