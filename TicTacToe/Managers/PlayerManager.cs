using System;
using System.Collections.Generic; 

namespace TicTacToe
{
    public static class PlayerManager
    {
        static void ClearMoves(Player MyPlayer)
        {
            MyPlayer.PlayerMoves.Clear();
        }


    }
}
