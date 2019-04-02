using System;
namespace TicTacToe
{
    public static class CombinationManager
    {
        public static bool CheckWiningCombinationChance(MoveCombination combination, int userMove1, int userMove2)
        {
            var counter = new int();
            foreach (var move in combination.Moves)
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

        public static int CheckWiningMoveInCombination(MoveCombination combination, int userMove1, int userMove2)
        {
            var result = new int();
            foreach (var move in combination.Moves)
            {
                if (userMove1 != move && move != userMove2)
                {
                    result = move;
                }
            }
            return result;
        }

        public static bool CheckEqualityBetweenCombinations(MoveCombination firstCombination, MoveCombination secondCombination)
        {
            return firstCombination.Moves.Contains(secondCombination.Moves[0])
            && firstCombination.Moves.Contains(secondCombination.Moves[1])
                && firstCombination.Moves.Contains(secondCombination.Moves[2]);
        }
    }
}
