using System;
using System.Collections.Generic; 
namespace TicTacToe
{
    public class Engine
    {
        public static MoveCombination horizontal = new MoveCombination(1, 2, 3);
        public static MoveCombination horizontal2 = new MoveCombination(4, 5, 6);
        public static MoveCombination horizontal3 = new MoveCombination(7, 8, 9);
        public static MoveCombination vertical = new MoveCombination(1, 5, 9);
        public static MoveCombination vertical2 =  new MoveCombination(7, 5, 3);
        public static MoveCombination vertical3 = new MoveCombination(1, 4, 7);
        public static MoveCombination diagonal = new MoveCombination(2, 5, 8);
        public static MoveCombination diagonal2 = new MoveCombination(3, 6, 9);

        public static List<MoveCombination> winingCombinations = new List<MoveCombination> { horizontal, horizontal2, horizontal3,
                                                                                             vertical, vertical2, vertical3,diagonal, diagonal2}; 
        public static int[] corners = { 1, 3, 7, 9 };
        // public static List<bool> places = new List<bool> { true, true, true, true, true, true, true, true, true };
        public List<int> engineMoves;
        public Engine() {
            engineMoves = new List<int> { }; 
        }



        public static List<int[]> GetAllRiskyCombinationsOfTwo(List<int> engineMoves, List<int> playerMoves) {
            var packagesOfRisk = new List<int[]>();
            for (int i = 0; i < playerMoves.Count -1; i++)
            {
                var checking = playerMoves[i]; 
                for (int j = i + 1; j < playerMoves.Count; j++)
                {
                  if(checking != playerMoves[j] && CheckCombination(checking, playerMoves[j]) && !engineMoves.Contains(BlockingStrategy.CalculateBlock(checking, playerMoves[j])) )
                   packagesOfRisk.Add(new int[] { checking, playerMoves[j] });
                }
            }
            return packagesOfRisk; 
        }



        public static bool CheckCombination(int userMove1, int userMove2) {
            foreach (var combination in winingCombinations) 
            if (combination.CheckWiningCombination(userMove1, userMove2)) return true; 
            return false;
        }



        public static bool CheckCombinationWithWiningCombinations(MoveCombination playerCombination)
        {
            foreach (var combination in winingCombinations)
            {
                if (combination.CheckEqualityBetweenCombinations(playerCombination)) return true;
            }
            return false;
        }




        public int CalculateMove(Player myPlayer) {
            var caseSwitch = new int();

            caseSwitch = myPlayer.playerMoves.Count;

            if (myPlayer.playerMoves.Count == 0) caseSwitch = 1;
            if (myPlayer.playerMoves.Count == 2) caseSwitch = 2;
            if (myPlayer.playerMoves.Count == 3) caseSwitch = 3;
            switch (caseSwitch)
            {

                case 1:
                    engineMoves.Add(BlockingStrategy.FirstMove(myPlayer));
                    return engineMoves[0];

                case 2:
                    if (GetAllRiskyCombinationsOfTwo(engineMoves, myPlayer.playerMoves).Count > 0)
                    {
                        engineMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(engineMoves, myPlayer.playerMoves));
                        return engineMoves[1];
                    }
                    engineMoves.Add(WiningStrategy.CalculateWiningMove(engineMoves, myPlayer.playerMoves));
                    return engineMoves[1];

                case 3:
                    if (myPlayer.CheckWiningStatePlayer()) {
                        return 10;
                    }
                    if (GetAllRiskyCombinationsOfTwo(engineMoves, myPlayer.playerMoves).Count > 0 && GetAllRiskyCombinationsOfTwo(myPlayer.playerMoves, engineMoves).Count < 1)
                    {
                        engineMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(engineMoves, myPlayer.playerMoves));
                        return engineMoves[2];
                    }
                    engineMoves.Add(WiningStrategy.CalculateWiningMove(engineMoves, myPlayer.playerMoves));
                    return engineMoves[2];

                 case 4:
                    if (myPlayer.CheckWiningStatePlayer())
                    {
                        return 10;
                    }
                    if (GetAllRiskyCombinationsOfTwo(engineMoves, myPlayer.playerMoves).Count > 0 && GetAllRiskyCombinationsOfTwo(myPlayer.playerMoves, engineMoves).Count < 1)
                    {
                        engineMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(engineMoves, myPlayer.playerMoves));
                        return engineMoves[3];
                    }
                    engineMoves.Add(WiningStrategy.CalculateWiningMove(engineMoves, myPlayer.playerMoves));
                    return engineMoves[3];

              
            case 5:
                    if (myPlayer.CheckWiningStatePlayer())
                    {
                        return 10;
                    }
                    if (GetAllRiskyCombinationsOfTwo(engineMoves, myPlayer.playerMoves).Count > 0 && GetAllRiskyCombinationsOfTwo(myPlayer.playerMoves, engineMoves).Count < 1)
                    {
                        engineMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(engineMoves, myPlayer.playerMoves));
                        return engineMoves[4];
                    }
                    engineMoves.Add(WiningStrategy.CalculateWiningMove(engineMoves, myPlayer.playerMoves));
                    return engineMoves[4];
                  
             
                default:
                    return 13;
            }
        }
    }
}
