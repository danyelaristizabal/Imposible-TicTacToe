using System;
using System.Collections.Generic;
using TicTacToe.Managers; 
namespace TicTacToe
{
    internal class Game9x9Manager : IGameManager
    {
        public Game MyGame { get; set; }
        public int NextTable { get; set; }

        internal static List<PartialGameManager> UltimateGame { get; set; }

        public bool Over { get; set; }
        public bool Draw { get; set; }

        public Game9x9Manager(Game game)
        {
            MyGame = game;
            UltimateGame = new List<PartialGameManager>();

            for (int i = 0; i < 9; i++)
            {
                UltimateGame.Add(new PartialGameManager(new Game(new Player(), new Engine()), i));
            }
        }

        public void RunGame()
        {
            bool play = true; 
            while(play) {

            Console.WriteLine("Welcome to Extreme Tic-tac-toe, Press enter to start playing");

            RunPartialGames();

            Console.WriteLine("To restart the game type R, to close the app press any key ");

                play = ClearMoves(Console.ReadLine()); 
            }
        }

        public void RunPartialGames() 
        {
            int move = 0;
            bool validation = true; 
            TryAgain:

            Console.WriteLine("Choose game table");
            while (validation) 
            {
                try
                {
                    move = Convert.ToInt32(Console.ReadLine());
                    validation = !TableInputValidator(MyGame, move); 
                    
                }
                catch // validating correct input 
                {
                    Console.WriteLine("Incorrect input, Only numbers from 1 to 9");

                    Console.WriteLine("Press enter your input again");

                    validation = true; 
                }
            }

            
            while (!WinnerStateChecker.CheckState(MyGame.MyPlayer) && !WinnerStateChecker.CheckState(MyGame.MyEngine))
            {
                int ComputerMove;
                bool tableValidation = true; 

                while (tableValidation) { 

                    NextTable = UltimateGame[move - 1].RunGame();
                    
                    if (UltimateGame[NextTable - 1].Winned) // Checking if somebody won the table before and handle choosing 
                                                            //table until we start again with new table move 
                    {
                        Console.WriteLine("Table closed, computer will choose another one");
                    // -------------- choosing next table logic 
                        move = EngineManager.ComputerChooseTable(MyGame);

                    Console.WriteLine($"Choosed table: {move}");

                    WinnerStateChecker.DisplayMovesOfPartialGame(move, UltimateGame); 

                        ComputerMove = CalculateMove(MyGame, UltimateGame[move - 1].GetEngine(), UltimateGame[move - 1].GetPlayer());

                        Console.WriteLine($"Calculated Move: {ComputerMove}");

                        UltimateGame[NextTable - 1].AddToEnginemove(ComputerMove);

                        NextTable = ComputerMove; 

                        if (WinnerStateChecker.CheckState(UltimateGame[NextTable - 1].GetEngine())) // Checking if computer won last table, if so handling logic. 
                        {

                            Console.WriteLine($"Computer Won table {NextTable}");

                        WinnerStateChecker.DisplayMovesOfPartialGame(NextTable,UltimateGame); 

                            MyGame.MyEngine.Moves.Add(NextTable);

                            if (Game9x9Checker(MyGame.MyEngine))   
                            {
                                Console.WriteLine("Computer WON 9x9 Game");
                                MyGame.Over = true;
                                break;
                            }

                            UltimateGame[NextTable - 1].ChangeWinnedState();

                            goto TryAgain;
                        }

                        move = ComputerMove;
                        tableValidation = true; 
                    }else
                    {

                        tableValidation = false; 

                    }

                    if (WinnerStateChecker.CheckState(UltimateGame[move - 1].GetPlayer()) && tableValidation != true) // Checking if player won, if so handling choosing next table logic 
                    {
                       // -------------- choosing next table logic 
                        Console.WriteLine($"Player won table: {move}");

                    WinnerStateChecker.DisplayMovesOfPartialGame(move, UltimateGame); 

                        MyGame.MyPlayer.Moves.Add(move);

                        if (Game9x9Checker(MyGame.MyPlayer))  
                        {
                            Console.WriteLine("Player WON 9x9 Game");
                            MyGame.Over = true;
                            break;
                        }

                        UltimateGame[move - 1].ChangeWinnedState();
                        
                        move = EngineManager.ComputerChooseTable(MyGame);

                        Console.WriteLine($"Choosed table :{move}");

                        WinnerStateChecker.DisplayMovesOfPartialGame(move, UltimateGame); 

                        ComputerMove = CalculateMove(MyGame, UltimateGame[move - 1].GetEngine(), UltimateGame[move - 1].GetPlayer());

                        Console.WriteLine($"Calculated Move: {ComputerMove} ");

                        UltimateGame[move - 1].AddToEnginemove(ComputerMove);

                        if (WinnerStateChecker.CheckState(UltimateGame[move - 1].GetEngine()))
                        {
                            Console.WriteLine($"Computer Won table {move}");

                        WinnerStateChecker.DisplayMovesOfPartialGame(move, UltimateGame); 

                            MyGame.MyEngine.Moves.Add(move);

                            if (Game9x9Checker(MyGame.MyEngine))   
                            {
                                Console.WriteLine("Computer WON 9x9 Game");
                                MyGame.Over = true;
                                break;
                            }

                            UltimateGame[move - 1].ChangeWinnedState();

                            goto TryAgain;
                        }
                        move = ComputerMove;
                        tableValidation = true;
                    }
                    else 
                    {
                        tableValidation = false;
                    } 

                }



                ComputerMove = CalculateMove(MyGame, UltimateGame[NextTable - 1].GetEngine(), UltimateGame[NextTable - 1].GetPlayer());

                WinnerStateChecker.DisplayMovesOfPartialGame(NextTable, UltimateGame); 

                    Console.WriteLine($"Calculated Move: {ComputerMove} ");

                    UltimateGame[NextTable - 1].AddToEnginemove(ComputerMove);

                    if (WinnerStateChecker.CheckState(UltimateGame[NextTable - 1].GetEngine()))
                    {
                        Console.WriteLine($"Computer Won table: {NextTable}");

                    WinnerStateChecker.DisplayMovesOfPartialGame(NextTable, UltimateGame);

                        MyGame.MyEngine.Moves.Add(NextTable);

                        if (Game9x9Checker(MyGame.MyEngine))  
                        {
                            Console.WriteLine("Engine wins 9x9 Game");
                            MyGame.Over = true;
                            break;
                        }

                        UltimateGame[NextTable - 1].ChangeWinnedState();
                        goto TryAgain;
                    }
                    move = ComputerMove;
            }
        }

