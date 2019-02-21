using System;
using System.Collections.Generic; 
namespace TicTacToe
{
    public static class BlockingStrategy
    {
        public static int FirstMove(Player myPlayer)
        {
            if (myPlayer.playerMoves[0] == 5)
            {
                var Rand = new Random();
                return Engine.corners[Rand.Next(0, Engine.corners.Length)];
            }
            return 5;
        }

        public static List<MoveCombination> FindingMovesToBlock(List<int> engineMoves, List<int> playerMoves) {
            var combinationsLeft = new List<MoveCombination> { };

            foreach (var combination in Engine.winingCombinations)
            {
                for (int i = 0; i < playerMoves.Count - 1 ; i++)
                {
                    if (combination.combination.Contains(playerMoves[i]) && combination.combination.Contains(playerMoves[i + 1]))
                       combinationsLeft.Add(combination);
                    if((playerMoves.Count + 1 )%3 ==  0 && combination.combination.Contains(playerMoves[i]) && combination.combination.Contains(playerMoves[i + 2])) // this shit is not working 
                    combinationsLeft.Add(combination);
                }   
            }
            return combinationsLeft; 
        }

        public static int CalculateBlock( int userMove1, int userMove2)
        {
            var result = new int();

            foreach (var combination in Engine.winingCombinations)
            {
                if (combination.CheckWiningCombination(userMove1, userMove2))
                    result = combination.CheckWiningMoveInCombination(userMove1, userMove2);
            }
            return result;
        }


    }
}
