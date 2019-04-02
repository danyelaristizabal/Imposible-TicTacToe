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
            Console.ReadKey();
            while (!WinnerChecker.CheckState(MyPlayer) && !WinnerChecker.CheckState(MyEngine))
            {
                Table:
                if (correctMoves.Contains(move)
                && !MyEngine.PlayerMoves.Contains(move)
                && !MyPlayer.PlayerMoves.Contains(move))
                {
                    int ComputerMove;
                    Console.WriteLine($"EngineMoves on current table: {move}");
                    UltimateGame[move - 1].GetEngineMoves().ForEach(i => Console.Write(i));
                    Console.WriteLine();
                    Console.WriteLine($"PlayerMoves on current table: {move}");
                    UltimateGame[move - 1].GetPlayerMoves().ForEach(i => Console.Write(i));



                    NextTable = UltimateGame[move - 1].RunGame();

                    if (UltimateGame[NextTable - 1].Winned)
                    {
                        move = ComputerChooseTable();
                        Console.WriteLine("Table closed, computer will choose another one");
                        move = ComputerChooseTable();
                        Console.WriteLine($"Choosed table : {move} ");
                        ComputerMove = EngineManager.CalculateMove(UltimateGame[move - 1].GetEngine(), UltimateGame[move - 1].GetPlayer());


                        Console.WriteLine($"EngineMoves on current table: {move}");
                        UltimateGame[move - 1].GetEngineMoves().ForEach(i => Console.Write(i));
                        Console.WriteLine();
                        Console.WriteLine($"PlayerMoves on current table: {move}");
                        UltimateGame[move - 1].GetPlayerMoves().ForEach(i => Console.Write(i));


                        Console.WriteLine($"Calculated Move: {ComputerMove} ");
                        UltimateGame[NextTable - 1].AddToEnginemove(ComputerMove);


                        if (WinnerChecker.CheckState(UltimateGame[NextTable - 1].GetEngine())) // here 
                        {
                            Console.WriteLine($"Computer Won table {NextTable}");
                            Console.WriteLine($"EngineMoves on current table: {NextTable}");
                            UltimateGame[NextTable - 1].GetEngineMoves().ForEach(i => Console.Write(i));
                            Console.ReadKey();
                            MyEngine.PlayerMoves.Add(NextTable);
                            UltimateGame[NextTable - 1].ChangeWinnedState();
                            Console.ReadKey();
                            goto TryAgain;
                        }

                        move = ComputerMove;
                        goto Table;
                    }



                    if (WinnerChecker.CheckState(UltimateGame[move - 1].GetPlayer()))
                    {
                        Console.WriteLine($"Player won table: {move}");
                        Console.WriteLine($"PlayerMoves on current table: {move}");
                        UltimateGame[move - 1].GetPlayerMoves().ForEach(i => Console.Write(i));
                        MyPlayer.PlayerMoves.Add(move);
                        UltimateGame[move - 1].ChangeWinnedState();
                        move = ComputerChooseTable();

                        Console.WriteLine($"Choosed table :{move}");
                        ComputerMove = EngineManager.CalculateMove(UltimateGame[move - 1].GetEngine(), UltimateGame[move - 1].GetPlayer());

                        Console.WriteLine($"EngineMoves on current table: {move}");
                        UltimateGame[move - 1].GetEngineMoves().ForEach(i => Console.Write(i));
                        Console.WriteLine();
                        Console.WriteLine($"PlayerMoves on current table: {move}");
                        UltimateGame[move - 1].GetPlayerMoves().ForEach(i => Console.Write(i));



                        Console.WriteLine($"Calculated Move: {ComputerMove} ");
                        UltimateGame[move - 1].AddToEnginemove(ComputerMove);

                        if (WinnerChecker.CheckState(UltimateGame[move - 1].GetEngine()))
                        {
                            Console.WriteLine($"Computer Won table {move}");
                            Console.WriteLine($"EngineMoves on current table: {move}");
                            UltimateGame[move - 1].GetEngineMoves().ForEach(i => Console.Write(i));
                            Console.ReadKey();
                            MyEngine.PlayerMoves.Add(move);
                            UltimateGame[move - 1].ChangeWinnedState();
                            Console.ReadKey();
                            goto TryAgain;
                        }

                        move = ComputerMove;
                        Console.ReadKey();
                        Console.ReadLine();
                        goto Table;
                    }

                     ComputerMove = EngineManager.CalculateMove(UltimateGame[NextTable - 1].GetEngine(), UltimateGame[NextTable -1].GetPlayer());

                    Console.WriteLine($"EngineMoves on next table: {NextTable}");
                    UltimateGame[NextTable - 1].GetEngineMoves().ForEach(i => Console.Write(i));
                    Console.WriteLine();
                    Console.WriteLine($"PlayerMoves on next table: {NextTable}");
                    UltimateGame[NextTable - 1].GetPlayerMoves().ForEach(i => Console.Write(i));


                    Console.WriteLine($"Calculated Move: {ComputerMove} ");

                    UltimateGame[NextTable - 1].AddToEnginemove(ComputerMove);

                    if (WinnerChecker.CheckState(UltimateGame[NextTable - 1].GetEngine()))
                    {
                        Console.WriteLine($"Computer Won table: {NextTable}");
                        Console.WriteLine($"EngineMoves on current table: {NextTable}");
                        UltimateGame[NextTable - 1].GetEngineMoves().ForEach(i => Console.Write(i));
                        Console.ReadKey();
                        MyEngine.PlayerMoves.Add(NextTable);
                        UltimateGame[NextTable - 1].ChangeWinnedState(); 
                        Console.ReadKey(); 
                        goto TryAgain;
                    }

                    move = ComputerMove;
                }
                else 
                {
                    Console.WriteLine("Wrong move, sending flow to try again");
                    Console.ReadKey(); 
                    goto TryAgain; 
                }

                if (WinnerChecker.CheckState(MyPlayer))
                {
                    Console.WriteLine("PlayerWins 9x9 Game");
                    break; 
                }
                if (WinnerChecker.CheckState(MyEngine))
                {
                    Console.WriteLine("PlayerWins 9x9 Game");
                    break; 
                }

            }

              
        }

        public int ComputerChooseTable() 
        {

            var calculated = EngineManager.CalculateMove(MyEngine, MyPlayer);
            while (MyEngine.PlayerMoves.Contains(calculated) || MyPlayer.PlayerMoves.Contains(calculated)) 
            {
                Console.WriteLine("not finded");
                calculated = EngineManager.CalculateMove(MyEngine, MyPlayer);
            }
            return calculated;
        }

        

        public bool ClearMoves(string command) // check this, is not 
        {
            if (command == "R" || command == "r") 
            {
                UltimateGame.ForEach(i => i.ClearMoves(command));
                UltimateGame.ForEach(i => i.ChangeWinnedState()); 
                MyPlayer.ClearMoves();
                MyEngine.ClearMoves(); 
                return true; 
            }
            return false;
        }
    }
}
