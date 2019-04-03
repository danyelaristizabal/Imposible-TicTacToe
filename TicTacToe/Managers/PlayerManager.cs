using System;
using System.Collections.Generic; 

namespace TicTacToe
{
    public static class PlayerManager
    {
        static void ClearMoves(IPlayer MyPlayer)
        {
            MyPlayer.Moves.Clear();
        }
    }
}
