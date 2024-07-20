using System;
using System.Collections.Generic;
using System.IO;
using SimplexNoise;

namespace perimiter_floor_colouring
{
    class Program
    {
        static public int size = 256, input = 0;
        public const int shift = 2;
        static public Dictionary<int, string> Colours = new Dictionary<int, string>();
        static void Main()
        {
            Colours.Add((0 + shift) % 11, "Red");
            Colours.Add((1 + shift) % 11, "Orange");
            Colours.Add((2 + shift) % 11, "Yellow");
            Colours.Add((3 + shift) % 11, "Light Green");
            Colours.Add((4 + shift) % 11, "Green");
            Colours.Add((5 + shift) % 11, "Cyan");
            Colours.Add((6 + shift) % 11, "Light Blue");
            Colours.Add((7 + shift) % 11, "Blue");
            Colours.Add((8 + shift) % 11, "Purple");
            Colours.Add((9 + shift) % 11, "Magenta");
            Colours.Add((10 + shift) % 11, "Pink");
            while (true)
            {
                //create square with size in chunks
                Noise.Seed = new Random().Next(0, int.MaxValue);
                Console.WriteLine(Noise.Seed);
                float[,] grid = GenerateNewGrid();
                DrawGrid(grid);
                string str = CountInGrid(grid);
                Console.WriteLine(str);
                WriteToFile(grid, str);
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {

                }
                Console.WriteLine();
            }
        }
        static public float[,] GenerateNewGrid()
        {
            int x = size, z = size;
            float scale = 0.01f;
            float[,] grid = Noise.Calc2D(x, z, scale);
            float num = 0.043137254901960f;
            //convert to 0-8: 0.03529411764
            //convert to 0-3: 0.0156862745
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[j, i] = (float)Math.Truncate(grid[j, i] * num);
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
                    if (input == 0)
                    {
                        string str = Grid[x, z].ToString().PadLeft(2, '0');
                        switch (Grid[x, z])
                        {
                            case (0 + shift) % 11:
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write($"{str}");
                                break;
                            case (1 + shift) % 11:
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.Write($"{str}");

                                break;
                            case (2 + shift) % 11:
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write($"{str}");

                                break;
                            case (3 + shift) % 11:
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{str}");

                                break;
                            case (4 + shift) % 11:
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.Write($"{str}");

                                break;
                            case (5 + shift) % 11:
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                Console.Write($"{str}");

                                break;
                            case (6 + shift) % 11:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write($"{str}");

                                break;
                            case (7 + shift) % 11:
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.Write($"{str}");

                                break;
                            case (8 + shift) % 11:
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.Write($"{str}");
                                break;
                            case (9 + shift) % 11:
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write($"{str}");
                                break;
                            case (10 + shift) % 11:
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write($"{str}");
                                break;

                        }
                    }
                    else
                    {
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
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n");
            }
        }
        static public string CountInGrid(float[,] Grid)
        {
            int[] count = new int[11];
            for (int x = 0; x < size; x++)
            {
                for (int z = 0; z < size; z++)
                {
                    switch (Grid[x, z])
                    {
                        case 0:
                            count[0]++;
                            break;
                        case 1:
                            count[1]++;
                            break;
                        case 2:
                            count[2]++;
                            break;
                        case 3:
                            count[3]++;
                            break;
                        case 4:
                            count[4]++;
                            break;
                        case 5:
                            count[5]++;
                            break;
                        case 6:
                            count[6]++;
                            break;
                        case 7:
                            count[7]++;
                            break;
                        case 8:
                            count[8]++;
                            break;
                        case 9:
                            count[9]++;
                            break;
                        case 10:
                            count[10]++;
                            break;

                    }
                }
            }
            //LGreen DGreen Cyan LBlue DBlue Purple
            int total = 0;
            foreach (var item in count)
            {
                total += item;
            }
            return $"Red: {count[(0 + shift) % 11]}, Orange: {count[(1 + shift) % 11]}, Yellow: {count[(2 + shift) % 11]}, Lime: {count[(3 + shift) % 11]}, Green: {count[(4 + shift) % 11]}, Cyan: {count[(5 + shift) % 11]}, " +
                $"Light Blue: {count[(6 + shift) % 11]}, Blue: {count[(7 + shift) % 11]}, Purple: {count[(8 + shift) % 11]}, Magenta: {count[(9 + shift) % 11]}, Pink: {count[(10 + shift) % 11]}\n{total} blocks, {total / 64} stacks, {(total / 64) / 27} sb + {total % 27}";
        }
        static public void WriteToFile(float[,] Grid, String str)
        {
            float previous = Grid[0,0];
            int count = 0;
            using (var sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine($"Seed: {Noise.Seed}");
                sw.Write($"{str}\n");
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (Grid[i, j] != previous)
                        {
                            count++;
                            sw.Write($"{count} of {Colours[Convert.ToInt32(previous)]}, ");
                            previous = Grid[i, j];
                            count = 0;
                        }
                        else if (Grid[i, j] == previous)
                        {
                            count++;
                        }
                    }
                    sw.Write($"{count} of {Colours[Convert.ToInt32(previous)]}");
                    previous = Grid[i, 0];
                    count = 0;
                    sw.Write("\n");
                }
            }
        }
    }
}
