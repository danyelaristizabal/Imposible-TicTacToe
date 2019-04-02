using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        
        static Engine MyEngine { get; set; } 
        static Player MyPlayer { get; set; }
        static Game3x3 Game    { get; set; }
        static Game9x9 Game9x9 { get; set; } // To do

        static void Main(string[] args)
        {
            MyPlayer = new Player();
            MyEngine = new Engine();
                string answer;
                var Number = new int();
                List<string> input = new List<string> { "1", "2" };
            TryAgain:

            Console.WriteLine("To play Imposible-TicTacToe press 1");
            Console.WriteLine("To play Extreme-TicTacToe press 2");

            try
            {
                answer = Console.ReadLine();

                if (input.Contains(answer))
                {
                    Number = int.Parse(answer);
                }
                else
                {
                    Console.WriteLine("Incorrect input, Only 1 or 2");
                    Console.WriteLine("Press enter to input again");
                    Console.ReadLine();
                    goto TryAgain;

                }
            }
            catch
            {
                Console.WriteLine("Incorrect input, Only 1 or 2");
                Console.WriteLine("Press enter to input again");
                Console.ReadLine();
                goto TryAgain;
            }
            if (Number == 1)
            {
                Game = new Game3x3(MyPlayer, MyEngine);
                Game.RunGame();
            }
            if (Number == 2) 
            {
                Game9x9 = new Game9x9(MyPlayer, MyEngine);
                Game9x9.RunGame();
            }
        }
    }
}
