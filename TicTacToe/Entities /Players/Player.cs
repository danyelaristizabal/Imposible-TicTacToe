using System.Collections.Generic;

namespace TicTacToe
{
    public class Player :IPlayer /// Wraps all the player functions logic
    {
        public List<int> PlayerMoves { get; set;  }
        public Player()
        {
            PlayerMoves = new List<int>();
        }
        internal void ClearMoves()
        { 
        PlayerMoves.Clear(); 
        }
    }
}
