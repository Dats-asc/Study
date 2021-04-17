using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Двусвязный_список_9_задач
{
    class Multiplicity
    {
        LinkedList<int> list1 = new LinkedList<int>();
        LinkedList<int> list2 = new LinkedList<int>();

        public Multiplicity(LinkedList<int> list1, LinkedList<int> list2)
        {
            if (list1.Count <= list2.Count)
            {
                this.list1 = list1;
                this.list2 = list2;
            }
            else
            {
                this.list1 = list2;
                this.list2 = list1;
            }
        }

        public bool ListsAreEquals()
        {
            LinkedList<int> temp = new LinkedList<int>();
            foreach (int num in list2)
                temp.AddLast(num);

            bool areEquals = true;

            foreach(int firstNum in list1)
            {
                foreach (int secondNum in temp)
                {
                    if (firstNum == secondNum)
                    {
                        temp.Remove(temp.Find(secondNum));
                        break;
                    }
                    else
                    {
                        areEquals = false;
                    }
                    if (!areEquals)
                        break;
                }
                if (!areEquals)
                    break;
            }

            return areEquals;
        }
    }
}
