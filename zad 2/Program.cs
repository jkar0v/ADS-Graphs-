namespace zad_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            int count = int.Parse(Console.ReadLine());

            while (count > 0)
            {
                string input = Console.ReadLine();
                int node = int.Parse(input.Split(':')[0]);
                List<int> edges = input.Split(": ")[1].Split(' ').Select(int.Parse).ToList();
                graph.Add(node, edges);
                count--;
            }
            foreach (var item in graph)
            {
                Console.Write("Node " + item.Key + " has neighbors: ");
                foreach (var edge in item.Value)
                {
                    if (item.Value.Count > 1)
                    {
                        Console.Write(edge + " ");
                    }
                    else
                    {
                        Console.Write(edge + " ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Starting point:");
            int start = int.Parse(Console.ReadLine());
            Console.WriteLine("End point:");
            int end = int.Parse(Console.ReadLine());
            BFS(graph, start, end);

            static void BFS(Dictionary<int, List<int>> graph, int start,int end)
            {
                var visited = new HashSet<int>();
                var queue = new Queue<(int node, int depth)>();
                visited.Add(start);
                queue.Enqueue((start, 0));

                while (queue.Count > 0)
                {
                    int depth = 0;
                    if (queue.Peek().node == end)
                    {
                        Console.WriteLine("Най-краткият път е: " + queue.Peek().depth + " стъпки");
                        break;
                    }
                    (var node, depth) = queue.Dequeue();
                    foreach (var neighbor in graph[node])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue((neighbor, depth + 1));
                        }
                    }
                }
            }
        }
    }
}
