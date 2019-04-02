using System;
using System.Collections.Generic;


namespace TicTacToe
{
    public static  class WinnerChecker
    {
        private static List<int> UnOrderedMovesList = new List<int>();

        public static bool CheckState(IPlayer MyPlayer) // TODO : player moves with 555 or 333 says it wins 
        {
            var PassedListOfMoves = MyPlayer.PlayerMoves;
            var AllPosibilitiesList = new List<MoveCombination>();

            if (PassedListOfMoves.Count < 3)
            {
                return false;
            }

            int[] arr = new int[PassedListOfMoves.Count];
            for (int i = 0; i < PassedListOfMoves.Count; i++)
                arr[i] = PassedListOfMoves[i];
            int r = 3;
            int n = arr.Length;
            PrintCombination(MyPlayer, arr, n, r);

            for (int i = 0; i <= UnOrderedMovesList.Count - 3; i = i + 3)
            {
                AllPosibilitiesList.Add(new MoveCombination(UnOrderedMovesList[i], UnOrderedMovesList[i + 1], UnOrderedMovesList[i + 2]));
            }

            foreach (var combination in AllPosibilitiesList)
            {
                if (EngineManager.CheckCombinationWithWiningCombinations(combination))
                {

                    return true;
                }
            }
            return false;
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

        internal static void  CombinationUtil(IPlayer MyPlayer, int[] arr, int[] data, int start, int end, int index, int r)
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

                CombinationUtil(MyPlayer, arr, data, i + 1,
                                end, index + 1, r);
            }
        }

        internal static void PrintCombination(IPlayer MyPlayer, int[] arr, int n, int r)
        {
            int[] data = new int[r];
            int numberofcombinations = CalculateNumberOfPosibleCombinations(6);
            int[,] combinations = new int[numberofcombinations, 3];
            CombinationUtil(MyPlayer, arr, data, 0, n - 1, 0, r);
        }


    }
}
