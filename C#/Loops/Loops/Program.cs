using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Ivan Almazan
Assignment: Loops
Summary: Loops and Factorials.
Write a program that finds the factorial for a given sequence of integers.
Ask the user for the starting value, then ask the user for the ending value.
Starting at the first number entered, display the factorial calculation and the result of the calculation on a line.
Do this for each value from the first number to the last number entered.
The factorial of a number n is = n * (n-1) * (n-2) * (n-3) ... * 1. 
Where the factorial of 0 is equal to 1. IE 5! = 5*4*3*2*1 = 120
*/

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int lower = 0;
            int upper = 0;
            int total = 1;

            Console.WriteLine("Ivan Almazan \nAssignment: Loops \nSummary:  Loops for factorials.\n");
            Console.WriteLine("Welcome to the factorial calculator.");

            Console.Write("Please enter lower bound: ");
            lower = int.Parse(Console.ReadLine());

            Console.Write("Please enter upper bound: ");
            upper = int.Parse(Console.ReadLine());

            Console.WriteLine("\nCalculating...");
            for (int i = lower; i <= upper; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("0!= 1");
                }
                else
                {
                    Console.Write(i + "!= ");
                    for (int j = i; j > 0; j--)
                    {
                        if (j != 1)
                        {
                            Console.Write(j + " * ");
                            total *= j;
                        }
                        else
                        {
                            Console.Write(j + " = ");
                            total *= j;
                        }
                    }
                    Console.WriteLine(total);
                    total = 1;
                }
            }
            
            Console.WriteLine("\nGoodbye");
            Console.ReadKey();
        }
    }
}

/*
Ivan Almazan
Assignment: Loops
Summary:  Loops for factorials.

Welcome to the factorial calculator.
Please enter lower bound: 0
Please enter upper bound: 7

Calculating...
0!= 1
1!= 1 = 1
2!= 2 * 1 = 2
3!= 3 * 2 * 1 = 6
4!= 4 * 3 * 2 * 1 = 24
5!= 5 * 4 * 3 * 2 * 1 = 120
6!= 6 * 5 * 4 * 3 * 2 * 1 = 720
7!= 7 * 6 * 5 * 4 * 3 * 2 * 1 = 5040

Goodbye
 */

