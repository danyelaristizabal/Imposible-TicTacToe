using System;
using System.Collections.Generic; 

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine myEngine = new Engine();
            Player myPlayer = new Player();

            Start:
            Console.WriteLine("Welcome to Imposible Tic-tac-toe, Press any key to start playing");
            Console.ReadKey();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter your {i + 1 } move");
                myPlayer.playerMoves.Add(Convert.ToInt32(Console.ReadLine()));
                if (i != 4) Console.WriteLine($"My {i + 1 } move is " + myEngine.CalculateMove(myPlayer));
            }

            Console.WriteLine("To restart the game enter 1, to close the app press any key ");

            if (Convert.ToInt32(Console.ReadLine()) == 2 ) {
                myPlayer.playerMoves.Clear();
                myEngine.engineMoves.Clear();
                goto Start;
            } 

            Console.ReadKey();
        }
    }
}
