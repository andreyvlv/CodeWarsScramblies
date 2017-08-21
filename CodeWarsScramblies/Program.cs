using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsScramblies
{
    class Program
    {
        static void Main(string[] args)
        {
            bool scrmbl = Scramble("rkqodlw", "world");
            Console.WriteLine(scrmbl);
            Console.ReadLine();
        }

        public static bool Scramble(string str1, string str2)
        {
            bool scrmbl = false;
            Dictionary<char, int> dict1 = new Dictionary<char, int>();
            Dictionary<char, int> dict2 = new Dictionary<char, int>();
            Dictionary<char, int> resultDict = new Dictionary<char, int>();
            foreach (var letter in str1.Distinct().ToArray())
            {
                var count = str1.Count(chr => chr == letter);
                dict1.Add(letter, count);
            }
            foreach (var letter in str2.Distinct().ToArray())
            {
                var count = str2.Count(chr => chr == letter);
                dict2.Add(letter, count);
            }
            dict1 = dict1.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            dict2 = dict2.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (KeyValuePair<char, int> item in dict1)
            {
                foreach (KeyValuePair<char, int> item2 in dict2)
                {
                    if (item.Key == item2.Key & item.Value >= item2.Value)
                    {
                        resultDict.Add(item2.Key, item2.Value);
                    }
                }
            }
            if (Enumerable.SequenceEqual(resultDict, dict2))
            {
                scrmbl = true;
            }
            return scrmbl;
        }
    }
}
