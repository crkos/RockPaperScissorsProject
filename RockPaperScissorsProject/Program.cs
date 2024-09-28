using RockPaperScissorsProject;

namespace RockPaperScissorsGame
{
    public class Game
    {
        private static void Main(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0 || args.Distinct().Count() != args.Length)
            {
                Console.WriteLine("Error: Please provide an odd number of unique move names (minimum 3).");
                Console.WriteLine("Example: Program.exe/dotnet run rock Spock paper lizard scissors");
                return;
            }

           

            var moves = args.ToArray();
            var rules = new Rules(moves);

            var key = KeyGen.GenerateRandomKey();
            var computerMoveIndex = new Random().Next(moves.Length);
            var computerMove = moves[computerMoveIndex];
            var hmac = HmacUtil.ComputeHmac(computerMove, key);

            Console.WriteLine($"HMAC: {hmac}");

            ShowMenu(moves);

            string userInput;
            while (true)
            {
                Console.Write("Enter your move: ");
                userInput = Console.ReadLine().Trim();

                if (userInput == "0")
                    return;
                if (userInput == "?")
                {
                    TableGenerator.GenerateHelpTable(moves, rules);
                    continue;
                }

                if (int.TryParse(userInput, out int userChoice) && userChoice > 0 && userChoice <= moves.Length)
                {
                    var userMove = moves[userChoice - 1];
                    Console.WriteLine($"Your move: {userMove}");
                    Console.WriteLine($"Computer move: {computerMove}");

                    var result = rules.DetermineOutcome(userMove, computerMove);
                    switch (result)
                    {
                        case 0:
                            Console.WriteLine("It's a draw!");
                            break;
                        case 1:
                            Console.WriteLine("You win!");
                            break;
                        case -1:
                            Console.WriteLine("You lose!");
                            break;
                    }

                    Console.WriteLine($"HMAC key: {key}");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number corresponding to a move or '0' to exit or '?' for help.");
                }
            }
        }

        private static void ShowMenu(string[] moves)
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < moves.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {moves[i]}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }
    }
}
