using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Двусвязный_список_9_задач
{
    class TextFile
    {
        public LinkedList<int> count = new LinkedList<int>();
        private string[] lines;

        public TextFile(string path)
        {
            string text = File.ReadAllText(path);
            lines = text.Split("\n");
        }

        public LinkedList<int> GetCountOfCharInLines()
        {
            for (int i = 0; i < lines.Length; i++)
            {
                count.AddLast(lines[0].Length);
            }

            return count;
        }
    }
}
