using System;

namespace LaboratoryWork3
{
    class Program
    {
        static void Main()
        {
            double startX = Math.PI / 5.0;
            double endX = Math.PI;
            int stepsCount = 10;
            int assignedN = 40;
            double precisionE = 0.0001;

            double step = (endX - startX) / stepsCount;

            Console.WriteLine("Вычисление функции");
            Console.WriteLine("---------------------------------------------------------------------");

            for (double x = startX; x <= endX + step / 2; x += step)
            {
                x = Math.Round(x, 4);

                double sumN = CalculateSumForAssignedN(x, assignedN);
                double sumE = CalculateSumWithPrecision(x, precisionE);
                double exactY = CalculateExactValue(x);


                Console.WriteLine("X=" + x.ToString("F4") + "\tSN=" + sumN.ToString("F6") + "\tSE=" + sumE.ToString("F6") + "\tY=" + exactY.ToString("F6"));
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Console.ReadLine();
        }

        static double CalculateSumForAssignedN(double x, int n)
        {
            double sum = 0.0;

            for (int i = 1; i <= n; i++)
            {
                double oddNumber = 2 * i - 1;
                double currentTerm = Math.Cos(oddNumber * x) / (oddNumber * oddNumber);
                sum += currentTerm;
            }
            return sum;
        }

        static double CalculateSumWithPrecision(double x, double e)
        {
            double sum = 0.0;
            int i = 1;

            while (true)
            {
                double oddNumber = 2 * i - 1;
                double currentTerm = Math.Cos(oddNumber * x) / (oddNumber * oddNumber);
                
                if (Math.Abs(currentTerm) < e)
                {
                    break;
                }

                sum += currentTerm;
                i++;
            }
            return sum;
        }

        static double CalculateExactValue(double x)
        {
            return (Math.PI * Math.PI) / 8.0 - (Math.PI / 4.0) * Math.Abs(x);
        }
    }
}
