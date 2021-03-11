using System;

namespace дз_16._02
{

    interface INumber
    {

        string Value { get; set; }

        INumber Add(INumber n);

        INumber Sub(INumber n);

        int compareTo(INumber n);
    }

    class SimpleLongNumber : INumber
    {
        public string Value { get; set; }

        private long longValue { get; set; }

        public SimpleLongNumber(long number) { Value = number.ToString(); longValue = number; }

        public INumber Add(INumber n)
        {
            Value = (longValue + Convert.ToInt64(n.Value)).ToString();
            return new SimpleLongNumber(longValue + Convert.ToInt64(n.Value));
        }

        public int compareTo(INumber n)
        {
            if (longValue > Convert.ToInt64(n.Value))
                return 1;
            else if (longValue < Convert.ToInt64(n.Value))
                return -1;
            else return 0;
        }

        public INumber Sub(INumber n)
        {
            if (longValue < Convert.ToInt64(n.Value))
            {
                throw new Exception("Number not natural");
            }
            else
            {
                Value = (longValue + Convert.ToInt64(n.Value)).ToString();
                return new SimpleLongNumber(longValue + Convert.ToInt64(n.Value));
            }
        }
    }

    class VeryLongNumber : INumber
    {
        public string Value { get; set; }

        private string veryLongValue { get; set; }


        public VeryLongNumber(string n) { Value = n; veryLongValue = n; }

        public INumber Add(INumber n)
        {
            string x = veryLongValue;
            string y = Convert.ToString(n.Value);
            if (x.Length < y.Length)
            {
                string temp = x;
                x = y;
                y = temp;
            }
            string newNumber = "";
            int xEnd = x.Length - 1;
            int yEnd = y.Length - 1;
            int rest = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (yEnd >= 0)
                {
                    int sum = Convert.ToInt32(x[xEnd].ToString()) + Convert.ToInt32(y[yEnd].ToString()) + rest;
                    rest = 0;
                    if (sum <= 9)
                    {
                        newNumber += sum;
                    }
                    else if (sum >= 10)
                    {
                        rest++;
                        newNumber += sum - 10;
                    }
                    xEnd--;
                    yEnd--;
                }
                else
                {
                    int sum = Convert.ToInt32(x[xEnd].ToString()) + rest;
                    rest = 0;
                    newNumber += sum;
                }
                if (xEnd == yEnd && rest == 1)
                {
                    newNumber += rest;
                    break;
                }
            }
            
            Value = newNumber;
            return new VeryLongNumber(newNumber);
        }

        public int compareTo(INumber n)
        {
            string x = Convert.ToString(n.Value);
            if (veryLongValue.Length > x.Length)
            {
                return 1;
            }
            else if (veryLongValue.Length < x.Length)
            {
                return -1;
            }
            else
            {
                bool aNumberIsBigger = false;
                bool bNumberIsBigger = false;
                for (int i = 0; i < veryLongValue.Length; i++)
                {
                    if (Convert.ToInt32(veryLongValue[i].ToString()) > Convert.ToInt32(x[i].ToString()))
                    {
                        aNumberIsBigger = true;
                    }
                    else if (Convert.ToInt32(veryLongValue[i].ToString()) < Convert.ToInt32(x[i].ToString()))
                    {
                        bNumberIsBigger = true;
                    }
                }
                if (aNumberIsBigger == false && bNumberIsBigger == false)
                {
                    return 0;
                }
                else if (aNumberIsBigger == true)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public INumber Sub(INumber n)
        {
            string x = veryLongValue;
            string y = Convert.ToString(n.Value);
            string newNumber = "";
            int xEnd = x.Length - 1;
            int yEnd = y.Length - 1;
            int rest = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (yEnd >= 0)
                {
                    int sum = Convert.ToInt32(x[xEnd].ToString()) - Convert.ToInt32(y[yEnd].ToString()) + rest;
                    rest = 0;
                    if (sum >= 0)
                    {
                        newNumber += sum;
                    }
                    else if (sum < 0)
                    {
                        rest++;
                        newNumber += 10 + sum;
                    }
                    xEnd--;
                    yEnd--;
                }
                else
                {
                    int sum = Convert.ToInt32(x[xEnd].ToString()) - rest;
                    rest = 0;
                    if (sum < 0)
                    {
                        rest++;
                        newNumber += 10 + sum;
                        continue;
                    }
                    newNumber += sum;
                }
                if (xEnd == yEnd && rest == 1)
                {
                    newNumber += Convert.ToInt32(x[0]) - rest;
                    break;
                }
            }
            Value = newNumber;
            return new VeryLongNumber(newNumber);
        }

        public static VeryLongNumber operator +(VeryLongNumber x, VeryLongNumber y)
        {
            return (VeryLongNumber)x.Add(y);
        }

        public static VeryLongNumber operator +(VeryLongNumber x, SimpleLongNumber y)
        {
            return (VeryLongNumber)x.Add(new VeryLongNumber(y.Value.ToString()));
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            INumber[] numbers = new INumber[10];


            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    numbers[i] = new SimpleLongNumber(i * 21);
                }
                else
                {
                    numbers[i] = new VeryLongNumber((i * 13).ToString());
                }
            }

            VeryLongNumber summ = new VeryLongNumber("0");

            for (int i = 0; i < 10; i++)
            {
                summ.Value = (summ.Add(numbers[i]).Value);
            }

            Console.WriteLine("Сумма - " + Convert.ToString(summ.Value));

          
        }
    }
}
