using System.Collections.Generic; 
namespace TicTacToe
{
    // Wraps all the logic related to analisis of moves, uses moveCombination class, Blocking and Wining strategy to calculate the bestmove in each point of the game. 
    internal class Engine 
    {
        internal static readonly List<MoveCombination> winingCombinations =
        new List<MoveCombination> { new MoveCombination(1, 2, 3), new MoveCombination(4, 5, 6), 
        new MoveCombination(7, 8, 9), new MoveCombination(1, 5, 9),new MoveCombination(7, 5, 3), 
        new MoveCombination(1, 4, 7), new MoveCombination(2, 5, 8),new MoveCombination(3, 6, 9)}; 

        internal List<int> engineMoves = new List<int>();

        internal void ClearMoves() {
            engineMoves.Clear(); 
        } 
        internal static int CalculateBlock(int userMove1, int userMove2)
        {
            foreach (var combination in winingCombinations)
            {
                if (combination.CheckWiningCombination(userMove1, userMove2)) 
                {
                    return combination.CheckWiningMoveInCombination(userMove1, userMove2);
                }   
            }
            return 0; 
        }

        internal List<int[]> GetAllRiskyCombinationsOfTwo(List<int> myEngineMoves, List<int> playerMoves) 
        {
            var packagesOfRisk = new List<int[]>();
            for (int i = 0; i < playerMoves.Count -1; i++)
            {
                for (int j = i + 1; j < playerMoves.Count; j++)
                {
                  if(playerMoves[i] != playerMoves[j] && CheckCombination(playerMoves[i], playerMoves[j]) && !myEngineMoves.Contains(CalculateBlock(playerMoves[i], playerMoves[j])) )
                   packagesOfRisk.Add(new int[] { playerMoves[i], playerMoves[j] });
                }
            }
            return packagesOfRisk; 
        }

        internal static bool CheckCombination(int Move1, int Move2) {
            foreach (var combination in winingCombinations) 
            {
                if (combination.CheckWiningCombination(Move1, Move2))
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
                if (combination.CheckEqualityBetweenCombinations(playerCombination)) 
                {
                    return true;
                } 
            }
            return false;
        }

        internal int CalculateMove(Engine MyEngine, Player MyPlayer) 
        {
            if (MyEngine.GetAllRiskyCombinationsOfTwo(MyEngine.engineMoves, MyPlayer.PlayerMoves).Count > 0
                   && MyEngine.GetAllRiskyCombinationsOfTwo(MyEngine.engineMoves, MyPlayer.PlayerMoves).Count < 1)
            {
                return BlockingStrategy.WithAllCombinationsCalculateBlock(MyEngine.engineMoves, MyPlayer.PlayerMoves);
            }
            return WiningStrategy.CalculateWiningMove(MyEngine.engineMoves, MyPlayer.PlayerMoves);
        }
    }
}
