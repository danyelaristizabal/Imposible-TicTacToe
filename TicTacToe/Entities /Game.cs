using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Game 
    {
        public Player MyPlayer  { get; set; }
        public Engine MyEngine { get; set; }
        public bool Over { get; set; }
        public bool Draw { get; set; }

        public Game(Player _Player, Engine _Engine)
        {
          MyPlayer = _Player;
          MyEngine = _Engine;
        }
    }
}
