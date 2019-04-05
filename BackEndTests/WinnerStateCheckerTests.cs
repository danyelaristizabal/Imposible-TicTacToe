using System;
using Xunit;
using TicTacToe;

namespace BackEndTests
{
    public class PLayerTests // TODO Write a function for each function in PlayerManager 
    {
        [Fact]
        public void CheckState()
        {
            var player = new Player();
            player.Moves.Add(1);
            player.Moves.Add(5);
            player.Moves.Add(7);
            var result =  WinnerStateChecker.CheckState(player);
            Assert.True(result == false);
        }
        [Fact]
       public void CalculateNumberOfPosibleCombinationsTest() 
       {
            int result =  WinnerStateChecker.CalculateNumberOfPosibleCombinations(3);
            Assert.True(result == 1); 
       }

    }
}
