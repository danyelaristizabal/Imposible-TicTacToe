using System.Collections.Generic; 
namespace TicTacToe
{
    // Wraps all the logic related to analisis of moves, uses moveCombination class, Blocking and Wining strategy to calculate the bestmove in each point of the game. 
    public class Engine : IPlayer 
    {
        public List<int> PlayerMoves { get; set; }

        public Engine() 
        {
            PlayerMoves = new List<int>(); 
        }
        internal void ClearMoves() {
            PlayerMoves.Clear(); 
        } 
    }
}
