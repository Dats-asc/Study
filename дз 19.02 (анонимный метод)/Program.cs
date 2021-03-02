using System;

namespace дз_19._02
{
    class Program
    {

        delegate double Avarege(RandomNumbers[] numbers);

        delegate int RandomNumbers();
        
        static int GetRandomNumber()
        {
            return new Random().Next();
        }

        static Avarege avarage = delegate (RandomNumbers[] numbers)
        {
            long summ = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                summ += numbers[i]();
            }
            return (double)summ / numbers.Length;
        };

        static void Main(string[] args)
        {
            Console.Write("Количество элементов массива - ");
            int length = int.Parse(Console.ReadLine());

            RandomNumbers[] numbers = new RandomNumbers[length];
            for (int i = 0; i < length; i++)
            {
                numbers[i] = GetRandomNumber;
            }

            Console.WriteLine($"Среднее арефметическое - {avarage(numbers)}");
        }
    }
}
