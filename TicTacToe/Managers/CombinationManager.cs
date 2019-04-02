using System;
namespace TicTacToe
{
    public static class CombinationManager
    {
        internal bool CheckWiningCombination(MoveCombination MyCombination, int userMove1, int userMove2)
        {
            var counter = new int();
            foreach (var move in combination)
            {
                if (userMove1 == move || move == userMove2)
                {
                    counter++;
                }
                if (counter == 2)
                {
                    return true;
                }
            }
            return false;
        }

        internal int CheckWiningMoveInCombination(int userMove1, int userMove2)
        {
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
