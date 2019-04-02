using System;
using System.Collections.Generic;

namespace TicTacToe
{
    internal class PartialGameManager
    {
        public bool Winned { get; set; }
        public Game MyGame { get; set; }
        public int Index { get; set; }
        public int PartialId { get; set; }
        public int NextMove { get; set;  }

        private static readonly List<int> correctMoves = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        internal PartialGameManager(Game _MyGame, int _PartialId)
        {
            MyGame = _MyGame; 
            Index = 0;
            Winned = false; 
            PartialId = _PartialId; 
        }

        public void ChangeWinnedState() 
        {
            Winned = true; 
        }

        public void AddToPlayermove(int move)
        {
            MyGame.MyPlayer.Moves.Add(move);
        }

        public void AddToEnginemove(int move)
        {
            MyGame.MyEngine.Moves.Add(move);
        }

        public List<int> GetPlayerMoves ()
        {
            return MyGame.MyPlayer.Moves;
        }

        public List<int> GetEngineMoves ()
        {
            return MyGame.MyEngine.Moves; 
        }

        public Engine GetEngine() 
        {
            return MyGame.MyEngine;
        }

        public Player GetPlayer() 
        {
            return MyGame.MyPlayer; 
        }

        public int RunGame()
        {
            Console.WriteLine($"Welcome to the partial table number {PartialId + 1}");
            Console.ReadKey();
           
                int move = 0;
            TryAgain:
                Console.WriteLine($"Enter your {Index + 1} move");
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
                    MyGame.MyPlayer.Moves.Add(move);
                }
                else
                {
                    Console.WriteLine("Incorrect input, Only numbers from 1 to 9");
                    Console.WriteLine("Press enter to input again");
                    Console.ReadLine();
                    goto TryAgain;
                }
                   
                Index++; 
                
                return move; 
        }

        internal bool ClearMoves(string command)
        {
            if (command == "R" || command == "r")
            {
                MyGame.MyPlayer.ClearMoves();
                MyGame.MyEngine.ClearMoves();
                Index = 0; 
                return true;
            }
            return false;
        }
    }
}
