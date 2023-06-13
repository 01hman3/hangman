using System;

namespace HangmanGame
{
    class Program
    {
        static string[] wordList = { "houssaine", "othmane" };
        static string selectedWord;
        static string hiddenWord;
        static int attemptsLeft = 6;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!");

            DisplayInstructions();

            InitializeGame();

            while (true)
            {
                DisplayGameInfo();

                string playerGuess = GetPlayerGuess();
                bool isCorrectGuess = CheckGuess(playerGuess);

                if (isCorrectGuess)
                {
                    Console.WriteLine("Correct guess!");
                }
                else
                {
                    Console.WriteLine("Incorrect guess!");
                    attemptsLeft--;
                }

                DrawHangman();

                if (IsGameOver())
                {
                    Console.WriteLine("Game Over!");
                    Console.WriteLine($"The word was: {selectedWord}");
                    break;
                }

                if (IsGameWon())
                {
                    Console.WriteLine("Congratulations! You won!");
                    break;
                }
            }

            Console.ReadLine();
        }

        static void InitializeGame()
        {
            Random random = new Random();
            selectedWord = wordList[random.Next(0, wordList.Length)];
            hiddenWord = new string('_', selectedWord.Length);
        }

        static void DisplayGameInfo()
        {
            Console.WriteLine($"Attempts Left: {attemptsLeft}");
            Console.WriteLine("Hidden Word: " + hiddenWord);
        }

        static string GetPlayerGuess()
        {
            Console.Write("Enter your guess: ");
            string playerGuess = Console.ReadLine();
            Console.WriteLine();
            return playerGuess;
        }

        static bool CheckGuess(string playerGuess)
        {
            if (playerGuess.Length == 1)
            {
                return CheckLetterGuess(playerGuess);
            }
            else
            {
                return CheckWordGuess(playerGuess);
            }
        }

        static bool CheckLetterGuess(string letter)
        {
            bool isCorrectGuess = false;

            for (int i = 0; i < selectedWord.Length; i++)
            {
                if (selectedWord[i] == letter[0])
                {
                    hiddenWord = hiddenWord.Remove(i, 1).Insert(i, letter);
                    isCorrectGuess = true;
                }
            }

            return isCorrectGuess;
        }

        static bool CheckWordGuess(string word)
        {
            if (word.Equals(selectedWord, StringComparison.OrdinalIgnoreCase))
            {
                hiddenWord = selectedWord;
                return true;
            }

            return false;
        }

        static bool IsGameOver()
        {
            return attemptsLeft <= 0;
        }

        static bool IsGameWon()
        {
            return hiddenWord.Equals(selectedWord, StringComparison.OrdinalIgnoreCase);
        }

        static void DrawHangman()
        {
            Console.WriteLine();

            switch (attemptsLeft)
            {
                case 6:
                    Console.WriteLine("  ________");
                    Console.WriteLine("  |      |");
                    Console.WriteLine("         |");
                    Console.WriteLine("         |");
                    Console.WriteLine("         |");
                    Console.WriteLine("         |");
                    Console.WriteLine("_________|");
                    break;
                case 5:
                    Console.WriteLine("  ________");
                    Console.WriteLine("  |      |");
                    Console.WriteLine("  O      |");
                    Console.WriteLine("         |");
                    Console.WriteLine("         |");
                    Console.WriteLine("         |");
                    Console.WriteLine("_________|");
                    break;
                case 4:
                    Console.WriteLine("  ________");
                    Console.WriteLine("  |      |");
                    Console.WriteLine("  O      |");
                    Console.WriteLine("  |      |");
                    Console.WriteLine("         |");
                    Console.WriteLine("         |");
                    Console.WriteLine("_________|");
                    break;
                case 3:
                    Console.WriteLine("  ________");
                    Console.WriteLine("  |      |");
                    Console.WriteLine("  O      |");
                    Console.WriteLine(" /|      |");
                    Console.WriteLine("         |");
                    Console.WriteLine("         |");
                    Console.WriteLine("_________|");
                    break;
                case 2:
                    Console.WriteLine("  ________");
                    Console.WriteLine("  |      |");
                    Console.WriteLine("  O      |");
                    Console.WriteLine(" /|\\     |");
                    Console.WriteLine("         |");
                    Console.WriteLine("         |");
                    Console.WriteLine("_________|");
                    break;
                case 1:
                    Console.WriteLine("  ________");
                    Console.WriteLine("  |      |");
                    Console.WriteLine("  O      |");
                    Console.WriteLine(" /|\\     |");
                    Console.WriteLine(" / \\     |");
                    Console.WriteLine("         |");
                    Console.WriteLine("_________|");
                    break;
            }

            Console.WriteLine();
        }

        static void ResetGame()
        {
            attemptsLeft = 6;
            InitializeGame();
        }

        static void DisplayGameOutcome()
        {
            if (IsGameOver())
            {
                Console.WriteLine("Game Over!");
                Console.WriteLine($"The word was: {selectedWord}");
            }

            if (IsGameWon())
            {
                Console.WriteLine("Congratulations! You won!");
            }
        }

        static void DisplayInstructions()
        {
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. A word will be selected randomly.");
            Console.WriteLine("2. Guess the word by entering one letter at a time or the entire word.");
            Console.WriteLine("3. You have 6 attempts to guess the word correctly.");
            Console.WriteLine("4. If you guess a letter correctly, it will be revealed in the hidden word.");
            Console.WriteLine("5. If you guess the entire word correctly, you win!");
            Console.WriteLine("6. If you run out of attempts before guessing the word, you lose!");
            Console.WriteLine();
        }
    }
}
