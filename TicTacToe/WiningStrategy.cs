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


        public static List<MoveCombination> CalculateWiningCombinationsLeft(List<int> Moves) // working correctly 
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


        public static List<int> ChooseRepeatedtwoNumbersOnSelectedCombinations(List<MoveCombination> combinationsLeft, List<int> engineMoves, List<int> playerMoves) // working 
        {
            var theChoosenOnes = new List<int> { };

            foreach (var combination in combinationsLeft)
            {
                var counter = 0; 
                var move1 = new int();
                var move2 = new int();
                foreach (var move in engineMoves)
                {
                    if (combination.combination.Contains(move)) 
                    {
                        if (counter == 0) move1 = move;
                        counter++;
                    }
                    if(counter == 2) 
                    {
                        move2 = move;
                       theChoosenOnes.Add( BlockingStrategy.CalculateBlock(move1, move2));
                        return theChoosenOnes; 
                    } 
                }
            }

            for (int i = 0; i < combinationsLeft.Count; i++)
                foreach (var checkingMove in combinationsLeft[i].combination)
                    for (int j = i + 1; j < combinationsLeft.Count; j++)
                        foreach (var move in combinationsLeft[j].combination)
                            if (move == checkingMove && !engineMoves.Contains(checkingMove) && !playerMoves.Contains(checkingMove))
                                theChoosenOnes.Add(checkingMove); 
            return theChoosenOnes;
        }
    }
}

/*  foreach (var onCheckcombination in combinationsLeft)
                    {
                        foreach (var onCheckMove in combination.combination)
                        {
                            if (checkingMove == onCheckMove && combination != onCheckcombination && checkingMove != engineMoves[0])
                            {
                                if (!theChoosenOnes.Contains(checkingMove) && !engineMoves.Contains(checkingMove) && !playerMoves.Contains(checkingMove) ) theChoosenOnes.Add(checkingMove);
                            }
                        }
                    }
                    */