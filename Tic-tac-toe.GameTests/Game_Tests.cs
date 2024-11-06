using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Tic_tac_toe.GameService;
using Xunit;

namespace Tic_tac_toe.GameTests
{
    public class Game_Tests
    {
        [Fact]
        public void MakeAMove_Player1_ReturnsTrue()
        {
            var game = new Game();
            string mark = game.MakeAMove("Player 1");

            Assert.Equal("X", mark);
        }

        [Fact]
        public void MakeAMove_Player2_ReturnsTrue()
        {
            var game = new Game();
            string mark = game.MakeAMove("Player 2");

            Assert.Equal("O", mark);
        }

        // Winning combinations:
        //1 2 3;    1 4 7;  1 5 9;  2 5 8;
        //3 6 9;    3 5 7;  4 5 6;  7 8 9.
        [Theory]
        [InlineData("x 1 2 3")] [InlineData("1 x 2 3")] [InlineData("1 2 x 3")] 
        [InlineData("1 2 3 x")] [InlineData("x 1 2 3 y")]

        [InlineData("1 2 3")] [InlineData("1 3 2")] [InlineData("2 1 3")]
        [InlineData("2 3 1")] [InlineData("3 1 2")] [InlineData("3 2 1")]

        [InlineData("1 4 7")] [InlineData("1 7 4")] [InlineData("4 1 7")]
        [InlineData("4 7 1")] [InlineData("7 1 4")] [InlineData("7 4 1")]

        [InlineData("1 5 9")] [InlineData("1 9 5")] [InlineData("5 1 9")]
        [InlineData("5 9 1")] [InlineData("9 1 5")] [InlineData("9 5 1")]

        [InlineData("2 5 8")] [InlineData("2 8 5")] [InlineData("5 2 8")]
        [InlineData("5 8 2")] [InlineData("8 2 5")] [InlineData("8 5 2")]

        [InlineData("3 6 9")] [InlineData("3 9 6")] [InlineData("6 3 9")]
        [InlineData("6 9 3")] [InlineData("9 3 6")] [InlineData("9 6 3")]

        [InlineData("3 5 7")] [InlineData("3 7 5")] [InlineData("5 3 7")]
        [InlineData("5 7 3")] [InlineData("7 3 5")] [InlineData("7 5 3")]

        [InlineData("4 5 6")] [InlineData("4 6 5")] [InlineData("5 4 6")]
        [InlineData("5 6 4")] [InlineData("6 4 5")] [InlineData("6 5 4")]

        [InlineData("7 8 9")] [InlineData("7 9 8")] [InlineData("8 7 9")]
        [InlineData("8 9 7")] [InlineData("9 7 8")] [InlineData("9 8 7")]
        public void CheckWin_WinningCombination_ReturnsTrue(string winCombo)
        { 
            var game = new Game();
            bool isWin = game.CheckWin(winCombo);
            Assert.True(isWin);
        }

    }
}
