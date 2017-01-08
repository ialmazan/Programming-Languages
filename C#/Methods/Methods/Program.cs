using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Ivan Almazan
Assignment: Methods
Summary: Methods, overloading, optional parameters.
Write a program that will analyze text.
Write a function that will take a string parameter with "Hello" as the default value for the optional parameter, this function will count the number of words in the string.
Assume that a word is identified by a single space character. The return is the count of words.
Overload the above function by allowing it to take an array of strings. (There must be two separate functions.)
Write a function that will count the number of vowels in a string. The return is the count of vowels, case-insensitive.
Create a menu system similar to the sample output. When at the bottom of each menu level, continue to perform the same operation until the user inputs the escape sequence.
i.e. -1
*/

namespace Methods
{
    class Program
    {
        static int count = 0;
        static string builder = " ";
        const string vowels = "aeiou";
        static string[] stringArray;

        static void parentMenu()
        {
            Console.WriteLine("\nMain Menu");
            Console.WriteLine("Choose from the following:");
            Console.WriteLine("1. Word counting.");
            Console.WriteLine("2. Vowel counting.");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your selection: ");
            builder = Console.ReadLine();
            Console.WriteLine();

            if (builder == "1")
                wordMenu();
            else if (builder == "2")
                vowelMenu();
            else if (builder == "3")
                Console.WriteLine("Goodbye.");
            else
            {
                Console.WriteLine("I'm sorry, could you please enter your selection again.");
                parentMenu();
            }
        }

        static void wordMenu()
        {
            Console.WriteLine("\nWord Counter Menu");
            Console.WriteLine("Choose from the following:");
            Console.WriteLine("1. Count the words in one sentence.");
            Console.WriteLine("2. Count the words in a paragraph.");
            Console.WriteLine("3. Main Menu");
            Console.Write("Enter your selection: ");
            builder = Console.ReadLine();
            Console.WriteLine();

            if (builder == "1")
                oneSentenceArray();
            else if (builder == "2")
                paragraphArray();
            else if (builder == "3")
                parentMenu();
            else
            {
                Console.WriteLine("I'm sorry, could you please enter your selection again.");
                wordMenu();
            }

        }

        static void vowelMenu()
        {
            Console.WriteLine("Vowel Counting Menu");
            Console.WriteLine("Choose from the following:");
            Console.WriteLine("1. Count vowels.");
            Console.WriteLine("2. Main Menu");
            Console.Write("Enter your selection: ");
            builder = Console.ReadLine();
            Console.WriteLine();

            if (builder == "1")
                vowelCounter();
            else if (builder == "2")
                parentMenu();
            else
            {
                Console.WriteLine("I'm sorry, could you please enter your selection again.");
                vowelMenu();
            }
        }

        static void oneSentenceArray()
        {
            count = 0;
            Console.Write("Enter a sentence (q to quit, d for default): ");
            builder = Console.ReadLine();
            if (builder == "q" || builder == "Q")
                wordMenu();
            else if (builder == "d" || builder == "D")
                countWords();
            else
            {
                stringArray = builder.Split(' ');
                countWords(stringArray);
            }
        }

        static void paragraphArray()
        {
            count = 0;
            Console.WriteLine("Enter several sentences, when done, enter q by itself on the last line.");
            builder = Console.ReadLine();
            if (builder == "q" || builder == "Q")
            {
                wordMenu();
            }
            else
            {
                stringArray = builder.Split(' ');
                countWordsParagraph(stringArray);
            }
        }

        static void countWords(string defaultString = "hello")
        {
            Console.WriteLine("There is 1 word in that sentence.");
            oneSentenceArray();
        }

        static void countWords(string[] stringArray)
        {   
            foreach(string s in stringArray)
            {
                count++;
            }

            Console.WriteLine("There are " + count + " words in that sentence.");
            oneSentenceArray();
        }

        static void countWordsParagraph(string[] stringArray)
        {
            if (builder == "q" || builder == "Q")
            {
                Console.WriteLine("There are " + count + " words in that paragraph.");
                Console.WriteLine();
                paragraphArray();
            }
            else
            {
                foreach (string s in stringArray)
                {
                    count++;
                }
                builder = Console.ReadLine();
                stringArray = builder.Split(' ');
                countWordsParagraph(stringArray);
            }
        }


        static void vowelCounter()
        {
            count = 0;
            Console.Write("Please enter some text to count the vowels (q to quit): ");
            builder = Console.ReadLine();
            if (builder == "q" || builder == "Q")
                vowelMenu();
            else
            {
                count = builder.Count(vowel => vowels.Contains(char.ToLowerInvariant(vowel)));
                Console.WriteLine("There are " + count + " vowels in that text.");
                Console.WriteLine();
                vowelCounter();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ivan Almazan \nAssignment: Methods \nSummary: Methods, overloading, optional parameters.");
            parentMenu();
            Console.ReadKey();
        }
    }
}

// Execution OutPut
/* 
Ivan Almazan
Assignment: Methods
Summary: Methods, overloading, optional parameters.

Main Menu
Choose from the following:
1. Word counting.
2. Vowel counting.
3. Exit
Enter your selection: 1


Word Counter Menu
Choose from the following:
1. Count the words in one sentence.
2. Count the words in a paragraph.
3. Main Menu
Enter your selection: 1

Enter a sentence (q to quit, d for default): Hello world, how are you today?
There are 6 words in that sentence.
Enter a sentence (q to quit, d for default): I'm bored today.
There are 3 words in that sentence.
Enter a sentence (q to quit, d for default): d
There is 1 word in that sentence.
Enter a sentence (q to quit, d for default): q

Word Counter Menu
Choose from the following:
1. Count the words in one sentence.
2. Count the words in a paragraph.
3. Main Menu
Enter your selection: 2

Enter several sentences, when done, enter q by itself on the last line.
Hello, how are you?
I'm fine, and you?
Just fine. just fine.
q
There are 12 words in that paragraph.

Enter several sentences, when done, enter q by itself on the last line.
q

Word Counter Menu
Choose from the following:
1. Count the words in one sentence.
2. Count the words in a paragraph.
3. Main Menu
Enter your selection: 3


Main Menu
Choose from the following:
1. Word counting.
2. Vowel counting.
3. Exit
Enter your selection: 2

Vowel Counting Menu
Choose from the following:
1. Count vowels.
2. Main Menu
Enter your selection: 1

Please enter some text to count the vowels (q to quit): Hello Abe, what are you
up to today?
There are 13 vowels in that text.

Please enter some text to count the vowels (q to quit): q
Vowel Counting Menu
Choose from the following:
1. Count vowels.
2. Main Menu
Enter your selection: 2


Main Menu
Choose from the following:
1. Word counting.
2. Vowel counting.
3. Exit
Enter your selection: 3

Goodbye.
*/
