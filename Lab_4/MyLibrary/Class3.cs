using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace librori_4_1
{
    public class Class3
    {
        public void SolvePuzzle()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string inputFilePath = "input.txt";
            string outputFilePath = "output.txt";

            char[,] startState = new char[2, 4];
            char[,] targetState = new char[2, 4];

            try
            {
                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    Console.WriteLine("Запис зроблений з " + inputFilePath);
                    for (int i = 0; i < 2; i++)
                    {
                        string line = sr.ReadLine();
                        for (int j = 0; j < 4; j++)
                            startState[i, j] = line[j];
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        string line = sr.ReadLine();
                        for (int j = 0; j < 4; j++)
                            targetState[i, j] = line[j];
                    }
                }

                int result = MinimumMoves(startState, targetState);

                Console.WriteLine("Мінімальна кількість перестановок: " + result);

                using (StreamWriter sw = new StreamWriter(outputFilePath))
                {
                    sw.WriteLine("Мінімальна кількість перестановок: " + result);
                }
                Console.WriteLine("Результат збережено до " + outputFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Неправильне значення ПОМИЛКА: " + e.Message);
            }
        }

        private int MinimumMoves(char[,] startState, char[,] targetState)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(StateToString(startState));
            distances[StateToString(startState)] = 0;

            while (queue.Count > 0)
            {
                string currentState = queue.Dequeue();

                if (currentState == StateToString(targetState))
                    return distances[currentState];

                int emptyIndex = currentState.IndexOf('#');

                int[] dx = { -1, 1, 0, 0 };
                int[] dy = { 0, 0, -1, 1 };

                for (int i = 0; i < 4; i++)
                {
                    int newRow = emptyIndex / 4 + dx[i];
                    int newCol = emptyIndex % 4 + dy[i];

                    if (IsValidMove(newRow, newCol))
                    {
                        string nextState = SwapCharacters(currentState, emptyIndex, newRow * 4 + newCol);
                        if (!distances.ContainsKey(nextState))
                        {
                            distances[nextState] = distances[currentState] + 1;
                            queue.Enqueue(nextState);
                        }
                    }
                }
            }

            return -1;
        }

        private bool IsValidMove(int row, int col)
        {
            return row >= 0 && row < 2 && col >= 0 && col < 4;
        }

        private string StateToString(char[,] state)
        {
            string result = "";
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result += state[i, j];
                }
            }
            return result;
        }

        private string SwapCharacters(string str, int index1, int index2)
        {
            char[] characters = str.ToCharArray();
            char temp = characters[index1];
            characters[index1] = characters[index2];
            characters[index2] = temp;
            return new string(characters);
        }
    }
}
