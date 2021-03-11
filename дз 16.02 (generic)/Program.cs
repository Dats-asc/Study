using System;

namespace дз_16._02__generic_
{
    class Number<T>
    {
        public T Value { get; set; }
        
        public Number(T value) { Value = value; }

        public Number<long> Add(Number<long> number)
        {
            return new Number<long>(Convert.ToInt64(Value) + number.Value);
        }

        public Number<string> Add(Number<string> number)
        {
            string x = Convert.ToString(Value);
            string y = number.Value;
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
            string str = "";
            for (int i = newNumber.Length - 1; i >= 0; i--)
                str += newNumber[i];
            return new Number<string>(str);
        }

        public Number<string> Add(Number<int> number)
        {
            string x = Convert.ToString(Value);
            string y = Convert.ToString(number);
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
            char[] arr = newNumber.ToCharArray();
            Array.Reverse(arr);
            return new Number<string>(arr.ToString());
        }

        public Number<long> Sub(Number<long> number)
        {
            if (Convert.ToInt64(Value) < number.Value)
                throw new Exception("Not natural number");
            else return new Number<long>(Convert.ToInt64(Value) - number.Value);
        }

        public Number<string> Sub(Number<string> number)
        {
            string x = Value.ToString();
            string y = number.Value;
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
            char[] arr = newNumber.ToCharArray();
            Array.Reverse(arr);
            return new Number<string>(arr.ToString());
        }

        public int CompareTo(Number<long> number)
        {
            if (Convert.ToInt64(Value) < number.Value)
                return -1;
            else if (Convert.ToInt64(Value) > number.Value)
                return 1;
            else return 0;
        }

        public int CompareTo(Number<string> number)
        {
            if (Value.ToString().Length > number.Value.Length)
            {
                return 1;
            }
            else if (Value.ToString().Length < number.Value.Length)
            {
                return -1;
            }
            else
            {
                bool aNumberIsBigger = false;
                bool bNumberIsBigger = false;
                for (int i = 0; i < this.Value.ToString().Length; i++)
                {
                    if (Convert.ToInt32(Value.ToString()[i].ToString()) > Convert.ToInt32(number.Value[i].ToString()))
                    {
                        aNumberIsBigger = true;
                    }
                    else if (Convert.ToInt32(Value.ToString()[i].ToString()) < Convert.ToInt32(number.Value[i].ToString()))
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Number<long>[] longNumbers = new Number<long>[5];
            Number<string>[] veryLongNumbers = new Number<string>[5];
            for (int i = 0; i < 5; i++)
            {
                longNumbers[i] = new Number<long>(i * 10);
                veryLongNumbers[i] = new Number<string>((i * 10).ToString());
            }

            Number<string> summ = new Number<string>("0");

            for (int i = 0; i < 5; i++)
            {
                summ.Value = (summ.Add(longNumbers[i])).Value.ToString();
                summ.Value = (summ.Add(veryLongNumbers[i])).Value;
            }

            Console.WriteLine(summ.Value);
        }
    }
}
