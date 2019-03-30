using System;
using System.Collections.Generic;
using System.Linq; 
namespace TicTacToe
{
    internal class Game9x9 
    {
        internal Player MyPlayer { get; set; }
        internal Engine MyEngine { get; set; }
        public int NextTable { get; set; }

        internal static List<PartialGame> UltimateGame { get; set; }
        private static  List<int> correctMoves = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public Game9x9(Player _MyPlayer, Engine _MyEngine)
        {
            MyPlayer = _MyPlayer;
            MyEngine = _MyEngine;
            UltimateGame = new List<PartialGame>();
           

            for (int i = 0; i < 9; i++)
            {
                UltimateGame.Add(new PartialGame(new Player(), new Engine(), i)); // check that in this way they end up with the correct indexes 
            }
        }

     

        public void RunGame() 
        {
                Start:
                Console.WriteLine("Welcome to Extreme Tic-tac-toe, Press enter to start playing");
                Console.ReadKey();
                
                RunPartialGame();
                
                Console.WriteLine("To restart the game type R, to close the app press any key ");
                
                if (ClearMoves(Console.ReadLine()))
                {
                    
                    goto Start;
                }

        }

        public void RunPartialGame() 
        {
            int move = 0;
            TryAgain:
            Console.WriteLine("Choose game table");
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
            Console.WriteLine("------ before while");
            Console.WriteLine("9x9 player moves:");
            MyPlayer.PlayerMoves.ForEach(Console.Write);
            Console.WriteLine("9x9 engine moves:");
            MyEngine.engineMoves.ForEach(Console.Write);

            Console.WriteLine($"wining stat player:{!MyPlayer.CheckWiningState(MyPlayer.PlayerMoves)}");
            Console.WriteLine($"wining stat engine:{!MyPlayer.CheckWiningState(MyEngine.engineMoves)}");
            Console.ReadKey();
            while (!MyPlayer.CheckWiningState(MyPlayer.PlayerMoves) && !MyPlayer.CheckWiningState(MyEngine.engineMoves))
            {
                Table:
                if (correctMoves.Contains(move)
                && !MyEngine.engineMoves.Contains(move)
                && !MyPlayer.PlayerMoves.Contains(move))
                {
                    Console.WriteLine($"EngineMoves on current table: {move}");
                    UltimateGame[move - 1].GetEngineMoves().ForEach(i => Console.Write(i));
                    Console.WriteLine();
                    Console.WriteLine($"PlayerMoves on current table: {move}");
                    UltimateGame[move - 1].GetPlayerMoves().ForEach(i => Console.Write(i));



                    NextTable = UltimateGame[move - 1].RunGame();

                    if (MyPlayer.CheckWiningState(UltimateGame[move - 1].GetPlayerMoves()))
                    {
                        Console.WriteLine($"Player won this table {move}");
                        Console.WriteLine($"PlayerMoves on current table: {move}");
                        UltimateGame[move - 1].GetPlayerMoves().ForEach(i => Console.Write(i));
                        MyPlayer.PlayerMoves.Add(move);
                        move = ComputerChooseTable();
                        Console.ReadKey();
                        Console.ReadLine();
                        goto Table;
                    }

                    int ComputerMove = MyEngine.CalculateMove(UltimateGame[NextTable - 1].GetEngine(), UltimateGame[NextTable -1].GetPlayer());
                    Console.WriteLine($"Calculated Move: {ComputerMove} ");

                    UltimateGame[NextTable - 1].AddToEnginemove(ComputerMove);

                    if (MyPlayer.CheckWiningState(UltimateGame[NextTable - 1].GetEngineMoves()))
                    {
                        Console.WriteLine($"Computer Won table {NextTable}");
                        Console.WriteLine($"EngineMoves on current table: {NextTable}");
                        UltimateGame[NextTable - 1].GetEngineMoves().ForEach(i => Console.Write(i));
                        Console.ReadKey();
                        MyEngine.engineMoves.Add(NextTable);
                        Console.WriteLine($"ADDED NUMBER: {MyEngine.engineMoves.Last<int>()}");
                        Console.ReadKey(); 
                        goto TryAgain;
                    }

                    move = ComputerMove;
                    Console.WriteLine($"end of cycle move:{move}");
                }
                else 
                {
                    Console.WriteLine("Wrong move, goint to try again");
                    Console.ReadKey(); 
                    goto TryAgain; 
                }

             
            }
        
        }

        public int ComputerChooseTable() 
        {
           return  MyEngine.CalculateMove(MyEngine, MyPlayer); 
        }

        public bool ClearMoves(string command)
        {
            if (command == "R" || command == "r") 
            {
                UltimateGame.ForEach(i => i.ClearMoves(command));
                MyPlayer.ClearMoves();
                MyEngine.ClearMoves(); 
                return true; 
            }
            return false;
        }
    }
}
