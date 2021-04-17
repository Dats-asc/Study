using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Двусвязный_список_9_задач
{
    class OrderedList
    {
        LinkedList<int> firstList { get; set; }
        LinkedList<int> secondList { get; set; }

        public OrderedList(LinkedList<int> firstList, LinkedList<int> secondList)
        {
            this.firstList = firstList;
            this.secondList = secondList;
        }

        public LinkedList<int> Join()
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            LinkedList<int> newList = new LinkedList<int>();
            

            foreach (int num in firstList)
                list1.Add(num);
            foreach (int num in secondList)
                list2.Add(num);

            for (int i = 0; i < list2.Count; i++)
            {
                bool isMore = false;
                for (int j = 0; j < list1.Count; j++)
                {
                    if (list2[i] >= list1[j])
                    { 
                        isMore = true;
                        list1.Insert(j, list2[i]);
                        break;
                    }
                }
                if (!isMore)
                    list1.Add(list2[i]);
            }

            for (int i = 0; i < list1.Count; i++)
            {
                newList.AddLast(list1[i]);
            }

            return newList;
        }
    }
}
