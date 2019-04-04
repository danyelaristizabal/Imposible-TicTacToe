using System;
using System.Collections.Generic; 
namespace TicTacToe
{
    public static class LocationConstants
    {
        public static readonly List<MoveCombination> winingCombinations =
        new List<MoveCombination> {
        new MoveCombination(1, 2, 3), new MoveCombination(4, 5, 6),
        new MoveCombination(7, 8, 9), new MoveCombination(1, 5, 9),new MoveCombination(7, 5, 3),
        new MoveCombination(1, 4, 7), new MoveCombination(2, 5, 8),new MoveCombination(3, 6, 9)
        };


        public static readonly List<int> correctMoves = new List<int> { 1, 2, 3, 4, 5, 6, 7, 6, 7, 8, 9 };

        public static readonly List<int> corners = new List<int> { 1, 3, 7, 9 };
    } 
}
