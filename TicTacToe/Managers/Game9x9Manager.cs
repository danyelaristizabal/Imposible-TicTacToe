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
        Start:

            Console.WriteLine("Welcome to Extreme Tic-tac-toe, Press enter to start playing");
            Console.ReadKey();

            RunPartialGames();

            Console.WriteLine("To restart the game type R, to close the app press any key ");

            if (ClearMoves(Console.ReadLine()))
            {
                goto Start;
            }
        }

        public void RunPartialGames() 
        {
            int move = 0;

            TryAgain:

            Console.WriteLine("Choose game table");

            try
            {
                move = Convert.ToInt32(Console.ReadLine());

                if (!TableInputValidator(MyGame, move)) 
                {

                    goto TryAgain; 

                }
            }
            catch // validating correct input 
            {
                Console.WriteLine("Incorrect input, Only numbers from 1 to 9"); 

                Console.WriteLine("Press enter to input again");

                Console.ReadLine();

                goto TryAgain;
            }

            while (!WinnerStateChecker.CheckState(MyGame.MyPlayer) && !WinnerStateChecker.CheckState(MyGame.MyEngine))
            {
                    Table:
                    int ComputerMove;
                    
                    NextTable = UltimateGame[move - 1].RunGame();
                    
                    if (UltimateGame[NextTable - 1].Winned) // Checking if somebody won the table before and handle choosing 
                                                            //table until we start again with new table move 
                    {
                        Console.WriteLine("Table closed, computer will choose another one");
                    // -------------- choosing next table logic 
                        move = EngineManager.ComputerChooseTable(MyGame);

                    Console.WriteLine($"Choosed table: {move}"); 
                           
                        DisplayMovesOfPartialGame(move); 

                        ComputerMove = CalculateMove(MyGame, UltimateGame[move - 1].GetEngine(), UltimateGame[move - 1].GetPlayer());

                        Console.WriteLine($"Calculated Move: {ComputerMove}");

                        UltimateGame[NextTable - 1].AddToEnginemove(ComputerMove);

                        NextTable = ComputerMove; 

                        if (WinnerStateChecker.CheckState(UltimateGame[NextTable - 1].GetEngine())) // Checking if computer won last table, if so handling logic. 
                        {

                            Console.WriteLine($"Computer Won table {NextTable}");

                            DisplayMovesOfPartialGame(NextTable); 

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
                        goto Table;
                    }


                    if (WinnerStateChecker.CheckState(UltimateGame[move - 1].GetPlayer())) // Checking if player won, if so handling choosing next table logic 
                    {
                       // -------------- choosing next table logic 
                        Console.WriteLine($"Player won table: {move}");

                        DisplayMovesOfPartialGame(move); 

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

                        DisplayMovesOfPartialGame(move); 

                        ComputerMove = CalculateMove(MyGame, UltimateGame[move - 1].GetEngine(), UltimateGame[move - 1].GetPlayer());

                        Console.WriteLine($"Calculated Move: {ComputerMove} ");

                        UltimateGame[move - 1].AddToEnginemove(ComputerMove);

                        if (WinnerStateChecker.CheckState(UltimateGame[move - 1].GetEngine()))
                        {
                            Console.WriteLine($"Computer Won table {move}");

                            DisplayMovesOfPartialGame(move); 

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

                        goto Table;
                    }

                    ComputerMove = CalculateMove(MyGame, UltimateGame[NextTable - 1].GetEngine(), UltimateGame[NextTable - 1].GetPlayer());

                    DisplayMovesOfPartialGame(NextTable); 

                    Console.WriteLine($"Calculated Move: {ComputerMove} ");

                    UltimateGame[NextTable - 1].AddToEnginemove(ComputerMove);

                    if (WinnerStateChecker.CheckState(UltimateGame[NextTable - 1].GetEngine()))
                    {
                        Console.WriteLine($"Computer Won table: {NextTable}");

                        DisplayMovesOfPartialGame(NextTable);

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

                Console.WriteLine("Press enter to input again");

                Console.ReadLine();
                return false;
            }
            if (Game.MyEngine.Moves.Contains(move) // Validating choosen table taken state
            || Game.MyPlayer.Moves.Contains(move))
            {
                Console.WriteLine("taken table, sending flow to choose table ");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        static void DisplayMovesOfPartialGame(int _partialId) 
        {
            Console.WriteLine($"EngineMoves on current table: {_partialId}");

            UltimateGame[_partialId - 1].GetEngineMoves().ForEach(Console.Write);

            Console.WriteLine();

            Console.WriteLine($"PlayerMoves on current table: {_partialId}");

            UltimateGame[_partialId - 1].GetPlayerMoves().ForEach(Console.Write);

            Console.WriteLine();

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

                UltimateGame.ForEach(i => i.ChangeWinnedState()); 

                MyGame.MyPlayer.ClearMoves();

                MyGame.MyEngine.ClearMoves(); 

                return true; 
            }
            return false;
        }
    }
}
