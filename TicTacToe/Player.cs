using System;
using System.Collections.Generic;
using System.Linq; 

namespace TicTacToe
{
    internal class Player /// Wraps all the player functions logic
    {
        internal List<int> PlayerMoves { get; set;  }
        static List<int> UnOrderedMovesList = new List<int>();
        static List<MoveCombination> AllPosibilitiesList = new List<MoveCombination>(); 
        internal Player()
        {
            PlayerMoves = new List<int> (); 
        } 
        internal void ClearMoves()
        { 
        PlayerMoves.Clear(); 
        }
        internal static int CalcFactorial(int number)
        {
            if (number == 1)
            {
             return 1;
            }
            return number * CalcFactorial(number - 1);
        }

        internal static int CalculateNumberOfPosibleCombinations(int numberOfMoves)
        {
            int result = CalcFactorial(numberOfMoves) / (CalcFactorial(3) * CalcFactorial(numberOfMoves - 3));
            return result;
        }

        internal static void CombinationUtil(int[] arr, int[] data, int start, int end, int index, int r)
        {
            if (index == r)
            {
                for (int j = 0; j < r; j++)
                {
                    UnOrderedMovesList.Add(data[j]);
                }
                return;
            }
            for (int i = start; i <= end &&
                      end - i + 1 >= r - index; i++)
            {
                data[index] = arr[i];

                CombinationUtil(arr, data, i + 1,
                                end, index + 1, r);
            }
        }
        internal static void PrintCombination(int[] arr, int n, int r)
        {
            int[] data = new int[r];
            int numberofcombinations = CalculateNumberOfPosibleCombinations(6);
            int[,] combinations = new int[numberofcombinations, 3];
            CombinationUtil(arr, data, 0, n - 1, 0, r);
        }

         internal bool CheckWiningState(List<int> PlayerMoves)
        {
                int[] arr = new int[PlayerMoves.Count];
            for (int i = 0; i < PlayerMoves.Count; i++)
                arr[i] = PlayerMoves[i]; 
            int r = 3;
            int n = arr.Length;
            PrintCombination(arr, n, r);

            for (int i = 0; i <= UnOrderedMovesList.Count - 3; i = i + 3)
            {
                AllPosibilitiesList.Add(new MoveCombination(UnOrderedMovesList[i], UnOrderedMovesList[i + 1], UnOrderedMovesList[i + 2]));
            }
            int switch_on = AllPosibilitiesList.Count;

            switch (switch_on)
            {
                case 1: return false;
                case 2: return false;

                default:
                    foreach (var combination in AllPosibilitiesList)
                    {
                        if (Engine.CheckCombinationWithWiningCombinations(combination)) return true;
                    }
                    return false;
            }
        }
    }
}
