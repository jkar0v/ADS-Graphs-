namespace zad_4
{
    internal class Program
    {
        static Graph graph = new();
        static PackageBST packageTree = new();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Меню ===");
                Console.WriteLine("1. Добави пратка");
                Console.WriteLine("2. Намери пратка по номер");
                Console.WriteLine("3. Покажи всички пратки");
                Console.WriteLine("4. Добави път между два града");
                Console.WriteLine("5. Изчисли най-кратък маршрут между два града");
                Console.WriteLine("6. Покажи пратки с дължина над ...");
                Console.WriteLine("7. Изход");
                Console.Write("Избор: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPackage();
                        break;
                    case "2":
                        FindPackage();
                        break;
                    case "3":
                        packageTree.InOrderTraversal();
                        break;
                    case "4":
                        AddRoad();
                        break;
                    case "5":
                        CalculateShortestPath();
                        break;
                    case "6":
                        FilterPackages();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Невалиден избор!");
                        break;
                }
            }
        }

        static void AddPackage()
        {
            Console.Write("Номер на пратка: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Начален град: ");
            string start = Console.ReadLine();
            Console.Write("Краен град: ");
            string end = Console.ReadLine();

            int distance = graph.Dijkstra(start, end);
            if (distance == -1)
            {
                Console.WriteLine("Няма път между тези два града!");
                return;
            }

            var package = new Package(id, start, end, distance);
            packageTree.Insert(package);
            Console.WriteLine("Пратката е добавена успешно!");
        }

        static void FindPackage()
        {
            Console.Write("Въведи номер на пратка: ");
            int id = int.Parse(Console.ReadLine());
            var package = packageTree.Search(id);
            if (package != null)
                Console.WriteLine(package);
            else
                Console.WriteLine("Пратка не е намерена.");
        }

        static void AddRoad()
        {
            Console.Write("Град 1: ");
            string city1 = Console.ReadLine();
            Console.Write("Град 2: ");
            string city2 = Console.ReadLine();
            Console.Write("Разстояние: ");
            int dist = int.Parse(Console.ReadLine());

            graph.AddEdge(city1, city2, dist);
            Console.WriteLine("Пътят е добавен успешно.");
        }

        static void CalculateShortestPath()
        {
            Console.Write("Начален град: ");
            string start = Console.ReadLine();
            Console.Write("Краен град: ");
            string end = Console.ReadLine();

            int distance = graph.Dijkstra(start, end);
            if (distance == -1)
                Console.WriteLine("Няма път между тези градове.");
            else
                Console.WriteLine("Най-краткият път е: " + distance + " км");
        }

        static void FilterPackages()
        {
            Console.Write("Въведи минимално разстояние: ");
            int min = int.Parse(Console.ReadLine());
            packageTree.FilterByDistance(min);
        }
    }
}
