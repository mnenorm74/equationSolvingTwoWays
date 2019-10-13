using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication12
{
    public static class FirstTask
    {
        private struct positionValue
        {
            public double position;
            public double value;

            public positionValue(double Position, double Value)
            {
                position = Position;
                value = Value;
            }
        }

        private static double getFunctionValue(double x) => Math.Pow(x, 3) + 2 * x + 2;

        private static double getIntervalCenter(double leftBorder, double rightBorder) =>
            (leftBorder + rightBorder) / 2;

        private static void printValues(List<double> points)
        {
            foreach (var value in points)
            {
                Console.WriteLine(new StringBuilder().Append("x = ").Append(value).Append(" f(x) = ")
                    .Append(getFunctionValue(value)).ToString());
            }

            Console.WriteLine();
        }

        private static double getMinArgument(List<double> borders)
        {
            var minValue = new positionValue(0, double.MaxValue);
            foreach (var value in borders)
            {
                if (getFunctionValue(value) < minValue.value)
                {
                    minValue.position = value;
                    minValue.value = getFunctionValue(value);
                }
            }

            return minValue.position;
        }

        private static void writeCurrentState(double leftBorder, double rightBorder, double center, double delta)
        {
            Console.WriteLine(new StringBuilder("Левая граница интервала: ").Append(leftBorder).ToString());
            Console.WriteLine(new StringBuilder("Центр: ").Append(center).ToString());
            Console.WriteLine(new StringBuilder("Правая граница интервала: ").Append(rightBorder).ToString());
            Console.WriteLine(new StringBuilder().Append("|").Append(leftBorder).Append(center < 0 ? " + " : " - ")
                .Append(center < 0 ? -center : center).Append("| = ").Append(Math.Abs(leftBorder - center)).ToString());
            Console.WriteLine();
        }

        private static void getRoot(double leftBorder, double rightBorder, double delta)
        {
            var center = getIntervalCenter(leftBorder, rightBorder);

            if (getFunctionValue(leftBorder) * getFunctionValue(center) < 0)
            {
                rightBorder = center;
            }
            else
            {
                leftBorder = center;
            }

            center = getIntervalCenter(leftBorder, rightBorder);
            writeCurrentState(leftBorder, rightBorder, center, delta);

            if (Math.Abs(leftBorder - center) >= delta)
            {
                getRoot(leftBorder, rightBorder, delta);
            }
            else
            {
                var borders = new List<double> {leftBorder, center, rightBorder};
                printValues(borders);
                Console.WriteLine(new StringBuilder("Корень: ").Append(getMinArgument(borders)).ToString());
            }
        }

        public static void SolveEquation()
        {
            const double delta = 0.01;
            const double leftBorder = -1;
            const int rightBorder = 0;
            writeCurrentState(leftBorder, rightBorder, getIntervalCenter(leftBorder, rightBorder), delta);
            getRoot(leftBorder, rightBorder, delta);
        }
    }
}


