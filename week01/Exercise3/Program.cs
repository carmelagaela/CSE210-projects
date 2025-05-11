using System;

class Program
{
    static void Main(string[] args)
    {
        // I added loop into the code
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Generate a new magic number for each round
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            // Track the number of guesses
            int guessCount = 0;

            Console.WriteLine("I have chosen a number between 1 and 100.");

            //Main guessing Loop
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! It took you {guessCount} guesses.");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing!");
    }
}
