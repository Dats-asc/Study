using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Двусвязный_список_9_задач
{
    class OrdinaryList
    {
        public LinkedList<int> List = new LinkedList<int>();

        private List<int> arr = new List<int>();

        public OrdinaryList(LinkedList<int> list)
        {
            List = list;
            foreach(int number in List)
            {
                arr.Add(number);
            }
        }

        public void SortByNegativeNumbers()
        {
            for (int k = 0; k < arr.Count; k++)
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    if (arr[i] > 0)
                    {
                        for (int j = i + 1; j < arr.Count; j++)
                        {
                            if (arr[j] > 0)
                            {
                                if (arr[i] > arr[j])
                                {
                                    int temp = arr[i];
                                    arr[i] = arr[j];
                                    arr[j] = temp;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            var newList = new LinkedList<int>();
            for (int i = 0; i < arr.Count; i++)
                newList.AddLast(arr[i]);

            List = newList;
        }

        public void SortByEvenNumbers()
        {
            for (int k = 0; k < arr.Count; k++)
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        for (int j = i + 1; j < arr.Count; j++)
                        {
                            if (arr[j] % 2 == 0)
                            {
                                if (arr[i] > arr[j])
                                {
                                    int temp = arr[i];
                                    arr[i] = arr[j];
                                    arr[j] = temp;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            var newList = new LinkedList<int>();
            for (int i = 0; i < arr.Count; i++)
                newList.AddLast(arr[i]);

            List = newList;
        }
    }
}
