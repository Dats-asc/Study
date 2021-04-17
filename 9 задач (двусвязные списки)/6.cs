using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Двусвязный_список_9_задач
{
    class FindAndChangeWord
    {
        public LinkedList<char> list = new LinkedList<char>();

        public FindAndChangeWord(LinkedList<char> list) { this.list = list; }

        private bool Check(string word, LinkedListNode<char> node, ref int counter, ref bool wordExist)
        {
            if (node == null && counter != word.Length - 1)
            {
                wordExist = false;
                return wordExist;
            }
            if (counter == word.Length - 1)
            {
                return wordExist;
            }
            else
            {
                if (word[counter] == node.Value)
                {
                    counter++;
                    Check(word, node.Next, ref counter, ref wordExist);
                }
                else
                {
                    wordExist = false;
                    return wordExist;
                }
            }
            return wordExist;
        }

        private void Change(string word, int index, string changeTo)
        {
            char[] arr = new char[list.Count];
            List<char> newArr = new List<char>();
            LinkedList<char> newList = new LinkedList<char>();

            int i = 0;
            foreach (char letter in list)
            {
                arr[i] = letter;
                i++;
            }

            for (int j = 0; j < arr.Length; j++)
            {
                if (j == index)
                {
                    for (int e = 0; e < changeTo.Length; e++)
                    {
                        newArr.Add(changeTo[e]);
                    }
                    j += word.Length - 1;
                }
                else
                    newArr.Add(arr[j]);
            }
            for (int j = 0; j < newArr.Count; j++)
            {
                newList.AddLast(newArr[j]);
            }

            list = newList;
        }

        public void ChangeWord(string word, string changeTo)
        {

            bool wordExist = true;
            int index = 0;
            foreach (char letter in list)
            {

                int counter = 0;
                wordExist = true;
                if (letter == word[0])
                {
                    if (Check(word, list.Find(letter), ref counter, ref wordExist))
                    {
                        Change(word, index, changeTo);
                    }
                }
                index++;
            }
        }
    }
}
