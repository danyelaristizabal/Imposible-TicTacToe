using System;
using System.Collections.Generic;
using System.Linq; 
namespace TicTacToe
{

    // Wraps all the logic behind choosing a winingMove to make a winingCombination 
    internal static class WiningStrategy
    {
        internal static int CalculateWiningMove(List<int> engineMoves, List<int> playerMoves)
        {
            var Rand = new Random();
            var WiningMove = new List<int> ();
            List<MoveCombination> movePackage = CalculateWiningCombinationsLeft(playerMoves);

            //In the case that movePackage en up being because there is no move to do, like at the end of any 
            // game nobody wins it will choose  randomly between the moves left to do. 
            if(movePackage.Count == 0)
            {
                List<int> posibleMoves = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                var filteredList = posibleMoves.Where(i => !engineMoves.Contains(i) && !playerMoves.Contains(i)).ToList<int>();
                return filteredList[Rand.Next(0, filteredList.Count())];
            }

            if (movePackage.Count == 1) {
                MoveCombination theOnly = movePackage[0];
                for (int i = 0; i < theOnly.combination.Count; i++)
                {
                    if (!engineMoves.Contains(theOnly.combination[i]) 
                    && !playerMoves.Contains(theOnly.combination[i]))
                    {
                        return theOnly.combination[i]; 
                    }
                }
            }
             WiningMove = ChooseBestMovesInCombinationsLeft(movePackage, engineMoves, playerMoves);
            return WiningMove[Rand.Next(0, WiningMove.Count)];
        }

        // Calculate all the wining combinations left in a game in any point. 

       private static List<MoveCombination> CalculateWiningCombinationsLeft(List<int> Moves) 
        {
            var combinationsLeft = new List<MoveCombination> { };

            foreach (var combination in Engine.winingCombinations)
            {
                int Counter = 0;
                foreach (var move in combination.combination)
                {
                    for (int i = 0; i < Moves.Count - 1; i++)
                    {
                        if(Moves[i] == move || Moves[i + 1] == move)
                            {
                            Counter++;
                        } 
                    }
                }
                if (Counter == 0)
                {
                    combinationsLeft.Add(combination);
                }
            }
            return combinationsLeft;
        }

        private static List<int> ChooseBestMovesInCombinationsLeft(List<MoveCombination> combinationsLeft, 
        List<int> engineMoves, List<int> playerMoves)    
         {
            var theChoosenOnes = new List<int>();

            // This cycle checks each move of engineMoves if they are completing 
            // any of the combinationsLeft, if it is completing one then calculate the block
            // for that combination and return inmidiatly theChoosenOnes with just the block move in it
              
            foreach (var combination in combinationsLeft)
            {
                var counter = 0; 
                var move1 = new int();
                var move2 = new int();
                foreach (var move in engineMoves)
                {
                    if (combination.combination.Contains(move)) 
                    {
                        if (counter == 0) 
                        {
                            move1 = move;
                        } 
                        counter++;
                    }
                    if(counter == 2) 
                    {
                        move2 = move;
                        theChoosenOnes.Add(Engine.CalculateBlock(move1, move2));
                        return theChoosenOnes; 
                    } 
                }
            }

            theChoosenOnes = FindRepeatedNumberTwoTimes(combinationsLeft, engineMoves, playerMoves); 

            if (theChoosenOnes.Count == 0) 
            {
                theChoosenOnes = AddAllPosibleMoves(combinationsLeft, engineMoves, playerMoves); 
            }
            return theChoosenOnes;

        }
        //In the case that theChoosenOnes end up being empty 
        //because none of the combinations have a shared move between each other,
        //this method will add all the posible moves that can make 
        //a wining move to the array theChoosenOnes. 

        private static List<int> AddAllPosibleMoves(List<MoveCombination> combinationsLeft, 
            List<int> engineMoves, List<int> playerMoves ) 
        {
            var theChoosenOnes = new List<int> ();
            foreach (var combination in combinationsLeft)
            {
                foreach (var move in combination.combination)
                {
                    if (!engineMoves.Contains(move) && !playerMoves.Contains(move))
                    {
                        theChoosenOnes.Add(move);
                    }
                }
            }
            return theChoosenOnes; 
        }

        // This function finds repeated numbers in a collection of combinations 
        // that they are used more than one time between the combinations 
        // in the context of the game means that choosing this two numbers 
        // will increase our posibilities of wining by choosing move that have 
        // the posibilities to make two wining combinations not only one.  

        private static List<int> FindRepeatedNumberTwoTimes(List<MoveCombination> combinationsLeft, 
            List<int> engineMoves, List<int> playerMoves) 
        {
            var theChoosenOnes = new List<int> ();
            for (int i = 0; i < combinationsLeft.Count; i++)
            {
                foreach (var checkingMove in combinationsLeft[i].combination)
                {
                    for (int j = i + 1; j < combinationsLeft.Count; j++)
                    {
                        foreach (var move in combinationsLeft[j].combination)
                            if (move == checkingMove && !engineMoves.Contains(checkingMove) && !playerMoves.Contains(checkingMove))
                            {
                                theChoosenOnes.Add(checkingMove);
                            }
                    }
                }
            }
            return theChoosenOnes; 
        }
    }
}
