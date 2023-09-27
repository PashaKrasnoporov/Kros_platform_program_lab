using System;
using System.IO;
using System.Numerics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;


        bool exit = false;

        while (!exit)
        {
            int N = GetNFromUser();
            BigInteger result = 0;

            if (N != -1)
            {
                result = CountValidSequences(N);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Кількість доступних послідовностей довжини {N}: {result}");
                Console.ResetColor();

                bool invalidChoice = true;

                while (invalidChoice)
                {
                    Console.WriteLine("Що бажаєте зробити?");
                    Console.WriteLine("1. Повторно вибрати метод введення даних");
                    Console.WriteLine("2. Вийти з програми");

                    char choice = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (choice)
                    {
                        case '1':
                            invalidChoice = false;
                            break;

                        case '2':
                            invalidChoice = false;
                            exit = true;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                            Console.ResetColor();
                            break;
                    }
                }
            }
        }
    }

    static int GetNFromUser()
    {
        int N = -1;
        while (N < 1 || N > 1000)
        {
            Console.WriteLine("Оберіть спосіб введення даних:");
            Console.WriteLine("1. Введення з консолі");
            Console.WriteLine("2. Зчитування з файлу INPUT.TXT");

            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choice)
            {
                case '1':
                    Console.Write("Введіть значення N та натисніть Enter: ");

                    Console.ForegroundColor = ConsoleColor.White;
                    string input = Console.ReadLine();
                    Console.ResetColor();

                    if (int.TryParse(input, out N) && N >= 1 && N <= 1000)
                        return N;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Некоректне значення N. Спробуйте ще раз.");
                        Console.ResetColor();
                    }
                    break;

                case '2':
                    N = ReadNFromFile();
                    return N;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    Console.ResetColor();
                    break;
            }
        }

        return N;
    }

    static int ReadNFromFile()
    {
        try
        {
            using (StreamReader sr = new StreamReader("INPUT.TXT"))
            {
                string line = sr.ReadLine();
                return Convert.ToInt32(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Помилка при зчитуванні з файлу INPUT.TXT: " + e.Message);
            return -1;
        }
    }

    static BigInteger CountValidSequences(int N)
    {
        if (N == 1)
            return 2;
        if (N == 2)
            return 3;

        BigInteger[] dp = new BigInteger[N + 1];
        dp[1] = 2;
        dp[2] = 3;

        for (int i = 3; i <= N; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[N];
    }
}
