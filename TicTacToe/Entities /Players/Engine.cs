using System.Collections.Generic; 
namespace TicTacToe
{
    // Wraps all the logic related to analisis of moves, uses moveCombination class, Blocking and Wining strategy to calculate the bestmove in each point of the game. 
    public class Engine : IPlayer 
    {
        public List<int> Moves { get; set; }

        public Engine() 
        {
            Moves = new List<int>(); 
        }
        public void ClearMoves() {
            Moves.Clear(); 
        } 
    }
}
