using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        
        static IPlayer MyEngine { get; set; } 
        static IPlayer MyPlayer { get; set; }
        static Game MyGame    { get; set; }
        static Game3x3Manager GameManager { get; set; }
        static Game9x9Manager Game9x9 { get; set; } 

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
                MyGame = new Game(MyPlayer, MyEngine);
                GameManager = new Game3x3Manager(MyGame);
                GameManager.RunGame(); 
            }
            if (Number == 2) 
            {
                MyGame = new Game(MyPlayer, MyEngine);
                Game9x9 = new Game9x9Manager(MyGame);
                Game9x9.RunGame();
            }
        }
    }
}
