using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Двусвязный_список_9_задач
{
    class Facultet
    {
        public LinkedList<LinkedList<string>> facult = new LinkedList<LinkedList<string>>();

        public LinkedList<string> GetGroup(string[] names)
        {
            LinkedList<string> group = new LinkedList<string>();

            for (int i = 0; i < names.Length; i++)
            {
                group.AddLast(names[i]);
            }

            return group;
        }

        public LinkedList<LinkedList<string>> GetFacult(string[] allNames)
        {
            for (int i = 0; i < allNames.Length; i++)
            {
                facult.AddLast(GetGroup(allNames[i].Split(" ")));
            }

            return facult;
        }
    }
}
