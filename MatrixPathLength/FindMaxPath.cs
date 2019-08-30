using System;
using System.Collections.Generic;
using System.Drawing;

namespace MatrixPathLength
{
    class FindMaxPath
    {
        Dictionary<Point, int> bestPaths;
        int highestValue = 0;
        int pointsSolved = 0;

        public int FindMaxPathLength(int[,] matrix)
        {
            bestPaths = new Dictionary<Point, int>();
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    bestPaths.Add(new Point(x, y), -1);
                }
            }

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    ComputeBestPath(x, y, matrix);
                }
                if (pointsSolved == matrix.GetLength(0) * matrix.GetLength(1))
                {
                    break;
                }
            }

            return highestValue;
        }

        private int ComputeBestPath(int x, int y, int[,] matrix)
        {
            Point thisPoint = new Point(x, y);
            if (bestPaths[thisPoint] > -1)
            {
                return bestPaths[thisPoint];
            }

            //check down
            int down = 0;
            if (x + 1 < matrix.GetLength(0) && matrix[x, y] < matrix[x + 1, y])
            {
                down = ComputeBestPath(x + 1, y, matrix);
            }
            //check up
            int up = 0;
            if (x - 1 >= 0 && matrix[x, y] < matrix[x - 1, y])
            {
                up = ComputeBestPath(x - 1, y, matrix);
            }
            //check right
            int right = 0;
            if (y + 1 < matrix.GetLength(1) && matrix[x, y] < matrix[x, y + 1])
            {
                right = ComputeBestPath(x, y + 1, matrix);
            }
            //check left
            int left = 0;
            if (y - 1 >= 0 && matrix[x, y] < matrix[x, y - 1])
            {
                left = ComputeBestPath(x, y - 1, matrix);
            }

            int bestPath = Math.Max(Math.Max(Math.Max(up, down), left), right) + 1;
            bestPaths[thisPoint] = bestPath;
            highestValue = bestPath > highestValue ? bestPath : highestValue;
            ++pointsSolved;
            return bestPath;
        }
    }
}
