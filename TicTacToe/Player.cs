using System;
using System.Collections.Generic; 
namespace TicTacToe
{
    public class Player
    {
        public List<int> playerMoves;

        public Player( )
        {
            playerMoves = new List<int> { };
        }

        public bool CheckWiningStatePlayer()
        {

            switch (playerMoves.Count)
            {
                case 1:
                    return false;
                case 2: return false;

                case 3:
                    MoveCombination firstCombination = new MoveCombination(playerMoves[0], playerMoves[1], playerMoves[2]);
                    if (Engine.CheckCombinationWithWiningCombinations(firstCombination)) return true;
                    return false;
                case 4:
                    MoveCombination secondCombination = new MoveCombination(playerMoves[1], playerMoves[2], playerMoves[3]);
                    if (Engine.CheckCombinationWithWiningCombinations(secondCombination)) return true;
                    MoveCombination thirdCombination = new MoveCombination(playerMoves[0], playerMoves[2], playerMoves[3]);
                    if (Engine.CheckCombinationWithWiningCombinations(thirdCombination)) return true;
                    MoveCombination fourthCombination = new MoveCombination(playerMoves[1], playerMoves[0], playerMoves[3]);
                    if (Engine.CheckCombinationWithWiningCombinations(fourthCombination)) return true;
                    return false;
                case 5:
                    MoveCombination fifthCombination = new MoveCombination(playerMoves[1], playerMoves[2], playerMoves[4]);
                    if (Engine.CheckCombinationWithWiningCombinations(fifthCombination)) return true;
                    MoveCombination sixthCombination = new MoveCombination(playerMoves[1], playerMoves[3], playerMoves[4]);
                    if (Engine.CheckCombinationWithWiningCombinations(sixthCombination)) return true;
                    MoveCombination seventhCombination = new MoveCombination(playerMoves[2], playerMoves[3], playerMoves[4]);
                    if (Engine.CheckCombinationWithWiningCombinations(seventhCombination)) return true;

                    MoveCombination eightCombination = new MoveCombination(playerMoves[0], playerMoves[2], playerMoves[4]);
                    if (Engine.CheckCombinationWithWiningCombinations(eightCombination)) return true;
                    MoveCombination ninethCombination = new MoveCombination(playerMoves[0], playerMoves[3], playerMoves[4]);
                    if (Engine.CheckCombinationWithWiningCombinations(ninethCombination)) return true;

                    MoveCombination tenthCombination = new MoveCombination(playerMoves[0], playerMoves[1], playerMoves[4]);
                    if (Engine.CheckCombinationWithWiningCombinations(tenthCombination)) return true;
                    return false;

                default:
                    return false;
            }
        }
    }
}
