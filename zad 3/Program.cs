namespace zad_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            int count = int.Parse(Console.ReadLine());

            while (count > 0)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] parts = input.Split(':', 2);
                    int node = int.Parse(parts[0].Trim());
                    List<int> edges = new List<int>();

                    if (parts.Length > 1 && !string.IsNullOrWhiteSpace(parts[1]))
                    {
                        edges = parts[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse).ToList();
                    }

                    graph[node] = edges;
                }
                catch { }
                count--;
            }
            foreach (var item in graph)
            {
                Console.Write("Node " + item.Key + " has neighbors: ");
                foreach (var edge in item.Value)
                {
                    Console.Write(edge + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Starting point:");
            int start = int.Parse(Console.ReadLine());
            Console.WriteLine("End point:");
            int end = int.Parse(Console.ReadLine());
            BFS(graph, start, end);

            static void BFS(Dictionary<int, List<int>> graph, int start, int end)
            {
                var visited = new HashSet<int>();
                var queue = new Queue<(int node, int depth)>();
                visited.Add(start);
                queue.Enqueue((start, 0));

                while (queue.Count > 0)
                {
                    (var node, int depth) = queue.Dequeue();

                    if (node == end)
                    {
                        Console.WriteLine($"Съществува път от {start} до {end} на дълбочина {depth}");
                        return;
                    }

                    foreach (var neighbor in graph.GetValueOrDefault(node, new List<int>()))
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue((neighbor, depth + 1));
                        }
                    }
                }

                Console.WriteLine($"Няма път от {start} до {end}");
            }
        }
    }
}
