using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
