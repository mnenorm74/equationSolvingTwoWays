using System;
using System.Text;

namespace ConsoleApplication12
{
    public static class SecondTask
    {
        private static double getSecondDerivativeValue(double x) => 6 * x;

        private static double getFirstDerivativeValue(double x) => 3 * Math.Pow(x, 2) + 2;

        private static double getFunctionValue(double x) => Math.Pow(x, 3) + 2 * x + 2;

        private static int getCountSignsAfterPoint(double delta)
        {
            return delta < 1 ? delta.ToString().Split(',')[1].Length : 0;
        }

        private static void printCurrentState(double previousValue, double currentValue)
        {
            Console.WriteLine(new StringBuilder().Append("Предыдущее значение = ").Append(previousValue)
                .Append(" текущее значение = ").Append(currentValue).Append(" разница = ")
                .Append(Math.Abs(currentValue - previousValue)).ToString());
        }

        private static void getRoot(double previousValue, double delta)
        {
            var currentValue =
                previousValue - getFunctionValue(previousValue) / getFirstDerivativeValue(previousValue);
            printCurrentState(previousValue, currentValue);

            if (Math.Abs(currentValue - previousValue) >= delta)
            {
                getRoot(currentValue, delta);
            }
            else
            {
                Console.WriteLine(new StringBuilder().Append("Корень: ")
                    .Append(Math.Round(currentValue, getCountSignsAfterPoint(delta))).ToString());
            }
        }
        
        public static void SolveEquation()
        {
            const double delta = 0.01;
            const double leftBorder = -1;
            const int rightBorder = 0;
            var previousValue = getFunctionValue(leftBorder) * getSecondDerivativeValue(leftBorder) > 0 
                ? leftBorder 
                : rightBorder;
            getRoot(previousValue, delta);
        }
    }
}

