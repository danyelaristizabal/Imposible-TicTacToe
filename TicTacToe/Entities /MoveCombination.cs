using System.Collections.Generic; 
namespace TicTacToe
{
    public class MoveCombination
    {
        internal List<int> Moves;
        int  firstMove, secondMove, thirdMove; 
        public MoveCombination(int _firstMove, int _secondMove, int _thirdMove)
        {
            Moves = new List<int>();
            firstMove = _firstMove;
            secondMove = _secondMove;
            thirdMove = _thirdMove; 
            Moves.Add(_firstMove);
            Moves.Add(_secondMove);
            Moves.Add(_thirdMove);
        }
    }
}
