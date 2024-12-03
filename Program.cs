namespace HangmanTwo
{
    internal class Program
    {
        static void zeroLives()
        {
            Console.WriteLine("---------");
            Console.WriteLine("  |    | ");
            Console.WriteLine("  0    | ");
            Console.WriteLine(" /|\\  | ");
            Console.WriteLine(" /|\\  | ");
            Console.WriteLine("     ====");
        }
        static void Main(string[] args)
        {
            int lives;
            bool playAgain = true;
            string answer;
            
            while (playAgain)
            {
                Console.Write("Player 1 choose a word for Player 2: ");
                string wordToGuess = Console.ReadLine().ToLower();
                Console.Clear();
                char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();
                List<char> incorrectGuesses = new List<char>();

                lives = 6;
                answer = "";

                while (lives > 0 && new string(guessedWord) != wordToGuess)
                {
                    Console.WriteLine("Word to guess: " + new string(guessedWord));
                    Console.WriteLine("Incorrect guesses: " + string.Join(", ", incorrectGuesses));
                    Console.WriteLine($" Lives remaining: {lives}");
                    Console.Write("Enter a letter: ");
                    char guess = Console.ReadLine().ToLower()[0];

                    if (wordToGuess.Contains(guess))
                    {
                        for (int i = 0; i < guessedWord.Length; i++)
                        {
                            if (wordToGuess[i] == guess)
                            {
                                guessedWord[i] = guess;
                            }
                        }
                    }
                    else
                    {
                        if (!incorrectGuesses.Contains(guess))
                        {
                            incorrectGuesses.Add(guess);
                            lives--; 
                        }
                    }
                }
                if (new string(guessedWord) == wordToGuess)
                {
                    Console.WriteLine($"Congratulations! You've guessed the word: {wordToGuess}");
                }
                else
                {
                    zeroLives();
                    Console.WriteLine($"You lost! The word to guess was: {wordToGuess}");
                }

                Console.WriteLine("Do you want to play again?: ");
                answer = Console.ReadLine().ToUpper();

                if (answer == "Y" || answer == "YES")
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                }
            }
        }
    }
}
