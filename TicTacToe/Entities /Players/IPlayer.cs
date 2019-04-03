using System;
using System.Collections.Generic; 
namespace TicTacToe

{
    public interface IPlayer
    {
         List<int> Moves { get; set; }
         void ClearMoves();
        
    }

}
