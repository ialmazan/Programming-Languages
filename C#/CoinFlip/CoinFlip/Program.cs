using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Ivan Almazan
Assignment: Loops and Randoms
Summary:  Decisions and iteration, random numbers.
Ask the user if they want to play the game. If they respond postively, then ask them to guess heads or tails. If they correctly guess the coin flip indicate that they won the game and then ask them if they want to play again. The game will continue until the user responds that they do not wish to continue playing.
Keep track of each time the player guesses correctly or incorrectly and display their wins and losses. Also note that the user input is not case sensitive.
*/

namespace CoinFlip
{
    class Program
    {
        static int wins = 0;
        static int loses = 0;
        static string play = " ";
        static string choice = " ";
        static Random random = new Random();
        static int face = 0;

        static void playAgain(string play)
        {
            if (play == "Y" || play == "y")
            {
                Console.Write("\nGuess H for heads, T for tails. ");
                choice = Console.ReadLine();
                result(choice);
            }
            else if (play == "N" || play == "n")
            {
                Console.WriteLine("Thanks for playing, goodbye.");
            }
            else
            {
                Console.WriteLine("\nI'm sorry, I didn't get that, please enter Y for yes or N for No. ");
                Console.Write("Do you want to play? ");
                play = Console.ReadLine();
                playAgain(play);
            }

        }

        static void result(string choice)
        {
            face = random.Next(2);

            if ((choice == "H" || choice == "h") && face == 0)
            {
                wins++;
                Console.WriteLine("The coin landed heads, you won.");
                Console.WriteLine("Wins: " + wins + "\nLoses: " + loses + "\n");
                print();
            }
            else if ((choice == "T" || choice == "t") && face == 1)
            {
                wins++;
                Console.WriteLine("The coin landed tails, you won.");
                Console.WriteLine("Wins: " + wins + "\nLoses: " + loses + "\n");
                print();
            }
            else if ((choice == "H" || choice == "h") && face == 1)
            {
                loses++;
                Console.WriteLine("The coin landed tails, you lost.");
                Console.WriteLine("Wins: " + wins + "\nLoses: " + loses + "\n");
                print();
            }
            else if ((choice == "T" || choice == "t") && face == 0)
            {
                loses++;
                Console.WriteLine("The coin landed heads, you lost.");
                Console.WriteLine("Wins: " + wins + "\nLoses: " + loses + "\n");
                print();
            }
            else
            {
                Console.Write("\nI'm sorry, I didn't get that, guess H for heads or T for tails. ");
                choice = Console.ReadLine();
                result(choice);
            }
        }

        static void print()
        {
            Console.Write("Do you want to play again? ");
            play = Console.ReadLine();
            playAgain(play);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Ivan Almazan \nAssignment: Loops and Randoms \nSummary:  Decisions and iteration, random numbers.\n");
            Console.Write("Wins: " + wins + "\nLoses: " + loses + "\n\nDo you want to play? ");
            play = Console.ReadLine();
            playAgain(play);
            Console.ReadKey();

        }
    }
}

// Execution Output
/*
Ivan Almazan
Assignment: Loops and Randoms
Summary:  Decisions and iteration, random numbers.

Wins: 0
Loses: 0

Do you want to play? y

Guess H for heads, T for tails. h
The coin landed heads, you won.
Wins: 1
Loses: 0

Do you want to play again? Y

Guess H for heads, T for tails. T
The coin landed tails, you won.
Wins: 2
Loses: 0

Do you want to play again? y

Guess H for heads, T for tails. H
The coin landed tails, you lost.
Wins: 2
Loses: 1

Do you want to play again? n
Thanks for playing, goodbye.
*/
