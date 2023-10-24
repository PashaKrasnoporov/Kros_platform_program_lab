using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Для коректної роботи програми введіть команду.");
            Console.WriteLine("Доступні команди: version, run lab1/lab2/lab3, set-path -p/--path <шлях>");
            return;
        }

        string command = args[0];

        switch (command)
        {
            case "version":
                ShowVersionInfo();
                break;
            case "run":
                if (args.Length < 2)
                {
                    Console.WriteLine("Помилка: Не вказана підкоманда для запуску.");
                }
                else
                {
                    string subcommand = args[1];
                    RunLab(subcommand, args);
                }
                break;
            case "set-path":
                SetLabPath(args);
                break;
            default:
                Console.WriteLine("Невідома команда. Для довідки використайте команду 'help'.");
                break;
        }
    }

    static void ShowVersionInfo()
    {
        Console.WriteLine("Програма: Моя Консольна Програма");
        Console.WriteLine("Автор: Ваше Ім'я");
        Console.WriteLine("Версія: 1.0");
    }

    static void RunLab(string lab, string[] args)
    {
        // Отримуємо шлях до вхідного файлу
        string inputPath = GetInputPath(args);

        // Отримуємо шлях до вихідного файлу
        string outputPath = GetOutputPath(args);

        string labPath = Environment.GetEnvironmentVariable("LAB_PATH");

        if (!string.IsNullOrEmpty(inputPath))
        {
            // Використовуємо вказаний шлях до інпут файлу
        }
        else if (!string.IsNullOrEmpty(labPath))
        {
            // Використовуємо LAB_PATH, якщо вказаний
            inputPath = Path.Combine(labPath, lab, "input.txt");
        }
        else
        {
            // Шукаємо в домашній директорії користувача
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            inputPath = Path.Combine(homeDirectory, "input.txt");
        }

        if (File.Exists(inputPath))
        {
            // Визначаємо, яку лабораторну роботу запускати на основі введеного номеру
            switch (lab)
            {
                case "lab1":
                    Lab1 lab1 = new Lab1();
                    lab1.Run(inputPath, outputPath);
                    break;
                case "lab2":
                    Lab2 lab2 = new Lab2();
                    lab2.Run(inputPath, outputPath);
                    break;
                case "lab3":
                    Lab3 lab3 = new Lab3();
                    lab3.Run(inputPath, outputPath);
                    break;
                default:
                    Console.WriteLine("Помилка: Невідомий номер лабораторної роботи.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Помилка: Вхідний файл не знайдено.");
        }
    }

    static void SetLabPath(string[] args)
    {
        if (args.Length < 3 || (args[1] != "-p" && args[1] != "--path"))
        {
            Console.WriteLine("Помилка: Не вказаний шлях для set-path.");
            return;
        }

        string path = args[2];
        Environment.SetEnvironmentVariable("LAB_PATH", path);
        Console.WriteLine($"Шлях до папки з інпут та аутпут файлами встановлено на {path}");
    }

    static string GetInputPath(string[] args)
    {
        for (int i = 0; i < args.Length - 1; i++)
        {
            if (args[i] == "-I" || args[i] == "--input")
            {
                return args[i + 1];
            }
        }
        return null;
    }

    static string GetOutputPath(string[] args)
    {
        for (int i = 0; i < args.Length - 1; i++)
        {
            if (args[i] == "-o" || args[i] == "--output")
            {
                return args[i + 1];
            }
        }
        return null;
    }
}
