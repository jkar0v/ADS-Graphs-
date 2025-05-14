namespace zad_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(5); // Създаване на граф с 5 върха (0 до 4)

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            Console.WriteLine("Графът след добавяне на ребра:");
            graph.PrintGraph();

            graph.RemoveEdge(1, 4);
            Console.WriteLine("\nГрафът след премахване на реброто между 1 и 4:");
            graph.PrintGraph();
        }
    }
}
