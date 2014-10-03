using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Portable;

namespace TicTacToe.Tests
{
  [TestClass]
  public class TicTacToeTest
  {
    [TestMethod]
    public void PlayerToggle()
    {
      TicTacToeGame game = new TicTacToeGame();

      Assert.AreEqual(game.PlayerTurn, Player.X);

      game.NewMoveMade(0, 0);

      Assert.AreEqual(game.PlayerTurn, Player.O);
    }
  }
}
