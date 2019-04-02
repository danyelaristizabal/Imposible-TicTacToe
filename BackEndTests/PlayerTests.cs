using System;
using Xunit;
using TicTacToe;

namespace BackEndTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var player = new Player();
            player.PlayerMoves.Add(5);
            player.PlayerMoves.Add(5);
            player.PlayerMoves.Add(5);
            var result =  WinnerChecker.CheckState(player);
            Assert.True(result = true);
        }
    }
}
