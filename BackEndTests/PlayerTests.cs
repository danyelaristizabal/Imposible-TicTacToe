using System;
using Xunit;
using TicTacToe;

namespace BackEndTests
{
    public class PLayerTests // TODO Write a function for each function in PlayerManager 
    {
        [Fact]
        public void Test1()
        {
            var player = new Player();
            player.Moves.Add(5);
            player.Moves.Add(5);
            player.Moves.Add(5);
            var result =  WinnerStateChecker.CheckState(player);
            Assert.True(result = true);
        }
    }
}
