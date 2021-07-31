using System;
using SimplexNoise;

namespace perimiter_floor_colouring
{
    class Program
    {
        static public int size = 256;
        static void Main()
        {
            while (true)
            {
                //create square with size in chunks
                Noise.Seed = new Random().Next(0,int.MaxValue);
                float[,] grid = GenerateNewGrid();
                DrawGrid(grid);
                Console.ReadKey();
                Console.WriteLine();
            }
        }
        static public float[,] GenerateNewGrid()
        {
            int x = size, z = size;
            float scale = 0.1f;
            float[,] grid = Noise.Calc2D(x, z, scale);

            //convert to 0-8: 0.03137254901
            //convert to 0-3: 0.0156862745
            for (int i = 0; i < size; i ++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = (float)Math.Truncate(grid[i, j] * 0.0156862745f);
                }
            }
            //return the grid
            return grid;
        }
        //colour order: Red Orange Yellow LGreen DGreen Cyan LBlue DBlue Purple
        //2 colouring methods, 0 - 8, or -4 to 4
        static public void DrawGrid(float[,] Grid)
        {
            for (int x = 0; x < size; x++)
            {
                for (int z = 0; z < size; z++)
                {
                    //switch (Grid[x, z])
                    //{
                    //    case 0:
                    //        Console.BackgroundColor = ConsoleColor.DarkRed;
                    //        Console.Write($"{Grid[x, z]}|");
                    //        break;
                    //    case 1:
                    //        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    //        Console.Write($"{Grid[x, z]}|");
                    //        break;
                    //    case 2:
                    //        Console.BackgroundColor = ConsoleColor.Yellow;
                    //        Console.Write($"{Grid[x, z]}|");
                    //        break;
                    //    case 3:
                    //        Console.BackgroundColor = ConsoleColor.Green;
                    //        Console.Write($"{Grid[x, z]}|");
                    //        break;
                    //    case 4:
                    //        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    //        Console.Write($"{Grid[x, z]}|");
                    //        break;
                    //    case 5:
                    //        Console.BackgroundColor = ConsoleColor.Cyan;
                    //        Console.Write($"{Grid[x, z]}|");
                    //        break;
                    //    case 6:
                    //        Console.BackgroundColor = ConsoleColor.Blue;
                    //        Console.Write($"{Grid[x, z]}|");
                    //        break;
                    //    case 7:
                    //        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    //        Console.Write($"{Grid[x, z]}|");
                    //        break;
                    //    case 8:
                    //        Console.BackgroundColor = ConsoleColor.Magenta;
                    //        Console.Write($"{Grid[x, z]}|");
                    //        break;
                    //}
                    switch (Grid[x, z])
                    {
                        case 0:
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write($"{Grid[x, z]}|");
                            break;
                        case 1:
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write($"{Grid[x, z]}|");
                            break;
                        case 2:
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($"{Grid[x, z]}|");
                            break;
                        case 3:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write($"{Grid[x, z]}|");
                            break;
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n");
            }
        }
    }
}
