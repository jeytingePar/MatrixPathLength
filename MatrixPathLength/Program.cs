using System;

namespace MatrixPathLength
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] sample = new int[,]
            {                
                { 9,9,4 },
                { 7,7,8 },
                { 2,1,1 },
            };
            FindMaxPath max = new FindMaxPath();

            for (int x = 0; x < sample.GetLength(0); x++)
            {
                for (int y = 0; y < sample.GetLength(1); y++)
                {
                    Console.Write(sample[x, y] + "\t");
                }
                Console.WriteLine();
            }
            Console.Out.WriteLine("Best path is " + max.FindMaxPathLength(sample));
            Console.ReadKey();
        }
    }
}
