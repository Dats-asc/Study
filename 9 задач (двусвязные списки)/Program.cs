using System;
using System.Collections.Generic;

namespace Двусвязный_список_9_задач
{
    

	class Program
    {
        static LinkedList<char> GetStringLinkList(string arr)
        {
            LinkedList<char> text = new LinkedList<char>();
            for (int i = 0; i < arr.Length; i++)
            {
                text.AddLast(arr[i]);
            }

            return text;
        }

        static LinkedList<int> GetIntLinkList(int[] arr)
        {
            LinkedList<int> text = new LinkedList<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                text.AddLast(arr[i]);
            }

            return text;
        }

        static void Main(string[] args)
        {
            FindAndChangeWord a = new FindAndChangeWord(GetStringLinkList("000itmathrepetitor000"));

            a.ChangeWord("itmathrepetitor", "WORKSFINE");

            foreach (char letter in a.list)
            {
                Console.Write(letter);
            }
        }
    }
}
