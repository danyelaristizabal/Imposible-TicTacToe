using System;
namespace TicTacToe.Managers
{
    public interface IGameManager
    {
       Game MyGame { get; set; }
       bool Over { get; set; }
       bool Draw { get; set; } 
       void RunGame(); 
    }
}
