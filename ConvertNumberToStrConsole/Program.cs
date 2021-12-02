using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConvertNumberToStrConsole
{
    internal class Program
    {

        private static string[] unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static string[] tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static string[] numOfZerosMap = new[] {"hundred", "thousand", "million", "billion"};

        static void Main(string[] args)
        {
            // 532611301
            // five hundred thirty two million six hundred eleven thousand three hundred one

            var number = 532611301;
            Console.WriteLine(NumberToWords(number));
        }

        public static string NumberToWords(long number)
        {
            string words = "";
            
            if ((number / 1000000000) > 0)
            {
                words += $"{NumberToWords(number / 1000000000)} {numOfZerosMap[3]} ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += $"{NumberToWords(number / 1000000)} {numOfZerosMap[2]} ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += $"{NumberToWords(number / 1000)} {numOfZerosMap[1]} ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += $"{NumberToWords(number / 100)} {numOfZerosMap[0]} ";
                number %= 100;
            }

            if (number > 0)
            {
                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += $" {unitsMap[number % 10]}";
                }
            }

            return words;
        }
    }
}
