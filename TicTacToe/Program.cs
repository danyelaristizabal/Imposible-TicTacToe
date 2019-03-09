using System;
using System.Collections.Generic; 

namespace TicTacToe
{
    class Program
    {
        static Engine MyEngine { get; set; } 
        static Player MyPlayer { get; set; }
        private static readonly List<int> correctMoves = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        private static void RunGame() 
        {
            MyEngine = new Engine();
            MyPlayer = new Player(); 
            for (int i = 0; i < 5; i++)
            {

                int move = 0;
            TryAgain:
                Console.WriteLine($"Enter your {i + 1} move");
                try
                {
                    move = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Incorrect input, Only numbers from 1 to 9");
                    Console.WriteLine("Press enter to input again");
                    Console.ReadLine();
                    goto TryAgain;
                }
                if (correctMoves.Contains(move))
                {
                    MyPlayer.PlayerMoves.Add(move);
                }
                else
                {
                    Console.WriteLine("Incorrect input, Only numbers from 1 to 9");
                    Console.WriteLine("Press enter to input again");
                    Console.ReadLine();
                    goto TryAgain;
                }
                if (i != 4)
                {
                    string answer = MyEngine.CalculateMove(MyPlayer);
                    if (answer.Contains(("loose"))|| answer.Contains(("WIN")))
                    {
                        Console.WriteLine(answer);
                        break;
                    }
                    Console.WriteLine(answer);
                }
            }
        }


        static void Main(string[] args)
        {
            Start:
            Console.WriteLine("Welcome to Imposible Tic-tac-toe, Press enter to start playing");
            Console.ReadKey();
            RunGame(); 
            Console.WriteLine("To restart the game type R, to close the app press any key ");
            if (ClearMoves(Console.ReadLine())) 
            {
                goto Start;
            }
        }



        private static bool ClearMoves(string command)
        {
            if (command == "R" || command == "r")
            {
                MyPlayer.ClearMoves();
                MyEngine.ClearMoves();
                return true;
            }
            return false;
        }
    }
}
