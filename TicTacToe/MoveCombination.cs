using System.Collections.Generic; 
namespace TicTacToe
{
    //MoveCombination is an object that wraps up 3 moves represented by numbers. 
    //This class has 3 main methods that help analizing MoveCombination type of objects. 

    internal class MoveCombination
    {
        internal List<int> combination;
        int  firstMove, secondMove, thirdMove; 

        internal MoveCombination(int _firstMove, int _secondMove, int _thirdMove)
        {
            combination = new List<int>();
            firstMove = _firstMove;
            secondMove = _secondMove;
            thirdMove = _thirdMove; 
            combination.Add(_firstMove);
            combination.Add(_secondMove);
            combination.Add(_thirdMove);
        }

        internal void AddMove(int move) {
            if(!combination.Contains(move) && combination.Count < 3)
            {
                combination.Add(move); 
            }
        }

        internal bool CheckWiningCombination(int userMove1, int userMove2)
        {
            var counter = new int(); 
            foreach (var move in combination)
            {
                if (userMove1 == move || move == userMove2)
                {
                  counter++ ;
                }
                if (counter == 2)
                {
                 return true;
                }
            }
            return false;
        }

        internal int CheckWiningMoveInCombination(int userMove1, int userMove2) {
            var result = new int(); 
            foreach (var move in combination)
            {
                if (userMove1 != move && move != userMove2)
                {
                 result = move;
                }
            }
            return result;
        }

        internal bool CheckEqualityBetweenCombinations(MoveCombination combinationBeingChecked)
        {
            return combination.Contains(combinationBeingChecked.combination[0]) 
            && combination.Contains(combinationBeingChecked.combination[1]) 
                && combination.Contains(combinationBeingChecked.combination[2]);
        }
    }
}
