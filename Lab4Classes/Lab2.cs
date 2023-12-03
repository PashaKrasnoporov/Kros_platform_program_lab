using System;
using System.IO;
using System.Linq;

namespace Lab4Classes
{
    public class Lab2
    {
        public static void RunLab(string inputFile, string outputFile)
        {
            try
            {
                if (!File.Exists(inputFile))
                {
                    throw new FileNotFoundException("The file INPUT.TXT was not found.");
                }

                using (StreamReader sr = new StreamReader(inputFile))
                using (StreamWriter sw = new StreamWriter(outputFile))
                {
                    // Код з вашого першого фрагменту, який рахує кількість послідовностей
                    // та не дозволяє введення некоректних даних.
                    Console.WriteLine("Введіть натуральне число N:");
                    int N = int.Parse(Console.ReadLine());

                    // Перевірка на коректність введених даних
                    if (N < 1)
                    {
                        throw new InvalidOperationException("Некоректне введення. N повинно бути натуральним числом.");
                    }

                    int result = CountSequences(N);

                    Console.WriteLine($"Кількість послідовностей довжини {N}, де жодні дві одиниці не стоять поруч: {result}");

                    // Кінець коду з першого фрагменту

                    var nm = sr.ReadLine()?.Split().Select(s =>
                    {
                        if (!int.TryParse(s, out int result))
                        {
                            throw new FormatException("Could not convert string to number.");
                        }
                        return result;
                    }).ToArray();

                    if (nm == null || nm.Length < 2)
                    {
                        throw new InvalidDataException("Incorrect input data in the first line.");
                    }

                    int n = nm[0];
                    int m = nm[1];

                    var suppliers = new (int, int)[m];

                    for (int i = 0; i < m; i++)
                    {
                        var ab = sr.ReadLine()?.Split().Select(s =>
                        {
                            if (!int.TryParse(s, out int result))
                            {
                                throw new FormatException("Could not convert string to number.");
                            }

                            return result;
                        }).ToArray();

                        if (ab == null || ab.Length < 2)
                        {
                            throw new InvalidDataException($"Incorrect input data in the string {i + 2}.");
                        }

                        suppliers[i] = (ab[0], ab[1]);
                    }

                    suppliers = suppliers.OrderBy(x => x.Item1 == 0 ? double.MaxValue : (double)x.Item2 / x.Item1).ToArray();

                    long[] dp = new long[n + 1];

                    for (int i = 1; i <= n; i++)
                    {
                        dp[i] = long.MaxValue;
                    }

                    foreach (var supplier in suppliers)
                    {
                        for (int j = 0; j <= n; j++)
                        {
                            if (dp[j] == long.MaxValue) continue;
                            int needPairs = Math.Min(supplier.Item1, n - j);
                            dp[j + needPairs] = Math.Min(dp[j + needPairs], dp[j] + supplier.Item2);
                        }
                    }

                    sw.WriteLine(dp[n] == long.MaxValue ? -1 : dp[n]);
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

        // Функція для обчислення кількості послідовностей
        static int CountSequences(int N)
        {
            // Основний алгоритм вирішення задачі
            // Використовується динамічне програмування

            // Два стани для кожного N: остання цифра 0 або 1
            int endingWithZero = 1;
            int endingWithOne = 1;

            for (int i = 2; i <= N; i++)
            {
                // Для послідовностей, що закінчуються 0, можна додати 0 або 1
                int newEndingWithZero = endingWithZero + endingWithOne;

                // Для послідовностей, що закінчуються 1, можна додати тільки 0
                int newEndingWithOne = endingWithZero;

                endingWithZero = newEndingWithZero;
                endingWithOne = newEndingWithOne;
            }

            // Загальна кількість послідовностей - сума двох станів
            return endingWithZero + endingWithOne;
        }
    }
}
