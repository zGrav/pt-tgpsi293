using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factorial_Number
{
    class Program
    {

        private static int number;
        //private static int result = 1; low limit because of int? using long to see
        private static long result = 1; // better but still has a low number limit, gotta speak with teacher.

        private static void do_Math(long number)
        {

            if (number <= 0)
            {
                Console.WriteLine("Cannot use that number as a factorial. Program terminated.");
                Console.ReadLine();
            }

            for (int i = 1; i <= number; i++)
            {
                result = result * i;
            }

            Console.WriteLine("Result: " + result);
            Console.ReadLine();
        }

      private static void do_Read()
        {
            Console.WriteLine("Insert a number to get it's factorial.");
            number = int.Parse(Console.ReadLine());
            do_Math(number);
        }

       public static void Main(string[] args)
        {
            do_Read();
        }
    }
}
