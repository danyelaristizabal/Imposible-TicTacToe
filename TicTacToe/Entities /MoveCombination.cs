using System.Collections.Generic; 
namespace TicTacToe
{
    public class MoveCombination
    {
        public int Id { get; set; }
        internal List<int> Moves;
        private int FirstMove { get; set;  }
        private int SecondMove { get; set; }
        private int ThirdMove { get; set; }

        public MoveCombination(int _firstMove, int _secondMove, int _thirdMove)
        {
            Moves = new List<int>();
            FirstMove = _firstMove;
            SecondMove = _secondMove;
            ThirdMove = _thirdMove; 
            Moves.Add(_firstMove);
            Moves.Add(_secondMove);
            Moves.Add(_thirdMove);
        }
    }
}
