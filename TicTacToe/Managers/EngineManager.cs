using System;
using System.Collections.Generic;
namespace TicTacToe
{
    public static class EngineManager
    {
        internal static readonly List<MoveCombination> winingCombinations =
        new List<MoveCombination> { new MoveCombination(1, 2, 3), new MoveCombination(4, 5, 6),
        new MoveCombination(7, 8, 9), new MoveCombination(1, 5, 9),new MoveCombination(7, 5, 3),
        new MoveCombination(1, 4, 7), new MoveCombination(2, 5, 8),new MoveCombination(3, 6, 9)};

        internal static int CalculateBlock(int userMove1, int userMove2)
        {
            foreach (var combination in winingCombinations)
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
            foreach (var combination in winingCombinations)
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
            foreach (var combination in winingCombinations)
            {
                if (CombinationManager.CheckEqualityBetweenCombinations(combination, playerCombination))
                {
                    return true;
                }
            }
            return false;
        }

        internal static int CalculateMove(Engine MyEngine, Player MyPlayer)
        {
            if (GetAllRiskyCombinationsOfTwo(MyEngine.PlayerMoves, MyPlayer.PlayerMoves).Count > 0
                   && GetAllRiskyCombinationsOfTwo(MyEngine.PlayerMoves, MyPlayer.PlayerMoves).Count < 1)
            {
                return BlockingStrategy.WithAllCombinationsCalculateBlock(MyEngine.PlayerMoves, MyPlayer.PlayerMoves);
            }
            return WiningStrategy.CalculateWiningMove(MyEngine.PlayerMoves, MyPlayer.PlayerMoves);
        }

    }
}
