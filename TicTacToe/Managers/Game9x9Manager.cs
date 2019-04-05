using System;
using System.Collections.Generic;
namespace TicTacToe
{
    internal class Game9x9Manager 
    {
        public Game MyGame { get; set; }
        public int NextTable { get; set; }

        internal static List<PartialGameManager> UltimateGame { get; set; }

        public bool Over { get; set; }
        public bool Draw { get; set; }

        public Game9x9Manager(Game _game )
        {
            MyGame = _game; 
            UltimateGame = new List<PartialGameManager>();

            for (int i = 0; i < 9; i++)
            {
                UltimateGame.Add(new PartialGameManager(new Game(new Player(), new Engine()),  i));
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

            while (!WinnerStateChecker.CheckState(MyGame.MyPlayer) && !WinnerStateChecker.CheckState(MyGame.MyEngine))
            {
                Table:

                if (Constants.correctMoves.Contains(move)
                && !MyGame.MyEngine.Moves.Contains(move)
                && !MyGame.MyPlayer.Moves.Contains(move))
                {
                    int ComputerMove;

                    Console.WriteLine($"EngineMoves on current table: {move}");

                    UltimateGame[move - 1].GetEngineMoves().ForEach(Console.Write);

                    Console.WriteLine();
                    Console.WriteLine($"PlayerMoves on current table: {move}");
                    UltimateGame[move - 1].GetPlayerMoves().ForEach(Console.Write);



                    NextTable = UltimateGame[move - 1].RunGame();

                    if (UltimateGame[NextTable - 1].Winned)
                    {
                        move = ComputerChooseTable();
                        Console.WriteLine("Table closed, computer will choose another one");
                        move = ComputerChooseTable();
                        Console.WriteLine($"Choosed table : {move} ");
                        ComputerMove = EngineManager.CalculateMove(UltimateGame[move - 1].GetEngine(), UltimateGame[move - 1].GetPlayer());


                        Console.WriteLine($"EngineMoves on current table: {move}");
                        UltimateGame[move - 1].GetEngineMoves().ForEach(Console.Write);
                        Console.WriteLine();
                        Console.WriteLine($"PlayerMoves on current table: {move}");
                        UltimateGame[move - 1].GetPlayerMoves().ForEach(Console.Write);


                        Console.WriteLine($"Calculated Move: {ComputerMove} ");
                        UltimateGame[NextTable - 1].AddToEnginemove(ComputerMove);

                        if (WinnerStateChecker.CheckState(UltimateGame[NextTable - 1].GetEngine())) // here 
                        {
                            Console.WriteLine($"Computer Won table {NextTable}");
                            Console.WriteLine($"EngineMoves on current table: {NextTable}");
                            UltimateGame[NextTable - 1].GetEngineMoves().ForEach(Console.Write);
                            Console.ReadKey();
                            MyGame.MyEngine.Moves.Add(NextTable);
                            UltimateGame[NextTable - 1].ChangeWinnedState();
                            Console.ReadKey();
                            goto TryAgain;
                        }

                        move = ComputerMove;
                        goto Table;
                    }



                    if (WinnerStateChecker.CheckState(UltimateGame[move - 1].GetPlayer()))
                    {
                        Console.WriteLine($"Player won table: {move}");
                        Console.WriteLine($"PlayerMoves on current table: {move}");
                        UltimateGame[move - 1].GetPlayerMoves().ForEach(Console.Write);
                        MyGame.MyPlayer.Moves.Add(move);
                        UltimateGame[move - 1].ChangeWinnedState();
                        move = ComputerChooseTable();

                        Console.WriteLine($"Choosed table :{move}");
                        ComputerMove = EngineManager.CalculateMove(UltimateGame[move - 1].GetEngine(), UltimateGame[move - 1].GetPlayer());

                        Console.WriteLine($"EngineMoves on current table: {move}");
                        UltimateGame[move - 1].GetEngineMoves().ForEach(Console.Write);
                        Console.WriteLine();
                        Console.WriteLine($"PlayerMoves on current table: {move}");
                        UltimateGame[move - 1].GetPlayerMoves().ForEach(Console.Write);



                        Console.WriteLine($"Calculated Move: {ComputerMove} ");
                        UltimateGame[move - 1].AddToEnginemove(ComputerMove);

                        if (WinnerStateChecker.CheckState(UltimateGame[move - 1].GetEngine()))
                        {
                            Console.WriteLine($"Computer Won table {move}");
                            Console.WriteLine($"EngineMoves on current table: {move}");
                            UltimateGame[move - 1].GetEngineMoves().ForEach(Console.Write);
                            Console.ReadKey();
                            MyGame.MyEngine.Moves.Add(move);
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

                    if (WinnerStateChecker.CheckState(UltimateGame[NextTable - 1].GetEngine()))
                    {
                        Console.WriteLine($"Computer Won table: {NextTable}");
                        Console.WriteLine($"EngineMoves on current table: {NextTable}");
                        UltimateGame[NextTable - 1].GetEngineMoves().ForEach(i => Console.Write(i));
                        Console.ReadKey();
                        MyGame.MyEngine.Moves.Add(NextTable);
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

                if (WinnerStateChecker.CheckState(MyGame.MyPlayer))
                {
                    Console.WriteLine("PlayerWins 9x9 Game");
                    break; 
                }
                if (WinnerStateChecker.CheckState(MyGame.MyEngine))
                {
                    Console.WriteLine("PlayerWins 9x9 Game");
                    break; 
                }
            }
        }

        public int ComputerChooseTable() 
        {

            var calculated = EngineManager.CalculateMove(MyGame.MyEngine, MyGame.MyPlayer);
            while (MyGame.MyEngine.Moves.Contains(calculated) || MyGame.MyPlayer.Moves.Contains(calculated)) 
            {
                Console.WriteLine("not finded");
                calculated = EngineManager.CalculateMove(MyGame.MyEngine, MyGame.MyPlayer);
            }
            return calculated;
        }

        

        public bool ClearMoves(string command) // check this, is not 
        {
            if (command == "R" || command == "r") 
            {
                UltimateGame.ForEach(i => i.ClearMoves(command));
                UltimateGame.ForEach(i => i.ChangeWinnedState()); 
                MyGame.MyPlayer.ClearMoves();
                MyGame.MyEngine.ClearMoves(); 
                return true; 
            }
            return false;
        }
    }
}
