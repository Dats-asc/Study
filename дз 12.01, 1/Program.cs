using System;

namespace дз_12._02._21
{
    class Train
    {
        private string locality;
         
        private string number;

        public int countOfWagons { get; set; }

        private string[] wagons { get; set; }

        public string this[int index]
        {
            get { return wagons[index]; }
            set { wagons[index] = value; }
        }

        public string departureTime { get; set; }

        public string arriveTime { get; set; }

        public Train() { }

        public Train(string locality, string trainNumber)
        {
            this.locality = locality;
            this.number = trainNumber;
        }

        public void InputingNamesOfWagons()
        {
            wagons = new string[countOfWagons];
            for (int i = 0; i < countOfWagons; i++)
            {
                Console.Write($"\nВведите название {i} вагона: ");
                this[i] = Console.ReadLine();
            }
        }

        public static int Timing(string x, string y)
        {
            int time = (int.Parse(y.Split('-')[0]) * 60 + int.Parse(y.Split('-')[1]))
                        - (int.Parse(x.Split('-')[0]) * 60 + int.Parse(x.Split('-')[1]));
            return time;
        }

    }

    class Program
    {
        static void InformationBoard()
        {
            Console.WriteLine(
                "1 - ввести число и названия вагонов." +
                "\n2 - посчитать время пути." +
                "\n3  - оставшееся время пути.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите название пункта назначения и номер поезда.");
            Train train = new Train(Console.ReadLine(), Console.ReadLine());
            Console.WriteLine("Введите время отбытия и прибытия: часы-минуты ");
            train.departureTime = Console.ReadLine();
            train.arriveTime = Console.ReadLine();
            while (true)
            {
                InformationBoard();
                var input = Console.ReadKey();
                switch(input.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Введите число вагонов: ");
                        train.countOfWagons = int.Parse(Console.ReadLine());
                        train.InputingNamesOfWagons();
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("Время пути составит: " + Train.Timing(train.departureTime, train.arriveTime));
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("Введите актуальное время: ");
                        string time = Console.ReadLine();
                        if (Train.Timing(time, train.arriveTime) > 0)
                        {
                            int diff = Train.Timing(time, train.arriveTime);
                            Console.WriteLine($"Осталось {diff / 60} часов и {diff - ((diff / 60) * 60)} минут.");
                        }
                        else
                        {
                            int diff = Train.Timing(train.arriveTime, time);
                            Console.WriteLine($"Опаздывание на {diff / 60} часов и {diff - ((diff / 60) * 60)} минут.");
                        }
                        break;
                }
            }

        }
    }
}
