using System;

namespace дз_19._02
{


    class Program
    {

        delegate double Calculation(double r, ref string result);
        
        static double CircleLength(double r, ref string result)
        {
            result += $"Длина - {Math.Round(2 * Math.PI * r, 2)}, ";
            return 2 * Math.PI * r;
        }

        static double CircleSquare(double r, ref string result)
        {
            result += $"площадь - {Math.Round(Math.PI * Math.Pow(r, 2),2)}, ";
            return Math.PI * Math.Pow(r, 2);
        }

        static double SphereVolume(double r, ref string result)
        {
            result += $"объём - {Math.Round(4.0 / 3 * Math.PI * Math.Pow(r, 3),2)}";
            return 4.0 / 3 * Math.PI * Math.Pow(r, 3);
        }

        static void Main(string[] args)
        {
            Calculation circle = CircleLength;
            circle += CircleSquare;
            circle += SphereVolume;

            string result = "";
            double radius = double.Parse(Console.ReadLine());

            circle(radius, ref result);
            Console.WriteLine(result);
        }
    }
}
