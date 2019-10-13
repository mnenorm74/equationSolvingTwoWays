using System;

namespace ConsoleApplication12
{
    internal class Program
    {
        private static void chooseMethod()
       {
            Console.WriteLine("Уравнение: x^3 + 2x + 2 = 0");
            Console.WriteLine("Выберите метод решения уравнения:");
            Console.WriteLine("1. Метод деления отрезка пополам");
            Console.WriteLine("2. Метод Ньютона(касательной)");
            var methodNumber = Convert.ToInt32(Console.ReadLine());

            switch (methodNumber)
            {
                case 1:
                    FirstTask.SolveEquation();
                    break;
                case 2:
                    SecondTask.SolveEquation();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Попробуйте еще раз");
                    chooseMethod();
                    break;
            }
        }
        
        public static void Main()
        {
            chooseMethod();
        }
    }
}

