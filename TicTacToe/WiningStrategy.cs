using System;
using System.Collections.Generic; 
namespace TicTacToe
{


    public static class WiningStrategy
    {

        public static int CalculateWiningMove(List<int> engineMoves, List<int> playerMoves)
        {
            var Rand = new Random();
            List<MoveCombination> movePackage = CalculateWiningCombinationsLeft(playerMoves);
            if(movePackage.Count == 1) {
                MoveCombination theOnly = movePackage[0];
                for (int i = 0; i < theOnly.combination.Count; i++)
                {
                    if (!engineMoves.Contains(theOnly.combination[i]) && !playerMoves.Contains(theOnly.combination[i])){
                        return theOnly.combination[i]; 
                    }
                }
            }

            var WiningMove = ChooseRepeatedtwoNumbersOnSelectedCombinations(movePackage, engineMoves, playerMoves);
            return WiningMove[Rand.Next(0, WiningMove.Count)];
        }


        public static List<MoveCombination> CalculateWiningCombinationsLeft(List<int> Moves)
        {
            var combinationsLeft = new List<MoveCombination> { };

            foreach (var combination in Engine.winingCombinations)
            {
                int Counter = 0;
                foreach (var move in combination.combination)
                {
                    for (int i = 0; i < Moves.Count - 1; i++)
                    {
                        if(Moves[i] == move || Moves[i + 1] == move) Counter++;
                    }
                }
                if (Counter == 0)
                {
                    combinationsLeft.Add(combination);
                }
            }
            return combinationsLeft;
        }


        public static List<int> ChooseRepeatedtwoNumbersOnSelectedCombinations(List<MoveCombination> combinationsLeft, List<int> engineMoves, List<int> playerMoves)
        {
            var theChoosenOnes = new List<int> { };



            foreach (var combination in combinationsLeft)
            {
                int checking;
                foreach (var move in combination.combination)
                {
                    checking = move;
                    foreach (var onCheckcombination in combinationsLeft)
                    {
                        foreach (var onCheckMove in combination.combination)
                        {
                            if (checking == onCheckMove && combination != onCheckcombination && checking != engineMoves[0])
                            {
                                if (!theChoosenOnes.Contains(checking) && !engineMoves.Contains(checking) && !playerMoves.Contains(checking) ) theChoosenOnes.Add(checking);
                            }
                        }
                    }
                }
            }
            return theChoosenOnes;
        }



    }
}