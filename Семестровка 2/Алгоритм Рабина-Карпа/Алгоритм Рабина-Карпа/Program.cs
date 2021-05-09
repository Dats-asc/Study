using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Алгоритм_Рабина_Карпа
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Input\Test";
            string information = "";
            for(int i = 1; i < 50; i++)
            {
                var time = new Stopwatch();
                string text = File.ReadAllText(path + i + ".txt").Split("\nРАЗДЕЛИТЕЛЬ\n")[0];
                string pattern = File.ReadAllText(path + i + ".txt").Split("\nРАЗДЕЛИТЕЛЬ\n")[1];
                string result;
                time.Start();
                result = Algorithm(text, pattern, Hash(pattern)).ToString();
                time.Stop();
                Console.WriteLine("Файл - " + i + "  Время - " + time.ElapsedMilliseconds + " ms  " + "   Длина текста - " + text.Length + "  Длина подстроки - " + pattern.Length);
                information += $"{time.ElapsedMilliseconds};{text.Length};{pattern.Length}\n";
            }
            File.WriteAllText(@"D:\RabinKarp.csv", information);


            static int Hash(string a)
            {
                int hash = a[0];
                for (int i = 1; i < a.Length; i++)
                {
                    hash += a[i] * (int)Math.Pow(10, i);
                }
                return hash;
            }

            static int Algorithm(string text, string pattern, int patternHash)
            {
                var results = new List<int>();
                for(int i = 0; i <= text.Length - pattern.Length; i++)
                {
                    if(Hash(text.Substring(i,pattern.Length)) == patternHash)
                    {
                        int count = 0;
                        for(int j = i; j < j + pattern.Length - 1; j++)
                        {
                            if(text[j] != pattern[count])
                            {
                                break;
                            }
                        }
                        results.Add(i);
                    }
                }
                return -1;
            }
        }
    }
}
