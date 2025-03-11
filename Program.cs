using System;
using System.Transactions;

class Program
{
    // функция для нахождения резульата функции. На вход принимаются дробные значения
    static double Calculate(double a, double b, double c, double d, double f, double x) 
    {
        // вывод результата функции по формуле
        return (a * Math.Pow(x, 2) + b * x + c) / (d * x + f);
    }
    static void Main()
    {
        // вывод псевдо-таблицы программы
        Console.WriteLine("\tТАБЛИЦА ВВОДА АРГУМЕНТОВ\n");
        Console.WriteLine("|Аргумент|\tДиапазон\t|Дискретность\t|");
        Console.WriteLine("|\ta|\t[0.1; 1.01]\t|\t0.01\t|");
        Console.WriteLine("|\tb|\t[18; 20]\t|\tpi\t|");
        Console.WriteLine("|\tc|\t[2.0; 3.0]\t|\t0.4\t|");
        Console.WriteLine("|\td|\t[-0.22; 0.20]\t|\t0.02\t|");
        Console.WriteLine("|\tf|\t[0.0; 0.4]\t|\t0.001\t|");
        Console.WriteLine("|\tx|\t3^(1/3)\t\t|\t-\t|");

        // ввод значений аргументов с клавиатуры 
        Console.Write("Введите значение a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите значение b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите значение c: ");
        double c = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите значение d: ");
        double d = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите значение f: ");
        double f = Convert.ToDouble(Console.ReadLine());

        // вводим константу x 
        double x = Math.Pow(3, 1.0 / 3.0);

        // вычисление значения функции. Принимаются значения аргументов от пользователя
        double functionValue = Calculate(a, b, c, d, f, x);

        // вывод результатов расчета
        Console.WriteLine("\nРЕЗУЛЬТАТЫ ВЫЧИСЛЕНИЯ\n");
        Console.WriteLine("Аргумент\tЗначение");
        Console.WriteLine($"a\t{a:F4}");
        Console.WriteLine($"b\t{b:F4}");
        Console.WriteLine($"c\t{c:F4}");
        Console.WriteLine($"d\t{d:F4}");
        Console.WriteLine($"f\t{f:F4}");
        Console.WriteLine($"x\t{x:F4}");
        Console.WriteLine($"Функция\t{functionValue:F4}");

        // автоматизированные тесты
        Console.WriteLine("\nЗапуск тестов\n");
        // создаем обобщенный сипсок, который позволяет хранить элементы определенного типа в динамическом массиве
        // в данном случае это кортеж, который хранит в себе 7 значений типа double
        // далее создается объект списка testCases, который содержит тестовые данные
        List<(double, double, double, double, double, double, double)> testCases = new List<(double, double, double, double, double, double, double)>
        {
            // список содержит набор заданных значений аргементов функции и вычесленных для них
            // ожидаемый результат
            (0.1, 18, 2.0, -0.22, 0.0, x, Calculate(0.1, 18, 2.0, -0.22, 0.0, x)),
            (1.01, 20, 3.0, 0.20, 0.4, x, Calculate(1.01, 20, 3.0, 0.20, 0.4, x)),
            (0.5, 19, 2.5, -0.1, 0.2, x, Calculate(0.5, 19, 2.5, -0.1, 0.2, x))
        };

        // данный цикл перебирает каждый кортеж (a, b, c, d, f, x expected) в списке testCases
        // каждый кортеж распаковывается в переменные aTest, bTest, cTest, dTest, fTest, xTest, expected
        foreach (var (aTest, bTest, cTest, dTest, fTest, xTest, expected) in testCases)
        {
            // вычесление резульата функции по тестовым значениям аргументов
            double result = Calculate(aTest, bTest, cTest, dTest, fTest, xTest);
            // вывод резульата теста
            Console.WriteLine($"Тест с a={aTest}, b={bTest}, c={cTest}, d={dTest}, f={fTest}: {result:F4} (ожидалось {expected:F4})");
        }
    }
}
