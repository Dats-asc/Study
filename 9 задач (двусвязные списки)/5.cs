using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Двусвязный_список_9_задач
{
    class Summ
    {
        public LinkedList<int> list;


        public Summ(LinkedList<int> list) { this.list = list; }

        private int GetValuesToZero(LinkedListNode<int> node)
        {
            if (node.Previous == null)
            {
                return node.Value;
            }
            else 
                return node.Value + GetValuesToZero(node.Previous);
        }

        public void GetSum()
        {
            LinkedList<int> newList = new LinkedList<int>();

            foreach (int number in list)
            {
                newList.AddLast(GetValuesToZero(list.Find(number)));
            }

            list = newList;
        }
    }
}
