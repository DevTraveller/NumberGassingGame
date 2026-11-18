using System;


namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {


            bool playAgain = true;

            do // Repeat the game at least once until the player chooses not to play again
            {
                Show(); // Method call: displays the menu and starts the game

                Console.WriteLine("");
                Console.Write(" Vill du spela igen? (ja/nej): ");


                bool validAnswer = false;

                while (!validAnswer)
                {
                    // Remove extra spaces and make the answer lowercase
                    string answer = Console.ReadLine()?.Trim().ToLower() ?? "";


                    if (answer == "ja")
                    {
                        playAgain = true;
                        validAnswer = true;
                    }
                    else if (answer == "nej")
                    {
                        playAgain = false;
                        validAnswer = true;
                    }
                    else
                    {
                        Console.Write(" Ogiltigt svar. Skriv ja eller nej: ");
                    }

                }


            } while (playAgain);
            Console.Clear();
            Console.WriteLine("     ==================================================");
            Console.WriteLine("    |                                                  |");
            Console.WriteLine("    |  ** Tack för att du spelade! Välkommen åter! **  |");
            Console.WriteLine("    |                                                  |");
            Console.WriteLine("     ==================================================");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        static void Show()
        {

            Console.Clear();
            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket?");
            Console.WriteLine();
            Console.WriteLine(" Välj svårighetnivå: ");
            Console.WriteLine("");
            Console.WriteLine("1. Lätt");
            Console.WriteLine("2. Mellan");
            Console.WriteLine("3. Svårt ");
            Console.WriteLine("4. Anpassad ");
            Console.WriteLine("");
            Console.Write("Skriv 1, 2, 3 eller 4: ");
            //Console.WriteLine("");


            bool validChoice = false;
            int number = 1;
            int attempt = 1;

            while (!validChoice)
            {


                string Choice = Console.ReadLine() ?? string.Empty;

                switch (Choice)
                {
                    case "1":
                        number = 10;
                        attempt = 6;
                        validChoice = true;
                        break;


                    case "2":
                        number = 25;
                        attempt = 5;
                        validChoice = true;
                        break;


                    case "3":
                        number = 50;
                        attempt = 3;
                        validChoice = true;
                        break;


                    case "4":
                        Console.Write("Vilket är det högsta talet du vill gissa? ");

                        // Repeat until the player enters a valid number greater than 1
                        while (!int.TryParse(Console.ReadLine(), out number) || number < 2)
                        {
                            Console.Write("  Ogiltigt, skriv ett tal störe än 1: ");
                        }

                        Console.Write("Hur många försök vill du ha? ");
                        while (!int.TryParse(Console.ReadLine(), out attempt) || attempt < 1)
                        {
                            Console.Write("  Ogiltigt, Skriv ett tal störe än 0: ");
                        }

                        validChoice = true;
                        break;


                    default:

                        Console.Write("  Ogiltigt val. välj 1, 2, 3 eller 4: ");
                        break;

                }




            }

            Console.Clear();

            // Instansering: creates a Random object
            Random random = new Random();
            int randomNumber = random.Next(1, number + 1); // Add 1 to unclude the highest possible number

            Console.WriteLine("");
            Console.WriteLine($"Jag tänker på ett nummer mellan 1 och {number},  Kan du gissa vilket? ");
            Console.WriteLine("");
            Console.WriteLine($"du får {attempt} försök");
            Console.WriteLine("");

            // Method call: passes the random number and attempts as arguments
            CheckGuess(randomNumber, attempt);


        }
        static void CheckGuess(int randomNumber, int attempt)

        {
            bool succeeded = false;


            for (int i = 1; i <= attempt; i++)
            {
                Console.Write($"Försök {i}: ");

                int input;

                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    //Console.WriteLine("");
                    Console.Write("  Ogiltigt, skriv ett tal: ");

                }
                if (input == randomNumber)
                {

                    Console.WriteLine("");
                    Console.WriteLine("    ****************************************************");
                    Console.WriteLine("   *                                                    *");
                    Console.WriteLine("   *            ** Wohoo! Du klarade det! **            *");
                    Console.WriteLine("   *                                                    *");
                    Console.WriteLine("    ***************************************************");
                    succeeded = true;
                    break;
                }
                else if (input < randomNumber)
                {

                    Console.WriteLine("     Tyvärr, du gissade för lågt!");
                    Console.WriteLine("");
                }
                else
                {

                    Console.WriteLine("     Tyvärr, du gissade för högt!");
                    Console.WriteLine("");
                }

            }

            if (!succeeded)
            {
                Console.WriteLine("    ========================================================================");
                Console.WriteLine(" ");
                Console.WriteLine($"         Game Over, du lyckades inte gissa talet på {attempt} försök!");
                Console.WriteLine(" ");
                Console.WriteLine("    =======================================================================");
                Console.WriteLine("");
                Console.WriteLine("");

            }


        }












    }
}
