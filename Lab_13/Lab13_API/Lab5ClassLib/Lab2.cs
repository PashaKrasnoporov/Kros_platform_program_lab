using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using WebApp.Models;

namespace Lab5ClassLib
{
    public static class Lab2
    {
        public static string Run(string inputValues)
        {
            try
           private static void Swap(ref char a, ref char b)
               {
                   char temp = a;
                   a = b;
                   b = temp;
               }

               private static void GeneratePermutations(char[] chars, int start, int end, HashSet<string> permutations)
               {
                   if (start == end)
                   {
                       permutations.Add(new string(chars));
                       return;
                   }

                   for (int i = start; i <= end; i++)
                   {
                       Swap(ref chars[start], ref chars[i]);
                       GeneratePermutations(chars, start + 1, end, permutations);
                       Swap(ref chars[start], ref chars[i]);
                   }
               }

               public static HashSet<string> GeneratePermutations(string input)
               {
                   char[] chars = input.ToCharArray();
                   HashSet<string> permutations = new HashSet<string>();
                   GeneratePermutations(chars, 0, chars.Length - 1, permutations);
                   return permutations;
               }

               public static void WritePermutationsToFile(HashSet<string> permutations, string filePath)
               {
                   using (StreamWriter writer = new StreamWriter(filePath))
                   {
                       foreach (string permutation in permutations)
                       {
                           writer.WriteLine(permutation);
                       }
                   }
               }
           }

           class Class1
           {
               static void Main(string[] args)
               {

                   //Function function1 = new Function();
                   Console.OutputEncoding = Encoding.UTF8;
                   Console.InputEncoding = Encoding.UTF8;

                   string inputString = string.Empty;

                   while (true)
                   {
                       Console.WriteLine("Виберіть джерело даних:");
                       Console.WriteLine("1. Ввести рядок із консолі");
                       Console.WriteLine("2. Використати дані із файлу INPUT.TXT");
                       Console.Write("Введіть цифру для вибору: ");
                       string choice = Console.ReadLine();

                       if (choice == "1")
                       {
                           Console.WriteLine("Введіть рядок:");
                           inputString = Console.ReadLine().Trim();
                           break;
                       }
                       else if (choice == "2")
                       {
                           try
                           {
                               inputString = File.ReadAllText("INPUT.TXT").Trim();
                               break;
                           }
                           catch (FileNotFoundException)
                           {
                               Console.ForegroundColor = ConsoleColor.Red;
                               Console.WriteLine("Файл INPUT.TXT не знайдений.");
                               Console.ResetColor();
                           }
                       }
                       else
                       {
                           Console.ForegroundColor = ConsoleColor.Red;
                           Console.WriteLine("Невірний вибір. Будь ласка, виберіть правильну опцію.");
                           Console.ResetColor();
                       }
                   }

                   HashSet<string> permutations = PermutationsGenerator.GeneratePermutations(inputString);
                   PermutationsGenerator.WritePermutationsToFile(permutations, "OUTPUT.TXT");
                   //model1

                   Console.ForegroundColor = ConsoleColor.Green;
                   Console.WriteLine("Перестановки були записані в файл OUTPUT.TXT.");
                   Console.ResetColor();

                   Console.ForegroundColor = ConsoleColor.Green;
                   Console.WriteLine("Перестановки із файлу OUTPUT.TXT:");
                   string[] lines = File.ReadAllLines("OUTPUT.TXT");
                   foreach (string line in lines)
                   {
                       Console.WriteLine(line);
                   }
                   Console.ResetColor();
        }
    }
}
