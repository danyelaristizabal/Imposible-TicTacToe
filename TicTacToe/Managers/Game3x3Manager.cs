using System;
namespace TicTacToe
{
    public class Game3x3Manager 
    {
        private static Game MyGame { get; set; }
        public Game3x3Manager(Game _myGame)
        {
            MyGame = _myGame; 
        }

        public void AddToPlayermove(int move)
        {
            MyGame.MyPlayer.Moves.Add(move);
        }

        public void AddToEnginemove(int move)
        {
            MyGame.MyEngine.Moves.Add(move);
        }

        public void RunGame()
        {
        Start:
            Console.WriteLine("Welcome to Imposible Tic-tac-toe, Press enter to start playing");
            Console.ReadKey();

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
                if (EngineManager.correctMoves.Contains(move))
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
                if (i != 4)
                {
                    string answer = Play();
                    if (answer.Contains(("loose")) || answer.Contains(("WIN")))
                    {
                        Console.WriteLine(answer);
                        break;
                    }
                    Console.WriteLine(answer);
                }
            }
            Console.WriteLine("To restart the game type R, to close the app press any key ");
            if (ClearMoves(Console.ReadLine()))
            {
                goto Start;
            }
        }

        private static string Play()
        {
            switch (MyGame.MyPlayer.Moves.Count)
            {
                case 1:
                    MyGame.MyEngine.Moves.Add(BlockingStrategy.FirstMove(MyGame.MyPlayer));
                    return $" Computer First move is: {MyGame.MyEngine.Moves[0]} ";

                case 2:
                    if (EngineManager.GetAllRiskyCombinationsOfTwo(MyGame.MyEngine.Moves, MyGame.MyPlayer.Moves).Count > 0)
                    {
                        MyGame.MyEngine.Moves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(MyGame.MyEngine.Moves, MyGame.MyPlayer.Moves));
                        return $" Computer Second move is: {MyGame.MyEngine.Moves[1]} ";
                    }
                    MyGame.MyEngine.Moves.Add(WiningStrategy.CalculateWiningMove(MyGame.MyEngine.Moves, MyGame.MyPlayer.Moves));
                    return $" Computer Second move is: {MyGame.MyEngine.Moves[1]} ";

                case 3:
                    if (WinnerStateChecker.CheckState(MyGame.MyPlayer))
                    {
                        return "YOU WIN!";
                    }
                    if (EngineManager.GetAllRiskyCombinationsOfTwo(MyGame.MyEngine.Moves, MyGame.MyPlayer.Moves).Count > 0
                     && EngineManager.GetAllRiskyCombinationsOfTwo(MyGame.MyPlayer.Moves, MyGame.MyEngine.Moves).Count < 1)
                    {
                        MyGame.MyEngine.Moves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(MyGame.MyEngine.Moves, MyGame.MyPlayer.Moves));
                        if (WinnerStateChecker.CheckState(MyGame.MyEngine))
                        {
                            return $" Computer Third move is: {MyGame.MyEngine.Moves[2]}, Haha, You loose";
                        }
                        return $" Computer Third move is: {MyGame.MyEngine.Moves[2]} ";

                    }
                    MyGame.MyEngine.Moves.Add(WiningStrategy.CalculateWiningMove(MyGame.MyEngine.Moves, MyGame.MyPlayer.Moves));
                    if (WinnerStateChecker.CheckState(MyGame.MyEngine))
                    {
                        return $" Computer Third move is: {MyGame.MyEngine.Moves[2]}, oh Haha, You loose";
                    }
                    return $" Computer Third move is: {MyGame.MyEngine.Moves[2]} ";

                case 4:
                    if (WinnerStateChecker.CheckState(MyGame.MyPlayer))
                    {
                        return "YOU WIN!";
                    }

                    if (EngineManager.GetAllRiskyCombinationsOfTwo(MyGame.MyEngine.Moves, MyGame.MyPlayer.Moves).Count > 0 
                    && EngineManager.GetAllRiskyCombinationsOfTwo(MyGame.MyPlayer.Moves, MyGame.MyEngine.Moves).Count < 1)
                    {
                        MyGame.MyEngine.Moves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(MyGame.MyEngine.Moves, MyGame.MyPlayer.Moves));
                        if (WinnerStateChecker.CheckState(MyGame.MyEngine))
                        {
                            return $" Computer Fourth move is: {MyGame.MyEngine.Moves[3]}, Haha, You loose";
                        }
                        return $" Computer Fourth move is: {MyGame.MyEngine.Moves[3]} ";

                    }
                    MyGame.MyEngine.Moves.Add(WiningStrategy.CalculateWiningMove(MyGame.MyEngine.Moves, MyGame.MyPlayer.Moves));
                    if (WinnerStateChecker.CheckState(MyGame.MyEngine))
                    {
                        return $" Computer Fourth move is: {MyGame.MyEngine.Moves[3]}, Haha, You loose";
                    }
                    return $" Computer Fourth move is: {MyGame.MyEngine.Moves[3]} ";

                case 5:
                    if (WinnerStateChecker.CheckState(MyGame.MyPlayer))
                    {
                        return "YOU WIN!";
                    }
                    if (EngineManager.GetAllRiskyCombinationsOfTwo(MyGame.MyEngine.Moves, MyGame.MyPlayer.Moves).Count > 0 
                    && EngineManager.GetAllRiskyCombinationsOfTwo(MyGame.MyPlayer.Moves, MyGame.MyEngine.Moves).Count < 1)
                    {
                        MyGame.MyEngine.Moves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(MyGame.MyEngine.Moves, MyGame.MyPlayer.Moves));
                        if (WinnerStateChecker.CheckState(MyGame.MyEngine))
                        {
                            return $" Computer Fifth move is: {MyGame.MyEngine.Moves[4]}, Haha, You loose";
                        }
                        return $" Computer Fifth move is: {MyGame.MyEngine.Moves[4]} ";

                    }
                    MyGame.MyEngine.Moves.Add(WiningStrategy.CalculateWiningMove(MyGame.MyEngine.Moves, MyGame.MyPlayer.Moves));
                    if (WinnerStateChecker.CheckState(MyGame.MyEngine))
                    {
                        return $" Computer Fifth move is: {MyGame.MyEngine.Moves[4]}, Haha, You loose";
                    }
                    return $" Computer Fifth move is: {MyGame.MyEngine.Moves[4]} ";


                default:
                    return "Inesperated Error";
            }
        }

        internal bool ClearMoves(string command)
        {
            if (command == "R" || command == "r")
            {
                MyGame.MyPlayer.ClearMoves();
                MyGame.MyEngine.ClearMoves();
                return true;
            }
            return false;
        }
    }
}
