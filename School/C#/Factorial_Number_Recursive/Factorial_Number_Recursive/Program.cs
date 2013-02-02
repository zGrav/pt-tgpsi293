using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factorial_Number_Recursive
{
    class Program
    {

        private static int number;
        //private static int result = 1; low limit because of int? using long to see
        private static long result = 1; // better but still has a low number limit, gotta speak with teacher.

        // recursive ?
        public long fact(int number)
        {
            // 1st attempt

            //if (number == 1) return 1;
            //result = fact(number - 1) * number;
            //return result;

            return (number > 1) ? result = fact(number - 1) * number : 1 ;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Insert a number to get it's factorial.");
            number = int.Parse(Console.ReadLine());

            Program test = new Program();
            Console.WriteLine(test.fact(number));
            Console.ReadLine();
        }
    }
}
