using System;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] input = { "222333", "333333" };
            string pattern = @"^(\d)\1{2}(?!\1)(\d)\2{2}";

            foreach (var item in input)
            {
                if (Regex.IsMatch(item, pattern))
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadKey();
        }
    }
}
