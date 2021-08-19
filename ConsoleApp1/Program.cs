using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Coordinator
    {
        public int X;
        public int Y;
        public bool IsVisited = false;
        public Coordinator() { }
        public Coordinator(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<Coordinator>> map = new Dictionary<int, List<Coordinator>>();

            // Entries
            List<int> row1 = new List<int>() { 34, 21, 32, 41, 25 };
            List<int> row2 = new List<int>() { 14, 42, 43, 14, 31 };
            List<int> row3 = new List<int>() { 54, 45, 52, 42, 23 };
            List<int> row4 = new List<int>() { 33, 15, 51, 31, 35 };
            List<int> row5 = new List<int>() { 21, 52, 33, 13, 23 };

            List<int> entries = new List<int>();
            entries.AddRange(row1);
            entries.AddRange(row2);
            entries.AddRange(row3);
            entries.AddRange(row4);
            entries.AddRange(row5);

            // Initialize
            for (int i = 0; i < 5; i++)
            {
                List<Coordinator> coordinators = new List<Coordinator>();
                for (int j = 0; j < 5; j++)
                {
                    int unitDigit = entries.ElementAt(j) % 10;
                    int tenDigit = (entries.ElementAt(j) - unitDigit) / 10;
                    Coordinator newCooordinator = new Coordinator(tenDigit, unitDigit);
                    coordinators.Add(newCooordinator);

                }
                entries.RemoveRange(0, 5);
                map.Add(i, coordinators);
            }
            Console.WriteLine("{0} {1}", 1, 1);
            Coordinator coordinator = new Coordinator(map.Values.ElementAt(0)[0].X, map.Values.ElementAt(0)[0].Y); // [1] [1]

            // Search for Treasure

            List<Coordinator> queue;
            while (!coordinator.IsVisited)
            {
                Console.WriteLine("{0} {1}", coordinator.X, coordinator.Y);
                coordinator.IsVisited = true;
                map.TryGetValue(coordinator.X - 1, out queue);
                coordinator = queue.ElementAt(coordinator.Y - 1);
            }

            if (!coordinator.IsVisited)
            {
                Console.WriteLine("Could not find anythings");
                return;
            }

            Console.WriteLine("Found treasure at {0} {1}", coordinator.X, coordinator.Y);
        }
    }
}
