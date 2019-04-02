using System;
using Xunit;
using TicTacToe; 

namespace BackEndTests
{
    public class MoveCombinationTests
    {
       
        [Fact]
        public void CheckWiningCombinationTest() 
        {
            var combination = new MoveCombination(1, 2, 3);

            var result = CombinationManager.CheckWiningCombinationChance(combination, 1, 5);

            Assert.True(result == false); 
        }
      
    }
}
