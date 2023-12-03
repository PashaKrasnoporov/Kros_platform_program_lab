using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Numerics;
using WebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class FunctionsController : Controller
{
    public IActionResult Function1()
    {

        var model = new Function
        {
            Name = "Генерація перестановок",
            Description = $"Генерує всі можливі перестановки символів введеного рядка. Введіть рядок:",
        // Other data
        };
        return View(model);
    }

    public async Task<IActionResult> GeneratePermutations([Bind("Input")] Function model)
    {
        try
        {
            // Simulate asynchronous processing (replace with actual asynchronous logic)
            //await Task.Delay(1000);

            var permutations = PermutationsGenerator.GeneratePermutations(model.Input);
            model.Output = permutations;
            // Other data

            return View("Function1", model);
        }
        catch (Exception ex)
        {
            model.ErrorMessage = $"Помилка: {ex.Message}";
            // Other data

            return View("Function1", model);
        }
    }


    public IActionResult Function2()
    {
        var model1 = new Function
        {
            Name = "Генерація послідовностей",
            Description = "Ця функція реалізує обчислення та відображення кількості допустимих послідовностей для заданого числа N. Підтримує введення з консолі та зчитування з файлу INPUT.TXT.",
            // Інші дані
        };
        return View(model1);
    }

    public async Task<IActionResult> GenerateSequences([Bind("Input")] Function model1)
    {
        try
        {
            // Simulate asynchronous processing (replace with actual asynchronous logic)
            //await Task.Delay(1000);

            int inputValue = int.Parse(model1.Input);
            BigInteger permutations = Class2.CountValidSequences(inputValue);
            model1.Output = new HashSet<string> { permutations.ToString() };

            // Other data

            return View("Function2", model1);
        }
        catch (Exception ex)
        {
            model1.ErrorMessage = $"Помилка: {ex.Message}";
            // Other data

            return View("Function2", model1);
        }
    }

    public IActionResult Function3()
    {
        var model3 = new Puzzle
        {
            Name = "Вирішити Головоломку",
            Description = "Метод, який вирішує головоломку з мінімізацією перестановок.",
            // Other data
        };
        return View(model3);
    }

    public async Task<IActionResult> SolvePuzzle([Bind("Input, EndInput, NumInput")] Puzzle model3)
    {
        try
        {
            // Simulate asynchronous processing (replace with actual asynchronous logic)
            //await Task.Delay(1000);

            char[] startValue = (model3.Input).ToCharArray();
            char[] endValue = (model3.EndInput).ToCharArray();

           
            int rows = model3.NumInput;
            int cols = startValue.Length / rows;
            char[,] start = new char[rows, cols];
            char[,] end = new char[rows, cols];


            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    end[i, j] = endValue[i * cols + j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    start[i, j] = startValue[i * cols + j];
                }
            }

            int result = MinimumMoves(start, end);
            model3.Output = new HashSet<string> { result.ToString() }; ;
            


            return View("Function3", model3);
        }
        catch (Exception ex)
        {
            model3.ErrorMessage = $"Помилка: {ex.Message}";
            // Other data

            return View("Function3", model3);
        }
    }

    [Authorize]
    public IActionResult FunctionsList(Function model)
    {
        return View();
    }

    public int MinimumMoves(char[,] startState, char[,] targetState)
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

    public bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < 2 && col >= 0 && col < 4;
    }

    public string StateToString(char[,] state)
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

    public string SwapCharacters(string str, int index1, int index2)
    {
        char[] characters = str.ToCharArray();
        char temp = characters[index1];
        characters[index1] = characters[index2];
        characters[index2] = temp;
        return new string(characters);
    }
}

    // Repeat for other functions
