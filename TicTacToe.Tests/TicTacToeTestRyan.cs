using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Portable;

namespace TicTacToe.Tests
{
    [TestClass]
    public class TicTacToeTestRyan
    {
        [TestMethod]
        public void CheckingNewGamePlayer() {
            var game = new TicTacToeGame();
            
            Assert.AreEqual(game.PlayerTurn, Player.X);

            var game2 = new TicTacToeGame();

            Assert.AreEqual(game2.PlayerTurn, Player.O);
        }

        [TestMethod]
        public void CheckingAlternatingTurns() {
            var game = new TicTacToeGame();

            Assert.AreEqual(game.PlayerTurn, Player.X);
            game.NewMoveMade(0, 0);

            Assert.AreEqual(game.PlayerTurn, Player.O);
            game.NewMoveMade(1, 0);

            Assert.AreEqual(game.PlayerTurn, Player.X);
        }

        [TestMethod]
        public void CellOnlyClickableOnce() {
            var game = new TicTacToeGame();

            game.NewMoveMade(0, 0);
            Assert.AreEqual(game.PlayerTurn, Player.X);

            game.NewMoveMade(0, 0);
            Assert.AreEqual(game.PlayerTurn, Player.X);
        }
    }
}
