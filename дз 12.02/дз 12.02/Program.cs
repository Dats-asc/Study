using System;

namespace дз_12._02
{
    class Person { }

    class Employee : Person { }

    class Program
    {

        static void SimpleMethod(int x, int y)
        {
            try
            {
                try
                {
                    if (x == 0 && y == 0)
                        throw new Exception();
                    Console.WriteLine(x / y);
                }
                catch (Exception) { throw; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                int z = int.Parse(null);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

                int[] array1 = new int[x];
                int[] array2 = new int[y];
                if (x != 0 && y != 0)
                {
                    int z = array1[x - 1] + array2[y - 1];
                }

            Person person = new Person();
                Employee emp = (Employee)person;

        }

        static double Ctan(double x)
        {
            try
            {
                try
                {
                    if (x == 0)
                        throw new Exception();
                    return 1 / Math.Tan(x);
                }
                catch (Exception) { throw; }
            }
            catch (Exception)
            {
                throw new Exception("Argument zero divide.");
            }


        }

        static void Main(string[] args)
        {
            SimpleMethod(0, 0);
        }
    }
}
