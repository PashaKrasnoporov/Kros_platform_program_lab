using LabsLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        LabsClasses.Lab3 _labClass = new LabsClasses.Lab3();
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

            int result = _labClass.MinimumMoves(startState, targetState);

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
}
