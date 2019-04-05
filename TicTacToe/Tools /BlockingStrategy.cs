using System;
using System.Collections.Generic; 
namespace TicTacToe
{
    // Wraps all the logic behind analyzing the player and calculate a blocking move when is needed. 
    internal static class BlockingStrategy
    {
        internal static int FirstMove(IPlayer myPlayer)
         {
            if (myPlayer.Moves[0] == 5)
            { 
                var Rand = new Random();
                return Constants.corners[Rand.Next(0, Constants.corners.Count)];
            }
            return 5;
         }

         internal static bool ThereIsANeedToBlock(List<int> engineMoves, List<int> playerMoves ) 
         {
            return EngineManager.GetAllRiskyCombinationsOfTwo(engineMoves, playerMoves).Count > 0;
         }
         internal static int WithAllCombinationsCalculateBlock(List<int> engineMoves, List<int> playerMoves) 
         {
            List<int> blocks = new List<int>(); 
            foreach (var combination in EngineManager.GetAllRiskyCombinationsOfTwo(engineMoves, playerMoves))
            {
                if (!engineMoves.Contains(EngineManager.CalculateBlock(combination[0], combination[1])))
                {
                   blocks.Add(EngineManager.CalculateBlock(combination[0], combination[1]));
                }
            }
            var rand = new Random();
            return blocks[rand.Next(0, blocks.Count)];
         }
    }
}
