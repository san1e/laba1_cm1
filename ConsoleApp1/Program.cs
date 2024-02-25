using System;

class Program
{
    static void Main()
    {
        // Ваша функція
        Func<double, double> f = x => Math.Exp(x) - Math.Sin(2 * x) - 1;

        // Інтервал
        double a = -6;
        double b = 6;

        // Розбиваємо інтервал на підінтервали
        int n = 100; // Кількість підінтервалів
        double h = (b - a) / n;

        // Шукаємо корені на кожному підінтервалі
        for (int i = 0; i < n; i++)
        {
            double x1 = a + i * h;
            double x2 = a + (i + 1) * h;

            // Якщо функція змінює знак на підінтервалі
            if (f(x1) * f(x2) < 0)
            {
                // Обчислюємо корінь рівняння за методом січних з епсилоном 0.01
                double x = SecantMethod(f, x1, x2, 0.01);
                Console.WriteLine($"Root on interval [{x1}, {x2}]: {x}");
            }
        }
    }

    // Метод січних з епсилоном
    static double SecantMethod(Func<double, double> f, double x0, double x1, double epsilon)
    {
        double f0 = f(x0);
        double f1 = f(x1);
        double x2 = x1 - f1 * (x1 - x0) / (f1 - f0);
        double f2 = f(x2);

        while (Math.Abs(f2 - f1) > epsilon)
        {
            x0 = x1;
            x1 = x2;
            f0 = f1;
            f1 = f2;
            x2 = x1 - f1 * (x1 - x0) / (f1 - f0);
            f2 = f(x2);
        }

        return x2;
    }
}
