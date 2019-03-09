using System;
using System.Collections.Generic; 
namespace TicTacToe
{
    // Wraps all the logic behind analizing the player and calculate a blocking move when is needed. 
     static class BlockingStrategy
    {
        private static readonly int[] corners = { 1, 3, 7, 9 };
        public static int FirstMove(Player myPlayer)
         {

            if (myPlayer.PlayerMoves[0] == 5)
            {
                var Rand = new Random();
                return corners[Rand.Next(0, corners.Length)];
            }
            return 5;
         }
         static bool ThereIsANeedToBlock(List<int> engineMoves, List<int> playerMoves ) 
         {
            if (Engine.GetAllRiskyCombinationsOfTwo(engineMoves, playerMoves).Count > 0) return true;
            return false; 
         } 
         public static int WithAllCombinationsCalculateBlock(List<int> engineMoves, List<int> playerMoves) 
         {
            List<int> blocks = new List<int>(); 
            foreach (var combination in Engine.GetAllRiskyCombinationsOfTwo(engineMoves, playerMoves))
            {
                if (!engineMoves.Contains(Engine.CalculateBlock(combination[0], combination[1])))
                   blocks.Add(Engine.CalculateBlock(combination[0], combination[1]));
            }
            var rand = new Random();
            return blocks[rand.Next(0, blocks.Count)];
         }
    }
}
