using System;

namespace TicTacToe.Portable
{
  public class TicTacToe
  {
    public static int WinCountX { get; private set; }
    public static int WinCountO { get; private set; }
    private static Player NewGameTurn = Player.X;
    public static readonly int BoardSize = 3;

    public Player PlayerTurn { get; private set; }
    private CellState[,] _gameBoard = new CellState[BoardSize, BoardSize];


    public TicTacToe()
    {
      PlayerTurn = NewGameTurn;
        
      for (int i = 0; i < BoardSize; ++i) {
        for (int j = 0; j < BoardSize; ++j) {
          _gameBoard[i, j] = CellState.Default;
        }
      }
    }

    public CellState[,] NewMoveMade(int row, int column) {
      if ( _gameBoard[row, column] != CellState.Default ) {
        return _gameBoard;
      }

      if (PlayerTurn == Player.X) {
        _gameBoard[row, column] = CellState.NormalX;
      } else {
        _gameBoard[row, column] = CellState.NormalO;
      }

      CheckForWinner();
      TogglePlayer();
      return _gameBoard;
    }

    private  void CheckForWinner() {
      bool _gameOver = false;
      CellState currentPlayerState = CellState.Default;
      if (PlayerTurn == Player.X) {
        currentPlayerState = CellState.NormalX;
      } else {
        currentPlayerState = CellState.NormalO;
      }

      for (int i = 0; i < BoardSize; ++i) {
        if (_gameBoard[i, 0] != currentPlayerState || _gameBoard[i, 1] != currentPlayerState || _gameBoard[i, 2] != currentPlayerState) {
          continue;
        }
        _gameOver = true;

        if (PlayerTurn == Player.X) {
          _gameBoard[i, 0] = CellState.WinX;
          _gameBoard[i, 1] = CellState.WinX;
          _gameBoard[i, 2] = CellState.WinX;
          ++WinCountX;           
        } else {
          _gameBoard[i, 0] = CellState.WinO;
          _gameBoard[i, 1] = CellState.WinO;
          _gameBoard[i, 2] = CellState.WinO;
          ++WinCountO;
        }
      }

      for (int i = 0; i < BoardSize; i++) {
        if (_gameBoard[0, i] != currentPlayerState || _gameBoard[1, i] != currentPlayerState || _gameBoard[2, i] != currentPlayerState) {
          continue;
        }
        _gameOver = true;

        if (PlayerTurn == Player.X) {
          _gameBoard[0, i] = CellState.WinX;
          _gameBoard[1, i] = CellState.WinX;
          _gameBoard[2, i] = CellState.WinX;
          ++WinCountX;           
        } else {
          _gameBoard[0, i] = CellState.WinO;
          _gameBoard[1, i] = CellState.WinO;
          _gameBoard[2, i] = CellState.WinO;
          ++WinCountO;
      }
          
      // check columns, diag

      // check if game is over - win or draw and then toggle the player to start next game
    }

      if (_gameBoard[0, 0] == currentPlayerState && _gameBoard[1, 1] == currentPlayerState && _gameBoard[2, 2] == currentPlayerState) {

        _gameOver = true;
        if (PlayerTurn == Player.X) {
          _gameBoard[0, 0] = CellState.WinX;
          _gameBoard[1, 1] = CellState.WinX;
          _gameBoard[2, 2] = CellState.WinX;
          ++WinCountX;
        } else {
          _gameBoard[0, 0] = CellState.WinO;
          _gameBoard[1, 1] = CellState.WinO;
          _gameBoard[2, 2] = CellState.WinO;
          ++WinCountO;
        }
      } else if (_gameBoard[2, 0] == currentPlayerState && _gameBoard[1, 1] == currentPlayerState && _gameBoard[0, 2] == currentPlayerState) {

        _gameOver = true;
        if (PlayerTurn == Player.X) {
          _gameBoard[0, 0] = CellState.WinX;
          _gameBoard[1, 1] = CellState.WinX;
          _gameBoard[2, 2] = CellState.WinX;
          ++WinCountX;           
        } else {
          _gameBoard[0, 0] = CellState.WinO;
          _gameBoard[1, 1] = CellState.WinO;
          _gameBoard[2, 2] = CellState.WinO;
          ++WinCountO;
      }
    }

      int DrawCellCounter = 0 ;
      for (int i = 0; i < BoardSize; ++i) {
        for (int j = 0; j < BoardSize; ++j) {
          if (_gameBoard[i, j] != CellState.Default) {
            ++DrawCellCounter;
          }
        }
      }

      if (DrawCellCounter == 9) {
        _gameOver = true;
      }


      if (_gameOver == true) {
        if (NewGameTurn == Player.X) {
          NewGameTurn = Player.O;
          return;
        }
        NewGameTurn = Player.O;
      }
  }

    private void TogglePlayer() {
      if (PlayerTurn == Player.X) {
        PlayerTurn = Player.O;
        return;
      }

      PlayerTurn = Player.X;
    }
  }
}