        static int CalculateMove(Game game, IPlayer computer, IPlayer player) 
        {
            int result = EngineManager.CalculateMove(computer, player); 
            while (!TableInputValidator(game, result))
            {
                result = EngineManager.CalculateMove(computer, player);
            }
            return result; 
        }

        static bool TableInputValidator(Game Game, int move)
        {

            if (!Constants.correctMoves.Contains(move)) // Validating correct input
            {
                Console.WriteLine("Incorrect input, Only numbers from 1 to 9");

                Console.WriteLine("Press enter your input again");

                return false;
            }
            if (Game.MyEngine.Moves.Contains(move) // Validating choosen table taken state
            || Game.MyPlayer.Moves.Contains(move))
            {
                Console.WriteLine("taken table, sending flow to choose table ");
                return false;
            }
            return true;
        }

        static bool Game9x9Checker(IPlayer player) 
        {
            return WinnerStateChecker.CheckState(player);
        }

        public bool ClearMoves(string command) 
        {
            if (command == "R" || command == "r") 
            {
                UltimateGame.ForEach(i => i.ClearMoves(command));

                UltimateGame.ForEach(i => i.Winned = false);

                MyGame.MyPlayer.ClearMoves();

                MyGame.MyEngine.ClearMoves(); 

                return true; 
            }
            return false;
        }
    }
}
