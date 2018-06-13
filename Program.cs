using System;
using System.Collections.Generic;
 
namespace Dijkstra
{
    class Program
    {
        private static void Main()
        {
 
            const int n = 5;
            var adjacencyMatrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    adjacencyMatrix[i, j] = -1;
                }
            }
            adjacencyMatrix[0, 1] = 10;
            adjacencyMatrix[0, 3] = 30;
            adjacencyMatrix[0, 4] = 100;
            adjacencyMatrix[1, 2] = 50;
            adjacencyMatrix[2, 0] = 70;
            adjacencyMatrix[2, 4] = 10;
            adjacencyMatrix[3, 2] = 20;
            adjacencyMatrix[4, 3] = 60;
 
            var costs = new int[n];
            for (int i = 1; i < costs.Length; i++)
            {
                costs[i] = int.MaxValue;
            }
 
            for (int i = 0; i < n; i++)
            {
                var list = new List<int>();
                for (int j = i; j < n; j++)
                {
                    if (adjacencyMatrix[i, j] != -1)
                        list.Add(j);
                }
                list.Sort((x, y) => adjacencyMatrix[i, x].CompareTo(adjacencyMatrix[i, y])); //Сортируем по мин. стоимости пути
                foreach (var j in list)
                {
                    var newcost = costs[i] + adjacencyMatrix[i, j];
                    if (newcost < costs[j])
                        costs[j] = newcost;
                }
            }
            for (int i = 0; i < costs.Length; i++)
            {
                Console.WriteLine("Пункт {0}, стоимость пути = {1}", i, costs[i]);
            }
            Console.ReadKey();
        }
    }
}
