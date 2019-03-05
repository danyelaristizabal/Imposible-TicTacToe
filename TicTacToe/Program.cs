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
            List<int> correctMoves = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 
            Start:
            Console.WriteLine("Welcome to Imposible Tic-tac-toe, Press any key to start playing");
            Console.ReadKey();
           
           


            for (int i = 0; i < 5; i++)
            { 

                int move = 0;
                TryAgain: 
                Console.WriteLine($"Enter your {i + 1 } move");
                try 
                { 
                move = Convert.ToInt32(Console.ReadLine());
                }
                catch {
                    Console.WriteLine("Incorrect input, Only numbers from 1 to 9");
                    Console.WriteLine("Press enter to input again");
                    Console.ReadLine();
                    goto TryAgain; 
                }

                if (correctMoves.Contains(move)) myPlayer.playerMoves.Add(move);
                else {
                    Console.WriteLine("Incorrect input, Only numbers from 1 to 9");
                    Console.WriteLine("Press enter to input again");
                    Console.ReadLine(); 
                    goto TryAgain; 
                }
                if (i != 4) Console.WriteLine($"My {i + 1 } move is " + myEngine.CalculateMove(myPlayer));
            }

            Console.WriteLine("To restart the game enter 1, to close the app press any key ");

            if (Convert.ToInt32(Console.ReadLine()) == 1 ) {
                myPlayer.playerMoves.Clear();
                myEngine.engineMoves.Clear();
                goto Start;
            } 
            Console.ReadKey();
                     
        }
    }
}
