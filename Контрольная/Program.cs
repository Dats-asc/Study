using System;
using System.Collections.Generic;

namespace Контрольная_работа_13._04
{
    struct SetofStack
    {
        public int Max;
        public List<Stack<int>> stack;
        public int Count;

        public SetofStack(int max)
        {
            this.Max = max;
            stack = new List<Stack<int>>();
            Count = 0;
        }

        public void Push(int item)
        {
            if (Count % Max == 0)
            {
                stack.Add(new Stack<int>());
                stack[stack.Count - 1].Push(item);
                Count++;
            }
            else
            {
                stack[stack.Count - 1].Push(item);
                Count++;
            }
        }

        public int Pop()
        {
            int pop = stack[stack.Count - 1].Pop();
            Count--;
            return pop;
        }
    }  // 1 Задача

    class Dictnry
    {
        public Dictionary<char, int>[] array;

        public Dictnry(int count)
        {
            array = new Dictionary<char, int>[count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Dictionary<char, int>();
            }
        }

        public Dictionary<char, int> max_dct()
        {
            int max = Int32.MinValue;
            char key = '.';
            
            Dictionary<char, int> newDictionary = new Dictionary<char, int>();
            
            for (int i = 0; i < array.Length; i++)
            {
                foreach (KeyValuePair<char, int> num1 in array[i])
                {
                    max = num1.Value;
                    bool contained = false;
                    for (int e = i; e < array.Length; e++)
                    {

                        foreach (KeyValuePair<char, int> num2 in array[e])
                        {
                            if (num1.Key == num2.Key)
                            {
                                contained = true;
                                if (num2.Value > max)
                                    max = num2.Value;
                            }
                        }

                    }
                    if (contained)
                    {
                        if (!newDictionary.ContainsKey(key))
                            newDictionary.Add(key, max);
                    }
                }
            }

            return newDictionary;
        }

        public Dictionary<char, int> sum_dct()
        {
            int summ = 0;
            char key = '.';

            Dictionary<char, int> newDictionary = new Dictionary<char, int>();

            for (int i = 0; i < array.Length; i++)
            {
                foreach (KeyValuePair<char, int> num1 in array[i])
                {
                    bool contained = false;
                    summ = num1.Value;
                    for (int e = i; e < array.Length; e++)
                    {

                        foreach (KeyValuePair<char, int> num2 in array[e])
                        {
                            if (num1.Key == num2.Key)
                            {
                                contained = true;
                                summ += num2.Value;
                            }
                        }

                    }
                    if (contained)
                    {
                        if (!newDictionary.ContainsKey(key) && key != '.')
                            newDictionary.Add(key, summ);
                    }
                }
            }

            return newDictionary;
        }
    }      // 3 Задача

    

    class Program
    {
        private static int GetSum(LinkedListNode<int> node)
        {
            if (node.Previous == null)
            {
                return node.Value;
            }
            else
            {
                return node.Value + GetSum(node.Previous);
            }
        }              //
                                                                            // 2 Задача
        static LinkedList<int> GetNewListWithSumm(LinkedList<int> list)
        {
            LinkedList<int> newList = new LinkedList<int>();

            foreach (int number in list)
            {
                newList.AddLast(GetSum(list.Find(number)));
            }

            return newList;

        }  // 


        static void Main(string[] args)
        {
            Dictnry a = new Dictnry(3);
            a.array[0].Add('a', 1); a.array[0].Add('b', 2); a.array[0].Add('c', 3);
            a.array[1].Add('a', 4); a.array[1].Add('b', 5); a.array[1].Add('c', 6);
            a.array[2].Add('a', 7); a.array[2].Add('b', 8); a.array[2].Add('c', 9);

            Dictionary<char, int> newDic = a.max_dct();

            foreach (KeyValuePair<char, int> num in newDic)
                Console.Write(num.Key + ";" + num.Value + " - ");

        }
    }
}
