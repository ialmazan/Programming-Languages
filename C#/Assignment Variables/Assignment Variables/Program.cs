using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Ivan Almazan
Assignment: Assignment Variables
Summary:Summary: Arithmatic, variables and arrays.
Prompt the user for how many numbers they want to enter.
Load the numbers into an array or list.  (The numbers might be floating point.)
Find the average value, the median value and the sum.
Print the numbers entered back to the user, followed by the average, median and sum.
The average is the sum divided by the count of the numbers.
The median is the value that occurs in the middle, if we have 10 numbers, that will be the 5th number (or more precisely, the average of the 5th and 6th).
*/

namespace Assignment_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ivan Almazan \nAssignment: Assignment Variables \nSummary: Arithmatic, variables and arrays.\n");
            int size = 0;
            Console.Write("How many numbers would you like to enter? ");
            size = int.Parse(Console.ReadLine());
            Console.WriteLine();

            float[] numbers = new float[10];

            for (int i = 0; i < size; i++)
            {
                int j = i;
                Console.Write("What number would you like to enter for number " + ++j + ": ");
                numbers[i] = float.Parse(Console.ReadLine());
            }

            for (int i = 0; i < size; i++)
            {
                if (i == 0)
                {
                    Console.Write("\nYou entered ");
                    Console.Write(numbers[i]);
                }
                else if (i == (size-1))
                {
                    Console.Write(", " + numbers[i] + ".");
                }
                else
                {
                    Console.Write(", " + numbers[i]);
                }
            }

            Console.WriteLine("\nThe Average is " + numbers.Average());

            if (size % 2 == 0)
            {
                Array.Sort(numbers);
                float mid1 = numbers[(size / 2) -1];
                float mid2 = numbers[(size / 2)];
                float median = (mid1 + mid2) / 2;
                Console.WriteLine("The Median is " + median);
            }
            else
            {
                Array.Sort(numbers);
                Console.WriteLine("The median is " + numbers[size/2]);
            }

            Console.WriteLine("The Sum is " + numbers.Sum());
            Console.ReadKey();
        }
    }
}

// Execution Output
/*
Ivan Almazan
Assignment: Assignment Variables
Summary: Arithmatic, variables and arrays.

How many numbers would you like to enter? 10

What number would you like to enter for number 1: 22.1
What number would you like to enter for number 2: 4
What number would you like to enter for number 3: 41
What number would you like to enter for number 4: 14
What number would you like to enter for number 5: 24.2
What number would you like to enter for number 6: 19
What number would you like to enter for number 7: 25
What number would you like to enter for number 8: 46
What number would you like to enter for number 9: 79
What number would you like to enter for number 10: 9

You entered 22.1, 4, 41, 14, 24.2, 19, 25, 46, 79, 9.
The Average is 28.33
The Median is 23.15
The Sum is 283.3
*/
