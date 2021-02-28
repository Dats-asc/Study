using System;

namespace дз_12._02._21_2
{
    class Program
    {

        class Arr
        {
            public int columns { get; private set; }

            public int rows { get; private set; }

            private int[,] array { get; set; }


            public int ArraySize { get { return columns * rows; } }
            

            public Arr() { }

            public Arr(int rows, int columns)
            {
                this.rows = rows;
                this.columns = columns;
                array = new int[rows, columns];
            }

            public int this[int index1, int index2]
            {
                get { return array[index1,index2]; }
                set { array[index1, index2] = value; }
            }

            public int this[int column]
            {
                set
                {
                    for (int i = 0; i < rows; i++)
                    {
                        value = int.Parse(Console.ReadLine());
                        array[i, column] = value;
                    }
                }

                get
                {
                    string str = "";
                    for (int i = 0; i < rows; i++)
                    {
                        str += array[i, column] + " ";
                    }
                    Console.WriteLine(array);
                    return 0;
                }
            }
        }
        static void Main(string[] args)
        {

        }
    }
}
