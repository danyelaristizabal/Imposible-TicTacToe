using System;
using System.Collections.Generic;

namespace TicTacToe
{
    internal class PartialGame
    {
        public bool Winned { get; set; }
        internal  Player MyPlayer { get; set; }
        internal  Engine MyEngine { get; set; }
        public int Index { get; set; }
        public int PartialId { get; set; }
        public int NextMove { get; set;  }
        private static readonly List<int> correctMoves = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        internal PartialGame(Player _Player, Engine _Engine, int _PartialId)
        {
            MyPlayer = _Player;
            MyEngine = _Engine;
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
            MyPlayer.PlayerMoves.Add(move);

        }
        public void AddToEnginemove(int move)
        {
            MyEngine.PlayerMoves.Add(move);
        }
        public List<int> GetPlayerMoves ()
        {
            return MyPlayer.PlayerMoves;
        }
        public List<int> GetEngineMoves ()
        {
            return MyEngine.PlayerMoves; 
        }
        public Engine GetEngine() 
        {
            return MyEngine;
        }
        public Player GetPlayer() 
        {
            return MyPlayer; 
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
                    MyPlayer.PlayerMoves.Add(move);
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
                MyPlayer.ClearMoves();
                MyEngine.ClearMoves();
                Index = 0; 
                return true;
            }
            return false;
        }

    }
}
