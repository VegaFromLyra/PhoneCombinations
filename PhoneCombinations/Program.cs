using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ebay problems: Given a number, find all possible string combinations represented by that number
// So say 1 - a, b, c and 2 - d, e, f then 12 will be ad, ae, af, bd, be, bf etc

namespace PhoneCombinations
{
    class Program
    {
        static public Dictionary<char, string> table = new Dictionary<char, string>();

        static void Main(string[] args)
        {

            table.Add('2', "abc");
            table.Add('3', "def");
            table.Add('4', "ghi");

            try
            {
                List<string> result = GetCombinations(234);

                foreach (string resultComb in result)
                {
                    Console.WriteLine(resultComb);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static List<string> GetCombinations(int number)
        {
            StringBuilder sb = new StringBuilder("");
            return GetCombinations(number.ToString(), sb);
        }

        static List<string> GetCombinations(string number, StringBuilder prefix)
        {
            List<string> output = new List<string>();

            if (number.Length == 0)
            {
                output.Add(prefix.ToString());
                return output;
            }

            string chars = table[number[0]];

            string rest = number.Substring(1, number.Length - 1);

            foreach (char character in chars)
            {
                prefix.Append(character);
                output.AddRange(GetCombinations(rest, prefix));
                prefix.Remove(prefix.Length - 1, 1);
            }

            return output;
        }
    }
}
