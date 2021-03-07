using System;
using System.Collections.Generic;
using System.Collections;

namespace d
{

    class MyList<T>
    {
        public T[] list;

        public int Count { get; private set; }

        public MyList()
        {
            list = new T[0];
            Count = 0;
        }

        public T this[int index]
        {
            get { return list[index]; }

            set { list[index] = value; }
        }

        private void ExpandArray()
        {
            T[] tempArray;

            if (Count == 0)
            {
                tempArray = new T[1];
            }
            else
            {
                tempArray = new T[list.Length * 2];
            }

            for (int i = 0; i < list.Length; i++)
            {
                tempArray[i] = list[i];
            }

            list = tempArray;
        }

        public void Add(T item)
        {
            if (list.Length == Count)
            {
                ExpandArray();
            }

            Count++;
            list[Count - 1] = item;
        }

        public int IndexOf(T item)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (Object.Equals(list[i], item))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public bool Remove(T item)
        {
            if (IndexOf(item) != -1)
            {
                int index = IndexOf(item);
                int count = 0;

                T[] tempArray = new T[list.Length];
                for (int i = 0; i < Count; i++)
                {
                    if (i == index)
                    {
                        continue;
                    }
                    tempArray[count] = list[i];
                    count++;
                }

                list = tempArray;
                Count--;

                return true;
            }
            else return false;
        }

        public void RemoveAt(int index)
        {
            T[] tempArray = new T[Count];

            int count = 0;

            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    continue;
                }

                tempArray[count] = list[i];
                count++;
            }

            Count--;
            list = tempArray;
        }

        public void Insert(int index, T item)
        {


            T[] tempArray = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    tempArray[i] = item;
                    continue;
                }

                tempArray[i] = list[i];
            }

            list = tempArray;
        }

        public int BinarySearch(T item)
        {
            return BinarySrch(0, Count, item);
        }

        private int BinarySrch(int left, int right, T item)
        {
            int mid = left + (right - left) / 2;

            if (left >= right)
                return -1;

            if (Convert.ToInt32(list[mid]) == Convert.ToInt32(item))
                return mid;

            else if (Convert.ToInt32(list[mid]) > Convert.ToInt32(item))
                return BinarySrch(left, mid, item);

            else
                return BinarySrch(mid + 1, right, item);
        }

        public void Sort()
        {
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count - 1; j++)
                {
                    if (Convert.ToInt32(list[j]) > Convert.ToInt32(list[j + 1]))
                    {
                        T temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        public void AddRange(ICollection<T> collection)
        {
            List<T> newList = (List<T>)collection;
            T[] tempArray = new T[(int)Math.Pow(2,Math.Ceiling(Math.Log2(Count + collection.Count)))];
            int count = 0;

            for (int i = 0; i < Count; i++)
            {
                tempArray[i] = list[i];
                count++;
            }

            for (int i = 0; i < collection.Count; i++)
            {
                tempArray[count] = newList[i];
            }

            list = tempArray;
        }

        public void ChangeMin()
        {
            int min = Int32.MaxValue;
            int max = Int32.MinValue;
            int indexOfMin = -1;
            int indexOfMax = -1;

            for (int i = 0; i < Count; i++)
            {
                if (Convert.ToInt32(list[i]) > max)
                {
                    max = Convert.ToInt32(list[i]);
                    indexOfMax = i;
                }

                if (Convert.ToInt32(list[i]) <max)
                {
                    min = Convert.ToInt32(list[i]);
                    indexOfMin = i;
                }
            }

            T temp = list[indexOfMax];
            list[indexOfMax] = list[indexOfMin];
            list[indexOfMin] = temp;

        }

        private static int GetLargestString(List<string> list)
        {
            int maxLength = -1;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Length > maxLength)
                    maxLength = list[i].Length;
            }

            return maxLength;
        }

        private static string ChangeString(string str, int maxLength)
        {
            string newString = "";

            for(int i = 0; i < maxLength; i++)
            {
                if (i < str.Length)
                {
                    newString += str[i];
                }
                else
                {
                    newString += "_";
                }
            }
            return newString;
        }

        public static List<string> all_eq(List<string> stringList)
        {
            int maxLength = GetLargestString(stringList);
            for (int i = 0; i < stringList.Count; i++)
            {
                stringList[i] = ChangeString(stringList[i], maxLength);
            }

            return new List<string>(stringList);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
