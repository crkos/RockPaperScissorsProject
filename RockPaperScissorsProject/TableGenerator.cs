using Snork.AsciiTable;

namespace RockPaperScissorsProject
{
    internal class TableGenerator
    {
        public static void GenerateHelpTable(string[] moves, Rules rules)
        {
            if (moves == null || moves.Length == 0)
            {
                Console.WriteLine("No moves provided.");
                return;
            }

            if (rules == null)
            {
                Console.WriteLine("Rules object is null.");
                return;
            }

            var table = new AsciiTableGenerator("Moves table");

            string[] newMoves = new string[moves.Length + 1];
            newMoves[0] = "↓User/->PC";
            Array.Copy(moves, 0, newMoves, 1, moves.Length);

            table.SetCaptions(newMoves);
            

            table.SetCaption(0,"↓User/->PC");

            foreach (var move in moves)
            {
                var row = new List<string> { move };
                foreach (var otherMove in moves)
                {
                    var result = rules.DetermineOutcome(move, otherMove);
                    
                    row.Add(GetOutcomeString(result));
                }
                table.Add([.. row]);
            }

            if (table.GetRows().Count > 0)
            {
                Console.WriteLine(table.ToString());
            }
            else
            {
                Console.WriteLine("No outcomes were determined.");
            }
        }

        private static string GetOutcomeString(int result)
        {
            return result switch
            {
                0 => "Draw",
                1 => "Win",
                _ => "Lose",
            };
        }
    }
}
