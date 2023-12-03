using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4Classes
{
    public static class Lab3
    {
        static int[] dr = { -1, 0, 1, 0 };
        static int[] dc = { 0, 1, 0, -1 };
        static char[] keys = { 'R', 'G', 'B', 'Y' };
        static int[] keyCosts;

        public static void RunLab(string inputFile, string outputFile)
        {
            using (StreamReader sr = new StreamReader(inputFile))
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                try
                {
                    var dimensions = ReadArray<int>(sr, 2);
                    int R = dimensions[0];
                    int C = dimensions[1];

                    keyCosts = ReadArray<int>(sr, keys.Length);

                    char[][] maze = new char[R][];
                    for (int i = 0; i < R; i++)
                    {
                        maze[i] = sr.ReadLine()?.ToCharArray() ?? throw new InvalidDataException("Incorrect input data in the maze.");
                    }

                    int result = BFS(maze, R, C);
                    if (result == -1)
                    {
                        sw.WriteLine("Sleep");
                    }
                    else
                    {
                        sw.WriteLine(result);
                    }
                }

                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }
        }

        static T[] ReadArray<T>(StreamReader sr, int length)
        {
            var parts = sr.ReadLine()?.Split();
            if (parts == null || parts.Length != length)
            {
                throw new InvalidDataException("Incorrect input data format.");
            }

            var result = new T[length];
            for (int i = 0; i < length; i++)
            {
                if (!TryParse(parts[i], out result[i]))
                {
                    throw new InvalidDataException("Could not convert string to number.");
                }
            }

            return result;
        }

        static bool TryParse<T>(string s, out T result)
        {
            try
            {
                result = (T)Convert.ChangeType(s, typeof(T));
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        static int BFS(char[][] maze, int R, int C)
        {
            Queue<(int, int, int, int)> queue = new Queue<(int, int, int, int)>();
            bool[,,] visited = new bool[R, C, 16];
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (maze[i][j] == 'S')
                    {
                        queue.Enqueue((i, j, 0, 0));
                        visited[i, j, 0] = true;
                    }
                }
            }

            while (queue.Count > 0)
            {
                var (r, c, state, cost) = queue.Dequeue();
                if (maze[r][c] == 'E') return cost;

                for (int d = 0; d < 4; d++)
                {
                    int nr = r + dr[d];
                    int nc = c + dc[d];
                    int nstate = state;
                    int ncost = cost;

                    if (nr >= 0 && nr < R && nc >= 0 && nc < C && maze[nr][nc] != 'X' && !visited[nr, nc, state])
                    {
                        if (Array.IndexOf(keys, maze[nr][nc]) != -1)
                        {
                            int keyIndex = Array.IndexOf(keys, maze[nr][nc]);
                            if ((state & (1 << keyIndex)) == 0)
                            {
                                nstate |= (1 << keyIndex);
                                ncost += keyCosts[keyIndex];
                            }
                        }

                        visited[nr, nc, nstate] = true;
                        queue.Enqueue((nr, nc, nstate, ncost));
                    }
                }
            }

            return -1;
        }
    }
}
