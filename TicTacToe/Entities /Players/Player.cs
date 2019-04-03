using System.Collections.Generic;

namespace TicTacToe
{
    public class Player :IPlayer /// Wraps all the player functions logic
    {
        public string Id { get; private set; }

        private string Password { get; set; }

        public List<int> Moves { get; set;  }

        public Player()
        {

            Moves = new List<int>();

        }

        public void ClearMoves()
        {
         
        Moves.Clear(); 

        }
    }
}
