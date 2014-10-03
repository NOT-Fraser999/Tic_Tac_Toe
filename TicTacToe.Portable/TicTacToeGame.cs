using System;

namespace TicTacToe.Portable
{
  public class TicTacToeGame
  {
    public static int WinCountX { get; private set; }
    public static int WinCountO { get; private set; }
    private static Player NewGameTurn = Player.X;
    public static readonly int BoardSize = 3;

    public Player PlayerTurn { get; private set; }
    private int TurnCounter;
    private CellState[,] _gameBoard = new CellState[BoardSize, BoardSize];
    CellState currentPlayerState = CellState.Default;
    bool _gameOver = false;


    public TicTacToeGame()
    {
      TurnCounter = 0;
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

      ++TurnCounter;
      CheckForWinner();
      TogglePlayer();
      return _gameBoard;
    }

    private  void CheckForWinner() {
      if (PlayerTurn == Player.X) {
        currentPlayerState = CellState.NormalX;
      } else {
        currentPlayerState = CellState.NormalO;
      }
      RowCheck();
      ColumnCheck();
      DiagCheck(currentPlayerState);

      if (PlayerTurn == Player.X && _gameOver == true) {
        ++WinCountX;
      } else if (PlayerTurn == Player.O && _gameOver == true) {
        ++WinCountO;
      }

      if (TurnCounter == (BoardSize * BoardSize)) {
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

    private void DiagCheck(CellState searchState){
      bool _diagonalOneWin = true;
      bool _diagonalTwoWin = true;

      for (int i = 0; i < BoardSize; i++) {

        if (_gameBoard[i, i] != searchState) {
          _diagonalOneWin = false;
        }
        if (_gameBoard[i, BoardSize - i - 1] != searchState) {
          _diagonalTwoWin = false;
        }
        if (!_diagonalOneWin && !_diagonalTwoWin) {
          return;
        }
      }

      for (int i = 0; i < BoardSize; ++i) {
        if (_diagonalOneWin == true) {
          if (PlayerTurn == Player.X) {
            _gameBoard[i, i] = CellState.WinX;
          } else {
            _gameBoard[i, i] = CellState.WinO;
          }
        }

        if (_diagonalTwoWin == true)
        if (PlayerTurn == Player.X) {
          _gameBoard[i, BoardSize - i - 1] = CellState.WinX;
        } else {
          _gameBoard[i, BoardSize - i - 1] = CellState.WinO;
        }
      }
        
    }

    private void RowCheck(){
      for (int i = 0; i < BoardSize; i++) {
        if (_gameBoard[0, i] != currentPlayerState || _gameBoard[1, i] != currentPlayerState || _gameBoard[2, i] != currentPlayerState) {
          continue;
        }
        _gameOver = true;

        for (int j = 0; j < BoardSize; j++) {
          if(PlayerTurn == Player.X) {
            _gameBoard[j, i] = CellState.WinX;
            return;
          }
          _gameBoard[j, i] = CellState.WinO;
        }
          
      }
    }

    private void ColumnCheck() {
      for (int i = 0; i < BoardSize; ++i) {
        if (_gameBoard[i, 0] != currentPlayerState || _gameBoard[i, 1] != currentPlayerState || _gameBoard[i, 2] != currentPlayerState) {
          continue;
        }
        _gameOver = true;

        for (int j = 0; j < BoardSize; j++) {
          if (PlayerTurn == Player.X) {
            _gameBoard[i, j] = CellState.WinX;
            return;
          }
          _gameBoard[i, j] = CellState.WinO;
        }
      }
    }
  }
}