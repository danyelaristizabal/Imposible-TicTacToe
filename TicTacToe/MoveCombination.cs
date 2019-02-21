using System;
using System.Collections.Generic; 
namespace TicTacToe
{
    public class MoveCombination
    {
        public List<int> combination;

        public MoveCombination(int _firstMove, int _secondMove, int _thirdMove)
        {
            combination = new List<int> { };
            combination.Add(_firstMove);
            combination.Add(_secondMove);
            combination.Add(_thirdMove);
        }

        public bool CheckWiningCombination(int userMove1, int userMove2)
        {
            var counter = new int(); 
            foreach (var move in combination)
            {
                if (userMove1 == move || move == userMove2)  counter++ ;
                if (counter == 2) return true;
            }
            return false;
        }

        public int CheckWiningMoveInCombination(int userMove1, int userMove2) {
            var result = new int(); 
            foreach (var move in combination)
            {
                if (userMove1 != move || move != userMove2) {
                    result = move;
                } 
            }
            return result;
        }

        public bool CheckEqualityBetweenCombinations(MoveCombination combinationBeingChecked)
        {
            if (combination.Contains(combinationBeingChecked.combination[0]) && combination.Contains(combinationBeingChecked.combination[1]) && combination.Contains(combinationBeingChecked.combination[2])) 
                return true;
            return false; 
        }

    }
}
