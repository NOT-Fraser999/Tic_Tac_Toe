using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Portable;

namespace TicTacToe.Tests
{
  [TestClass]
  public class TicTacToeFraserTest
  {
    [TestMethod]
    public void CheckforNewMove()
    {



    }

    [TestMethod]
    public void CheckforWinner() 
    {



    }

    [TestMethod]
    public void TogglePlayers()
    {
      var game = new TicTacToeGame();
      for (int i = 0; i < TicTacToeGame.BoardSize; ++i)
      {
        if (game.PlayerTurn == Player.X)
        {
          game.NewMoveMade(0, i);
          Assert.AreEqual(game.PlayerTurn, Player.O);
        } else {
          game.NewMoveMade(0, i);
          Assert.AreEqual(game.PlayerTurn, Player.X);
         }
      }
    }

    [TestMethod]
    public void ChangeWhoStartsNextRound()
    {



    }

    [TestMethod]
    public void CheckforCellReplacement()
    {



    }

    [TestMethod]
    public void IncrementtheWinCounter()
    {
      int startingWinCountX = TicTacToeGame.WinCountX;
      int startingWinCountO = TicTacToeGame.WinCountO;
      int thisTestWinCountX = 0;
      int thisTestWinCountO = 0;

      for (int i = 0; i < 3; ++i)
      {
        var game = new TicTacToeGame();
        Assert.AreEqual(TicTacToeGame.WinCountX, startingWinCountX + thisTestWinCountX);
        Assert.AreEqual(TicTacToeGame.WinCountO, startingWinCountO + thisTestWinCountO);
        var startingPlayer = game.PlayerTurn;
        for (int j = 0; j < TicTacToeGame.BoardSize - 1; ++j) {
          game.NewMoveMade(j, 0);
          game.NewMoveMade(j, 1);
        }

        Assert.AreEqual(TicTacToeGame.WinCountX, startingWinCountX + thisTestWinCountX);
        Assert.AreEqual(TicTacToeGame.WinCountO, startingWinCountO + thisTestWinCountO);
        game.NewMoveMade(TicTacToeGame.BoardSize - 1, 0);
        if (startingPlayer == Player.X)
        {
          ++thisTestWinCountX;
        }
        else
        {
          ++thisTestWinCountO;
        }
        Assert.AreEqual(TicTacToeGame.WinCountX, startingWinCountX + thisTestWinCountX);
        Assert.AreEqual(TicTacToeGame.WinCountO, startingWinCountO + thisTestWinCountO);
      }
    }

    [TestMethod]
    public void ShowWinState()
    {



    }
  }
}
