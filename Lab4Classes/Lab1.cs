using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab4Classes
{
    public class Lab1
    {
        // Метод для обміну значень двох символів
        private static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }

        // Рекурсивна функція для генерації перестановок
        private static void GeneratePermutations(char[] chars, int start, int end, HashSet<string> permutations)
        {
            // Якщо досягли кінця масиву, додаємо поточну перестановку в множину
            if (start == end)
            {
                permutations.Add(new string(chars));
                return;
            }

            // Генерація перестановок за допомогою рекурсії
            for (int i = start; i <= end; i++)
            {
                Swap(ref chars[start], ref chars[i]);
                GeneratePermutations(chars, start + 1, end, permutations);
                Swap(ref chars[start], ref chars[i]);
            }
        }

        // Метод для генерації перестановок з рядка input
        public static HashSet<string> GeneratePermutations(string input)
        {
            char[] chars = input.ToCharArray();
            HashSet<string> permutations = new HashSet<string>();
            GeneratePermutations(chars, 0, chars.Length - 1, permutations);
            return permutations;
        }

        // Метод для запису перестановок у файл
        public static void WritePermutationsToFile(HashSet<string> permutations, string filePath)
        {
            // Використання блоку using для автоматичного закриття файлового потоку
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string permutation in permutations)
                {
                    writer.WriteLine(permutation);
                }
            }
        }

        public static void Main(string[] args)
        {
            // Налаштування кодування для правильного відображення символів (UTF-8)
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string inputString = string.Empty;

            // Безкінечний цикл для вибору джерела даних
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
                    break; // Завершуємо цикл, якщо вибрано 1
                }
                else if (choice == "2")
                {
                    try
                    {
                        // Зчитуємо дані з файлу INPUT.TXT
                        string[] lines = File.ReadAllLines("INPUT.TXT");
                        inputString = string.Join(Environment.NewLine, lines).Trim();
                        break; // Завершуємо цикл, якщо вибрано 2
                    }
                    catch (FileNotFoundException)
                    {
                        // Обробка винятку, якщо файл не знайдено
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Файл INPUT.TXT не знайдений.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    // Повідомлення про невірний вибір
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Невірний вибір. Будь ласка, виберіть правильну опцію.");
                    Console.ResetColor();
                }
            }

            // Генерація перестановок та запис у файл
            HashSet<string> permutations = GeneratePermutations(inputString);
            WritePermutationsToFile(permutations, "OUTPUT.TXT");

            // Виведення повідомлення про успішне завершення та перегляд результатів
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
