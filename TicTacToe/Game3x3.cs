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
            MyEngine.engineMoves.Add(move);
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
                    MyEngine.engineMoves.Add(BlockingStrategy.FirstMove(MyPlayer));
                    return $" Computer First move is: {MyEngine.engineMoves[0]} ";

                case 2:
                    if (MyEngine.GetAllRiskyCombinationsOfTwo(MyEngine.engineMoves, MyPlayer.PlayerMoves).Count > 0)
                    {
                        MyEngine.engineMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(MyEngine.engineMoves, MyPlayer.PlayerMoves));
                        return $" Computer Second move is: {MyEngine.engineMoves[1]} ";
                    }
                    MyEngine.engineMoves.Add(WiningStrategy.CalculateWiningMove(MyEngine.engineMoves, MyPlayer.PlayerMoves));
                    return $" Computer Second move is: {MyEngine.engineMoves[1]} ";

                case 3:
                    if (MyPlayer.CheckWiningState(MyPlayer.PlayerMoves))
                    {
                        return "YOU WIN!";
                    }
                    if (MyEngine.GetAllRiskyCombinationsOfTwo(MyEngine.engineMoves, MyPlayer.PlayerMoves).Count > 0
                     && MyEngine.GetAllRiskyCombinationsOfTwo(MyPlayer.PlayerMoves, MyEngine.engineMoves).Count < 1)
                    {
                        MyEngine.engineMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(MyEngine.engineMoves, MyPlayer.PlayerMoves));
                        if (MyPlayer.CheckWiningState(MyEngine.engineMoves))
                        {
                            return $" Computer Third move is: {MyEngine.engineMoves[2]}, Haha, You loose";
                        }
                        return $" Computer Third move is: {MyEngine.engineMoves[2]} ";

                    }
                    MyEngine.engineMoves.Add(WiningStrategy.CalculateWiningMove(MyEngine.engineMoves, MyPlayer.PlayerMoves));
                    if (MyPlayer.CheckWiningState(MyEngine.engineMoves))
                    {
                        return $" Computer Third move is: {MyEngine.engineMoves[2]}, oh Haha, You loose";
                    }
                    return $" Computer Third move is: {MyEngine.engineMoves[2]} ";

                case 4:
                    if (MyPlayer.CheckWiningState(MyPlayer.PlayerMoves))
                    {
                        return "YOU WIN!";
                    }

                    if (MyEngine.GetAllRiskyCombinationsOfTwo(MyEngine.engineMoves, MyPlayer.PlayerMoves).Count > 0 && MyEngine.GetAllRiskyCombinationsOfTwo(MyPlayer.PlayerMoves, MyEngine.engineMoves).Count < 1)
                    {
                        MyEngine.engineMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(MyEngine.engineMoves, MyPlayer.PlayerMoves));
                        if (MyPlayer.CheckWiningState(MyEngine.engineMoves))
                        {
                            return $" Computer Fourth move is: {MyEngine.engineMoves[3]}, Haha, You loose";
                        }
                        return $" Computer Fourth move is: {MyEngine.engineMoves[3]} ";

                    }
                    MyEngine.engineMoves.Add(WiningStrategy.CalculateWiningMove(MyEngine.engineMoves, MyPlayer.PlayerMoves));
                    if (MyPlayer.CheckWiningState(MyEngine.engineMoves))
                    {
                        return $" Computer Fourth move is: {MyEngine.engineMoves[3]}, Haha, You loose";
                    }
                    return $" Computer Fourth move is: {MyEngine.engineMoves[3]} ";

                case 5:
                    if (MyPlayer.CheckWiningState(MyPlayer.PlayerMoves))
                    {
                        return "YOU WIN!";
                    }
                    if (MyEngine.GetAllRiskyCombinationsOfTwo(MyEngine.engineMoves, MyPlayer.PlayerMoves).Count > 0 && MyEngine.GetAllRiskyCombinationsOfTwo(MyPlayer.PlayerMoves, MyEngine.engineMoves).Count < 1)
                    {
                        MyEngine.engineMoves.Add(BlockingStrategy.WithAllCombinationsCalculateBlock(MyEngine.engineMoves, MyPlayer.PlayerMoves));
                        if (MyPlayer.CheckWiningState(MyEngine.engineMoves))
                        {
                            return $" Computer Fifth move is: {MyEngine.engineMoves[4]}, Haha, You loose";
                        }
                        return $" Computer Fifth move is: {MyEngine.engineMoves[4]} ";

                    }
                    MyEngine.engineMoves.Add(WiningStrategy.CalculateWiningMove(MyEngine.engineMoves, MyPlayer.PlayerMoves));
                    if (MyPlayer.CheckWiningState(MyEngine.engineMoves))
                    {
                        return $" Computer Fifth move is: {MyEngine.engineMoves[4]}, Haha, You loose";
                    }
                    return $" Computer Fifth move is: {MyEngine.engineMoves[4]} ";


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
