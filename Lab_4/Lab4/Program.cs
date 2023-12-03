using Lab4Classes;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter command: ");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                DisplayHelp();
                continue;
            }

            string[] args = input.Split(' ');

            try
            {
                switch (args[0].ToLower())
                {
                    case "version":
                        Console.WriteLine("Author: Pavlo Krasnopyorov");
                        Console.WriteLine("Version: 2.0");
                        break;

                    case "run":
                        HandleRunCommand(args);
                        break;

                    case "set-path":
                        HandleSetPathCommand(args);
                        break;

                    case "exit":
                    case "quit":
                        return;

                    default:
                        DisplayHelp();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }

    private static void HandleRunCommand(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Please specify the lab number.");
            return;
        }

        string labName = args[1].ToLower();
        if (labName != "lab1" && labName != "lab2" && labName != "lab3")
        {
            Console.WriteLine("Invalid lab number. Please enter lab1, lab2, or lab3.");
            return;
        }

        string inputPath = GetArgumentValue(args, "-i", "--input");
        string outputPath = GetArgumentValue(args, "-o", "--output");
        SetDefaultPathsIfNecessary(ref inputPath, ref outputPath);

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        int labNumber = int.Parse(labName.Substring(3));
        Runner.RunLab(labNumber, inputPath, outputPath);
        Console.WriteLine($"Lab {labNumber} has been run with input from {inputPath} and output to {outputPath}");
    }

    private static void HandleSetPathCommand(string[] args)
    {
        string path = GetArgumentValue(args, "-p", "--path");
        if (string.IsNullOrEmpty(path))
        {
            Console.WriteLine("Path not specified.");
            return;
        }

        Environment.SetEnvironmentVariable("LAB_PATH", path);
        Console.WriteLine($"Environment variable LAB_PATH set to {path}");
    }

    static string GetArgumentValue(string[] args, string shortArg, string longArg)
    {
        for (int i = 1; i < args.Length - 1; i++)
        {
            if (args[i].Equals(shortArg, StringComparison.OrdinalIgnoreCase) || args[i].Equals(longArg, StringComparison.OrdinalIgnoreCase))
            {
                return args[i + 1];
            }
        }
        return null;
    }

    static void SetDefaultPathsIfNecessary(ref string inputPath, ref string outputPath)
    {
        string labPath = Environment.GetEnvironmentVariable("LAB_PATH") ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        if (string.IsNullOrEmpty(inputPath))
        {
            inputPath = Path.Combine(labPath, "input.txt");
        }

        if (string.IsNullOrEmpty(outputPath))
        {
            outputPath = Path.Combine(labPath, "output.txt");
        }
    }

    static void DisplayHelp()
    {
        Console.WriteLine("Available commands:");
        Console.WriteLine("version - Display program info");
        Console.WriteLine("run [lab1|lab2|lab3] - Run the specified lab");
        Console.WriteLine("set-path - Set the folder path");
        Console.WriteLine("exit/quit - Exit the program");
    }
}
