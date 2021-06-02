using System;

namespace GraphCS131
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> airports = new Graph<string>();
            airports.AddVertex("LAX");
            airports.AddVertex("PHX");
            airports.AddVertex("DFW");
            airports.AddVertex("DEN");
            airports.AddVertex("DTW");
            airports.AddVertex("SNA");
            airports.AddEdge("LAX", "DEN", 3);
            airports.AddEdge("LAX", "PHX", 7);
            airports.AddEdge("LAX", "DTW", 15);
            airports.AddEdge("LAX", "SNA", 2);
            airports.AddEdge("DTW", "PHX", 5);
            airports.AddEdge("DEN", "LAX", 2);
            airports.AddEdge("SNA", "LAX", 1);
            airports.AddEdge("SNA", "PHX", 3);
            airports.AddEdge("SNA", "DFW", 5);
            airports.AddEdge("DFW", "SNA", 5);
            airports.AddEdge("DFW", "PHX", 5);
            airports.AddEdge("DFW", "DTW", 10);
            airports.AddEdge("PHX", "DFW", 6);
            airports.AddEdge("PHX", "DTW", 3);
            airports.AddEdge("PHX", "LAX", 4);

            Console.WriteLine("The airports are: LAX, DTW, DEN, SNA, PHX, DFW");
            Console.WriteLine("Enter the start airport: ");
            string start = Console.ReadLine();

            while(airports.Search(start) == null)
            {
                Console.WriteLine("Entered airport not found.  Please try again.");
                start = Console.ReadLine();
            }

            Console.WriteLine("Enter the destination airport: ");
            string end = Console.ReadLine();

            while (airports.Search(start) == null)
            {
                Console.WriteLine("Entered airport not found.  Please try again.");
                end = Console.ReadLine();
            }

            var paths = airports.FindAllPaths(start.ToUpper(), end.ToUpper());
            Console.WriteLine("All possible paths shown below:");
            int i = 1;
            if (paths == null)
            {
                Console.WriteLine("No path found");
            }
            else
            {
                foreach (var path in paths)
                {
                    Console.WriteLine($"Path {i}: ");
                    foreach (var vertex in path)
                    {
                        Console.Write($"{vertex.Value} ");
                    }
                    Console.WriteLine();
                    i++;
                }
            }

        }
    }
}
