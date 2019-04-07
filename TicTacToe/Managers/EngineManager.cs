using System;
using System.Collections.Generic;
using System.Linq; 
namespace TicTacToe
{
    public static class EngineManager
    {
        internal static int CalculateBlock(int userMove1, int userMove2)
        {
            foreach (var combination in Constants.winingCombinations)
            {
                if (CombinationManager.CheckWiningCombinationChance(combination, userMove1, userMove2))
                {
                    return CombinationManager.CheckWiningMoveInCombination(combination, userMove1, userMove2);
                }
            }
            return 0;
        }

        public static List<int[]> GetAllRiskyCombinationsOfTwo(List<int> myEngineMoves, List<int> playerMoves)
        {
            var packagesOfRisk = new List<int[]>();
            for (int i = 0; i < playerMoves.Count - 1; i++)
            {
                for (int j = i + 1; j < playerMoves.Count; j++)
                {
                    if (playerMoves[i] != playerMoves[j] && CheckCombination(playerMoves[i], playerMoves[j]) && !myEngineMoves.Contains(CalculateBlock(playerMoves[i], playerMoves[j])))
                        packagesOfRisk.Add(new int[] { playerMoves[i], playerMoves[j] });
                }
            }
            return packagesOfRisk;
        }

        internal static bool CheckCombination(int Move1, int Move2) // Only used inside Engine 
        {
            foreach (var combination in Constants.winingCombinations)
            {
                if (CombinationManager.CheckWiningCombinationChance(combination, Move1, Move2))
                {
                    return true;
                }
            }
            return false;
        }

        internal static bool CheckCombinationWithWiningCombinations(MoveCombination playerCombination)
        {
            foreach (var combination in Constants.winingCombinations)
            {
                if (CombinationManager.CheckEqualityBetweenCombinations(combination, playerCombination))
                {
                    return true;
                }
            }
            return false;
        }

        internal static int CalculateMove(IPlayer MyEngine, IPlayer MyPlayer)
        {
            if (GetAllRiskyCombinationsOfTwo(MyEngine.Moves, MyPlayer.Moves).Count > 0
                   && GetAllRiskyCombinationsOfTwo(MyEngine.Moves, MyPlayer.Moves).Count < 1)
            {
                return BlockingStrategy.WithAllCombinationsCalculateBlock(MyEngine.Moves, MyPlayer.Moves);
            }
            return WiningStrategy.CalculateWiningMove(MyEngine.Moves, MyPlayer.Moves);
        }

        public static int ComputerChooseTable(Game MyGame) 
        {
            var calculated = CalculateMove(MyGame.MyEngine, MyGame.MyPlayer);
            int counter = 0; 
            while (!MyGame.MyEngine.Moves.Contains(calculated) && !MyGame.MyPlayer.Moves.Contains(calculated))
            {
                calculated = CalculateMove(MyGame.MyEngine, MyGame.MyPlayer);
                counter++; 
                if(counter > 6) 
                {
                    var rand = new Random(); 
                    List<int> filteredList = Constants.correctMoves.Where(i => !MyGame.MyEngine.Moves.Contains(i) && !MyGame.MyEngine.Moves.Contains(i)).ToList();
                    return filteredList[rand.Next(0, filteredList.Count())];
                }
            }
            return calculated;
        }

    }
}
