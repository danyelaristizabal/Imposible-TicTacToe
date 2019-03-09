using System;
using System.Collections.Generic; 
namespace TicTacToe
{
    // Wraps all the logic related to analisis of moves, uses moveCombination class, Blocking and Wining strategy to calculate the bestmove in each point of the game. 
    public class Engine 
    {
        public static readonly List<MoveCombination> winingCombinations =
        new List<MoveCombination> { new MoveCombination(1, 2, 3), new MoveCombination(4, 5, 6), 
        new MoveCombination(7, 8, 9), new MoveCombination(1, 5, 9),new MoveCombination(7, 5, 3), 
        new MoveCombination(1, 4, 7), new MoveCombination(2, 5, 8),new MoveCombination(3, 6, 9)}; 

        private List<int> engineMoves;

        public Engine() 
        {
            engineMoves = new List<int> { }; 
        }

        public void ClearMoves() {
            engineMoves.Clear(); 
        } 

        public static int CalculateBlock(int userMove1, int userMove2)
        {
            var result = new int();
            foreach (var combination in winingCombinations)
            {
                if (combination.CheckWiningCombination(userMove1, userMove2))
                    result = combination.CheckWiningMoveInCombination(userMove1, userMove2);
            }
            return result;
        }

        public static List<int[]> GetAllRiskyCombinationsOfTwo(List<int> engineMoves, List<int> playerMoves) 
        {
            var packagesOfRisk = new List<int[]>();
            for (int i = 0; i < playerMoves.Count -1; i++)
            {
                for (int j = i + 1; j < playerMoves.Count; j++)
                {
                  if(playerMoves[i] != playerMoves[j] && CheckCombination(playerMoves[i], playerMoves[j]) && !engineMoves.Contains(CalculateBlock(playerMoves[i], playerMoves[j])) )
                   packagesOfRisk.Add(new int[] { playerMoves[i], playerMoves[j] });
                }
            }
            return packagesOfRisk; 
        }

        public static bool CheckCombination(int Move1, int Move2) {
            foreach (var combination in winingCombinations) 
            if (combination.CheckWiningCombination(Move1, Move2)) return true; 
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

        public string CalculateMove(Player myPlayer) 
        {

            var caseSwitch = new int();

            caseSwitch = myPlayer.PlayerMoves.Count;

            if (myPlayer.PlayerMoves.Count == 0) caseSwitch = 1;
            if (myPlayer.PlayerMoves.Count == 2) caseSwitch = 2;
            if (myPlayer.PlayerMoves.Count == 3) caseSwitch = 3;

            switch (caseSwitch)
            {

                 case 1:
                    engineMoves.Add(BlockingStrategy.FirstMove(myPlayer));
                    return $" Computer First move is: {engineMoves[0]} ";

                case 2:
                    if (GetAllRiskyCombinationsOfTwo(engineMoves, myPlayer.PlayerMoves).Count > 0)
                    {
                        engineMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(engineMoves, myPlayer.PlayerMoves));
                        return $" Computer Second move is: {engineMoves[1]} ";
                    }
                    engineMoves.Add(WiningStrategy.CalculateWiningMove(engineMoves, myPlayer.PlayerMoves));
                    return $" Computer Second move is: {engineMoves[1]} "; 

                 case 3:
                    if (myPlayer.CheckWiningState(myPlayer.PlayerMoves)) {
                        return "YOU WIN!";
                    }
                    if (GetAllRiskyCombinationsOfTwo(engineMoves, myPlayer.PlayerMoves).Count > 0
                     && GetAllRiskyCombinationsOfTwo(myPlayer.PlayerMoves, engineMoves).Count < 1)
                    {
                        engineMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(engineMoves, myPlayer.PlayerMoves));
                        return $" Computer Third move is: {engineMoves[2]} ";
                        if (myPlayer.CheckWiningState(engineMoves))
                        {
                            return $" Computer Third move is: {engineMoves[2]}, Haha, You loose";
                        }
                    }
                    engineMoves.Add(WiningStrategy.CalculateWiningMove(engineMoves, myPlayer.PlayerMoves));
                    if (myPlayer.CheckWiningState(engineMoves))
                    {
                        return $" Computer Third move is: {engineMoves[2]}, oh Haha, You loose";
                    }
                    return $" Computer Third move is: {engineMoves[2]} ";

                 case 4:
                    if (myPlayer.CheckWiningState(myPlayer.PlayerMoves))
                    {
                        return "YOU WIN!";
                    }

                    if (GetAllRiskyCombinationsOfTwo(engineMoves, myPlayer.PlayerMoves).Count > 0 && GetAllRiskyCombinationsOfTwo(myPlayer.PlayerMoves, engineMoves).Count < 1)
                    {
                        engineMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(engineMoves, myPlayer.PlayerMoves));
                        return $" Computer Fourth move is: {engineMoves[3]} ";
                        if (myPlayer.CheckWiningState(engineMoves))
                        {
                            return $" Computer Fourth move is: {engineMoves[3]}, Haha, You loose";
                        }
                    }
                    engineMoves.Add(WiningStrategy.CalculateWiningMove(engineMoves, myPlayer.PlayerMoves));
                    if (myPlayer.CheckWiningState(engineMoves))
                    {
                        return $" Computer Fourth move is: {engineMoves[3]}, Haha, You loose";
                    }
                    return $" Computer Fourth move is: {engineMoves[3]} ";

                case 5:
                    if (myPlayer.CheckWiningState(myPlayer.PlayerMoves))
                    {
                        return "YOU WIN!";
                    }
                    if (GetAllRiskyCombinationsOfTwo(engineMoves, myPlayer.PlayerMoves).Count > 0 && GetAllRiskyCombinationsOfTwo(myPlayer.PlayerMoves, engineMoves).Count < 1)
                    {
                        engineMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(engineMoves, myPlayer.PlayerMoves));
                        return $" Computer Fifth move is: {engineMoves[4]} ";
                        if (myPlayer.CheckWiningState(engineMoves))
                        {
                            return $" Computer Fifth move is: {engineMoves[4]}, Haha, You loose";
                        }
                    }
                    engineMoves.Add(WiningStrategy.CalculateWiningMove(engineMoves, myPlayer.PlayerMoves));
                    if (myPlayer.CheckWiningState(engineMoves))
                    {
                        return $" Computer Fifth move is: {engineMoves[4]}, Haha, You loose";
                    }
                    return $" Computer Fifth move is: {engineMoves[4]} ";
                default:
                    return "Inesperated Error";
            }
        }
    }
}
