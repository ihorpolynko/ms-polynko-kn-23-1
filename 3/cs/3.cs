using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        double lamda = 1;
        List<double> Xn = new List<double>();

        // Генерація 10 випадкових чисел
        Random rnd = new Random();
        for (int i = 0; i < 10; i++)
        {
            double y = rnd.NextDouble();  // Генерація випадкового числа Y в діапазоні [0, 1)

            // Використовуємо обернену функцію для моделювання експоненціального розподілу
            double xn = (-1 * Math.Log(1 - y)) / lamda;
            Xn.Add(xn);
        }

        double time = 0;
        for (int i = 0; i < Xn.Count; i++)
        {
            time += Xn[i];
            Console.WriteLine($"Подія {i} настала після {time} одиниці часу.");
        }
    }
}