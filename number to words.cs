
using System;

class Program
{
    static string[] ones = {
        "", "one", "two", "three", "four",
        "five", "six", "seven", "eight", "nine"
    };

    static string[] teens = {
        "ten", "eleven", "twelve", "thirteen",
        "fourteen", "fifteen", "sixteen",
        "seventeen", "eighteen", "nineteen"
    };

    static string[] tens = {
        "", "", "twenty", "thirty", "forty",
        "fifty", "sixty", "seventy", "eighty", "ninety"
    };

    static string ConvertToWords(int number)
    {
        if (number == 10000)
            return "ten thousand";

        if (number < 10)
            return ones[number];

        if (number < 20)
            return teens[number - 10];

        if (number < 100)
        {
            return tens[number / 10] +
                (number % 10 != 0 ? " " + ones[number % 10] : "");
        }

        if (number < 1000)
        {
            return ones[number / 100] + " hundred" +
                (number % 100 != 0 ? " and " + ConvertToWords(number % 100) : "");
        }

        return ones[number / 1000] + " thousand" +
            (number % 1000 >= 100 ? " " + ConvertToWords(number % 1000) :
            number % 1000 > 0 ? " " + ConvertToWords(number % 1000) : "");
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter a whole number from 1 to 10,000 (or type 'exit' to quit):");

            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
                break;

            int number;

            if (int.TryParse(input, out number) && number >= 1 && number <= 10000)
            {
                Console.WriteLine("The number " + number +
                    " in words is: " + ConvertToWords(number));
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 10,000.");
            }
        }
    }
}
