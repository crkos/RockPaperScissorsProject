namespace RockPaperScissorsProject
{
    internal class Rules
    {
        private readonly string[] _moves;
        private readonly Dictionary<string, int> _moveIndex;

        public Rules(string[] moves)
        {
            _moves = moves;
            _moveIndex = moves.Select((move, index) => new { move, index })
                              .ToDictionary(x => x.move, x => x.index);
        }

        public int DetermineOutcome(string userMove, string computerMove)
        {
            int userIndex = _moveIndex[userMove];
            int computerIndex = _moveIndex[computerMove];

            int totalMoves = _moves.Length;
            int halfMoves = totalMoves / 2;

            int result = Math.Sign((computerIndex - userIndex + halfMoves + totalMoves) % totalMoves - halfMoves);

            return result; // 1 = User wins, 0 = Draw, -1 = User loses
        }

    }
}
