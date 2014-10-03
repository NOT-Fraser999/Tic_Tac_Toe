using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Portable;

namespace TicTacToe.Tests {
  [TestClass]
  public class TicTacToeTest {
    [TestMethod]
    public void CheckStartingPlayer() {
      // Should Always be X
      var game = new TicTacToeGame();
      Assert.AreEqual(game.PlayerTurn, Player.X);
    }

    [TestMethod]
    public void CheckWinCounterForWin() {
      var game = new TicTacToeGame();
      game.NewMoveMade(0, 0);
      game.NewMoveMade(0, 1);
      game.NewMoveMade(1, 0);
      game.NewMoveMade(1, 1);

      Assert.AreEqual(TicTacToeGame.WinCountX, 0);
      game.NewMoveMade(2, 0);

      Assert.AreEqual(TicTacToeGame.WinCountX, 1);

      Assert.AreEqual(TicTacToeGame.WinCountO, 0);
    }
  }
}
