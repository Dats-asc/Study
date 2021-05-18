using System;
using System.Collections.Generic;
using System.Linq;

namespace Контрольная_2
{
    class VersionStack
    {
        private List<Stack<int>> Stacks;
        private List<int> Elements;
        public int ConditionOfStack;

        private List<Stack<int>> RollbackStacks;
        private int RollbackConditionNumber;
        private List<int> RollbackElements;


        public VersionStack()
        {
            Stacks = new List<Stack<int>>();
            Stacks.Add(new Stack<int>());
            ConditionOfStack = 0;
            Elements = new List<int>();
        }

        public void Push(int item)
        {
            Elements.Add(item);
            Stacks.Add(new Stack<int>(Elements));
            ConditionOfStack++;
        }

        public int Pop()
        {
            int item = Elements[Elements.Count - 1];
            Elements.RemoveAt(Elements.Count - 1);
            ConditionOfStack--;
            return item;
        }

        public void Rollback(int number)
        {
            RollbackStacks = new List<Stack<int>>();
            for(int i = number; i < Stacks.Count; i++)
            {
                RollbackStacks.Add(Stacks[i]);
            }
            RollbackElements = new List<int>(Elements);
            RollbackConditionNumber = number;
            ConditionOfStack = number;
            Elements.RemoveRange(number, Elements.Count - number);
        }

        public void BackupRollback()
        {
            ConditionOfStack = RollbackConditionNumber;
            Elements = RollbackElements;
            Stacks.AddRange(RollbackStacks);
        }

        public void Forget()
        {
            Stacks = new List<Stack<int>>();
            Stacks.Add(new Stack<int>());
            ConditionOfStack = 0;
            Elements = new List<int>();
        }
    } // 2 задача


    class Line
    {
        public readonly int xStart;
        public readonly int yStart;
        public readonly int xEnd;
        public readonly int yEnd;

        public Line(int xS, int yS, int xE, int yE)
        {
            xStart = xS;
            yStart = yS;
            xEnd = xE;
            yEnd = yE;
        }
    }

    class Program
    {

        static List<int> JoinFirstN(int N, List<List<int>> lists)
        {
            List<int> result = lists[0];

            for (int i = 1; i < lists.Count; i++)
            {
                result = result.Union(lists[i]).ToList();
            }

            var temp = result;
            result = new List<int>();

            for (int i = 0; i < N; i++)
            {
                result.Add(temp[i]);
            }
            return result;
        } // 1 задача

        static void Main(string[] args)
        {
            VersionStack a = new VersionStack();
            a.Push(1);
            a.Push(2);
            a.Push(3);
            a.Push(4);

            a.Push(10);

            a.Rollback(2);
            a.BackupRollback();

            Console.WriteLine( a.Pop());

        }
    }
}
