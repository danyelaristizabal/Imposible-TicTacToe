using System;
using System.Collections.Generic;

namespace TicTacToe
{
    internal class Game3x3
    {
        internal static Player MyPlayer  { get; set; }
        internal static Engine MyEngine { get; set; }


        private static readonly List<int> correctMoves = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public void AddToPlayermove(int move) 
        {
            MyPlayer.PlayerMoves.Add(move);

        }
        public void AddToEnginemove(int move)
        {
            MyEngine.PlayerMoves.Add(move);
        }

        public Game3x3(Player _Player, Engine _Engine)
        {
            MyPlayer = _Player;
            MyEngine = _Engine; 
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
            switch (MyPlayer.PlayerMoves.Count)
            {
                case 1:
                    MyEngine.PlayerMoves.Add(BlockingStrategy.FirstMove(MyPlayer));
                    return $" Computer First move is: {MyEngine.PlayerMoves[0]} ";

                case 2:
                    if (MyEngine.GetAllRiskyCombinationsOfTwo(MyEngine.PlayerMoves, MyPlayer.PlayerMoves).Count > 0)
                    {
                        MyEngine.PlayerMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(MyEngine.PlayerMoves, MyPlayer.PlayerMoves));
                        return $" Computer Second move is: {MyEngine.PlayerMoves[1]} ";
                    }
                    MyEngine.PlayerMoves.Add(WiningStrategy.CalculateWiningMove(MyEngine.PlayerMoves, MyPlayer.PlayerMoves));
                    return $" Computer Second move is: {MyEngine.PlayerMoves[1]} ";

                case 3:
                    if (WinnerChecker.CheckState(MyPlayer))
                    {
                        return "YOU WIN!";
                    }
                    if (MyEngine.GetAllRiskyCombinationsOfTwo(MyEngine.PlayerMoves, MyPlayer.PlayerMoves).Count > 0
                     && MyEngine.GetAllRiskyCombinationsOfTwo(MyPlayer.PlayerMoves, MyEngine.PlayerMoves).Count < 1)
                    {
                        MyEngine.PlayerMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(MyEngine.PlayerMoves, MyPlayer.PlayerMoves));
                        if (WinnerChecker.CheckState(MyEngine))
                        {
                            return $" Computer Third move is: {MyEngine.PlayerMoves[2]}, Haha, You loose";
                        }
                        return $" Computer Third move is: {MyEngine.PlayerMoves[2]} ";

                    }
                    MyEngine.PlayerMoves.Add(WiningStrategy.CalculateWiningMove(MyEngine.PlayerMoves, MyPlayer.PlayerMoves));
                    if (WinnerChecker.CheckState(MyEngine))
                    {
                        return $" Computer Third move is: {MyEngine.PlayerMoves[2]}, oh Haha, You loose";
                    }
                    return $" Computer Third move is: {MyEngine.PlayerMoves[2]} ";

                case 4:
                    if (WinnerChecker.CheckState(MyPlayer))
                    {
                        return "YOU WIN!";
                    }

                    if (MyEngine.GetAllRiskyCombinationsOfTwo(MyEngine.PlayerMoves, MyPlayer.PlayerMoves).Count > 0 && MyEngine.GetAllRiskyCombinationsOfTwo(MyPlayer.PlayerMoves, MyEngine.PlayerMoves).Count < 1)
                    {
                        MyEngine.PlayerMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(MyEngine.PlayerMoves, MyPlayer.PlayerMoves));
                        if (WinnerChecker.CheckState(MyEngine))
                        {
                            return $" Computer Fourth move is: {MyEngine.PlayerMoves[3]}, Haha, You loose";
                        }
                        return $" Computer Fourth move is: {MyEngine.PlayerMoves[3]} ";

                    }
                    MyEngine.PlayerMoves.Add(WiningStrategy.CalculateWiningMove(MyEngine.PlayerMoves, MyPlayer.PlayerMoves));
                    if (WinnerChecker.CheckState(MyEngine))
                    {
                        return $" Computer Fourth move is: {MyEngine.PlayerMoves[3]}, Haha, You loose";
                    }
                    return $" Computer Fourth move is: {MyEngine.PlayerMoves[3]} ";

                case 5:
                    if (WinnerChecker.CheckState(MyPlayer))
                    {
                        return "YOU WIN!";
                    }
                    if (MyEngine.GetAllRiskyCombinationsOfTwo(MyEngine.PlayerMoves, MyPlayer.PlayerMoves).Count > 0 && MyEngine.GetAllRiskyCombinationsOfTwo(MyPlayer.PlayerMoves, MyEngine.PlayerMoves).Count < 1)
                    {
                        MyEngine.PlayerMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(MyEngine.PlayerMoves, MyPlayer.PlayerMoves));
                        if (WinnerChecker.CheckState(MyEngine))
                        {
                            return $" Computer Fifth move is: {MyEngine.PlayerMoves[4]}, Haha, You loose";
                        }
                        return $" Computer Fifth move is: {MyEngine.PlayerMoves[4]} ";

                    }
                    MyEngine.PlayerMoves.Add(WiningStrategy.CalculateWiningMove(MyEngine.PlayerMoves, MyPlayer.PlayerMoves));
                    if (WinnerChecker.CheckState(MyEngine))
                    {
                        return $" Computer Fifth move is: {MyEngine.PlayerMoves[4]}, Haha, You loose";
                    }
                    return $" Computer Fifth move is: {MyEngine.PlayerMoves[4]} ";


                default:
                    return "Inesperated Error";
            }
        }


        internal  bool ClearMoves(string command)
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
