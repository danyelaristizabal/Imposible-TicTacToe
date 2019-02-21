using System;
using System.Collections.Generic; 

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

            Engine myEngine = new Engine();

            Player myPlayer = new Player();
            Console.WriteLine("Enter your first move");
            myPlayer.playerMoves.Add(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("My first move "+ myEngine.CalculateMove(myPlayer));

            Console.WriteLine("Enter your second move");
            myPlayer.playerMoves.Add(Convert.ToInt32(Console.ReadLine()));  
            Console.WriteLine("My second move " + myEngine.CalculateMove(myPlayer));

            Console.WriteLine("Enter your third move");
            myPlayer.playerMoves.Add(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("My third move " + myEngine.CalculateMove(myPlayer));

            Console.WriteLine("Enter your fourth move");
            myPlayer.playerMoves.Add(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("My third move " + myEngine.CalculateMove(myPlayer));
            /*
            Console.WriteLine("Enter your fifth move");
            myPlayer.playerMoves.Add(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("My fourth move " + myEngine.CalculateMove(myPlayer));

           */

            Engine myEngine = new Engine();

            Player myPlayer = new Player();

            myPlayer.playerMoves.Add(1);
          

            myPlayer.playerMoves.Add(4);
 
         

            BlockingStrategy.FindingMovesToBlock(myEngine.engineMoves, myPlayer.playerMoves).ForEach(i => i.combination.ForEach(b => Console.WriteLine(b)));     

            Console.ReadKey();
        }
    }
}
