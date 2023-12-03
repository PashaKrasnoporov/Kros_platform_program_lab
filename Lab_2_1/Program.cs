using LabsLibrary;
using System;
using System.IO;
using System.Numerics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        LabsClasses.Lab2 _labClass = new LabsClasses.Lab2();
        // Встановлення кодування для виводу та вводу консолі в UTF-8 для правильної роботи з не-Latin символами
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        bool exit = false;

        // Основний цикл програми
        while (!exit)
        {
            int N = _labClass.GetNFromUser(); // Отримання N від користувача

            BigInteger result = 0;

            // Якщо отримано допустиме значення N
            if (N != -1)
            {
                // Обчислення кількості допустимих послідовностей для заданого N
                result = _labClass.CountValidSequences(N);

                // Відображення результату користувачу
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Кількість доступних послідовностей довжини {N}: {result}");
                Console.ResetColor();

                bool invalidChoice = true;

                // Внутрішній цикл для обробки вибору користувача після відображення результату
                while (invalidChoice)
                {
                    Console.WriteLine("Що бажаєте зробити?");
                    Console.WriteLine("1. Повторно вибрати метод введення даних");
                    Console.WriteLine("2. Вийти з програми");

                    char choice = Console.ReadKey().KeyChar; // Отримання вибору користувача
                    Console.WriteLine();

                    switch (choice)
                    {
                        case '1':
                            invalidChoice = false;
                            break;

                        case '2':
                            invalidChoice = false;
                            exit = true; // Вихід з програми
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
}
