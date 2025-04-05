using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Задаємо ймовірності
        double[] probabilities = { 0.11, 0.25, 0.26, 0.3, 0.08 };
        double[] cumulative = new double[probabilities.Length + 1];
        cumulative[0] = 0;

        // Розрахунок меж (точок) для проміжків
        for (int i = 0; i < probabilities.Length; i++)
        {
            cumulative[i + 1] = Math.Round(cumulative[i] + probabilities[i], 2);
        }

        // Виводимо точки проміжків
        Console.Write("Точки проміжків: ");
        for (int i = 1; i < cumulative.Length; i++)
        {
            Console.Write($"{cumulative[i]}; ");
        }
        Console.WriteLine();

        // Лічильники
        int[] counts = new int[probabilities.Length];

        // Моделювання
        Random rnd = new Random();
        for (int i = 0; i < 10000; i++)
        {
            double value = rnd.NextDouble();
            for (int j = 0; j < probabilities.Length; j++)
            {
                if (value > cumulative[j] && value <= cumulative[j + 1])
                {
                    counts[j]++;
                    break;
                }
            }
        }

        // Вивід результатів
        for (int i = 0; i < probabilities.Length; i++)
        {
            Console.WriteLine($"Випадкове значення потрапило у проміжок {cumulative[i]} - {cumulative[i + 1]}: {counts[i]} разів");
        }
    }
}