using System;
using System.Collections.Generic;
using System.Linq; 

namespace TicTacToe
{
    public static  class WinnerStateChecker
    {
        private static List<int> UnOrderedMovesList = new List<int>();

        public static bool CheckState(IPlayer MyPlayer) // TODO : player moves with 555 or 333 says it wins 
        {
            var PassedListOfMoves = MyPlayer.Moves;
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

        public static int CalculateNumberOfPosibleCombinations(int numberOfMoves)
        {
            if(numberOfMoves == 3) {return 1;} // in case is 3 
            int result = CalcFactorial(numberOfMoves) / (CalcFactorial(3) * CalcFactorial(numberOfMoves - 3));
            return result;
        }

        internal static void  CombinationUtil(IPlayer MyPlayer, int[] arr, int[] data, int start, int end, int index, int r)
        {
            Console.WriteLine("inside the loop n:" + end + " r:" + r);
            if (index == r)
            {
                for (int j = 0; j < r; j++)
                {
                    UnOrderedMovesList.Add(data[j]);
                    Console.Write("Added:" + data[j]);
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
            int numberOfCombinations = CalculateNumberOfPosibleCombinations(n);
            int[,] combinations = new int[numberOfCombinations, 3];
            Console.WriteLine("before entering the loop n:" + n + " r:" + r );

            CombinationUtil(MyPlayer, arr, data, 0, n - 1, 0, r);
            Console.WriteLine("After the loop:");
            UnOrderedMovesList.ForEach(Console.Write);
            Console.WriteLine();
        }


    }
}
