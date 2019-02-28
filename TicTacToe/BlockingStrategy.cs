using System;
using System.Collections.Generic; 
namespace TicTacToe
{
    // Wraps all the logic behind analizing the player and calculate a blocking move when is needed. 
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

        public static bool ThereIsANeedToBlock(List<int> engineMoves, List<int> playerMoves ) {

            if (Engine.GetAllRiskyCombinationsOfTwo(engineMoves, playerMoves).Count > 0) return true;
            return false; 
        } 

        public static int WithAllCombinationsCalculateBlock(List<int> engineMoves, List<int> playerMoves) {
            List<int> blocks = new List<int>(); 
            foreach (var combination in Engine.GetAllRiskyCombinationsOfTwo(engineMoves, playerMoves))
            {
                if (!engineMoves.Contains(CalculateBlock(combination[0], combination[1])))
                   blocks.Add(CalculateBlock(combination[0], combination[1]));
              
            }
            var rand = new Random();

                        return blocks[rand.Next(0, blocks.Count)];
        }

        public static int CalculateBlock(int userMove1, int userMove2)
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
