namespace TicTacToe.Portable {
  public class TicTacToeGame {
    private static Player _newGameTurn = Player.X;
    public static readonly int BoardSize = 3;

    private readonly CellState[,] _gameBoard = new CellState[BoardSize, BoardSize];
    private CellState _currentPlayerState = CellState.Default;
    private bool _gameOver;
    private int _turnCounter;

    public TicTacToeGame() {
      _turnCounter = 0;
      PlayerTurn = _newGameTurn;
      _newGameTurn = _newGameTurn == Player.X ? Player.O : Player.X;

      for (int i = 0; i < BoardSize; ++i) {
        for (int j = 0; j < BoardSize; ++j) {
          _gameBoard[i, j] = CellState.Default;
        }
      }
    }

    public static int WinCountX { get; private set; }
    public static int WinCountO { get; private set; }
    public Player PlayerTurn { get; private set; }

    public CellState[,] NewMoveMade(int row, int column) {
      if (_gameBoard[row, column] != CellState.Default || _gameOver) {
        return _gameBoard;
      }

      if (PlayerTurn == Player.X) {
        _gameBoard[row, column] = CellState.NormalX;
      } else {
        _gameBoard[row, column] = CellState.NormalO;
      }

      ++_turnCounter;
      CheckForWinner();
      TogglePlayer();
      return _gameBoard;
    }

    private void CheckForWinner() {
      _currentPlayerState = PlayerTurn == Player.X ? CellState.NormalX : CellState.NormalO;

      ColumnCheck();
      RowCheck();
      DiagCheck(_currentPlayerState);

      if (PlayerTurn == Player.X && _gameOver) {
        ++WinCountX;
      } else if (PlayerTurn == Player.O && _gameOver) {
        ++WinCountO;
      }

      if (_turnCounter == (BoardSize * BoardSize)) {
        _gameOver = true;
      }
    }

    private void TogglePlayer() {
      if (PlayerTurn == Player.X) {
        PlayerTurn = Player.O;
        return;
      }

      PlayerTurn = Player.X;
    }

    private void DiagCheck(CellState searchState) {
      bool diagonalOneWin = true;
      bool diagonalTwoWin = true;

      for (int i = 0; i < BoardSize; i++) {
        if (_gameBoard[i, i] != searchState) {
          diagonalOneWin = false;
        }
        if (_gameBoard[i, BoardSize - i - 1] != searchState) {
          diagonalTwoWin = false;
        }
        if (!diagonalOneWin && !diagonalTwoWin) {
          return;
        }
      }

      _gameOver = true;

      for (int i = 0; i < BoardSize; ++i) {
        if (diagonalOneWin) {
          _gameBoard[i, i] = PlayerTurn == Player.X ? CellState.WinX : CellState.WinO;
        } else {
          _gameBoard[i, BoardSize - i - 1] = PlayerTurn == Player.X ? CellState.WinX : CellState.WinO;
        }
      }
    }

    private void ColumnCheck() {
      for (int columnIndex = 0; columnIndex < BoardSize; columnIndex++) {
        if (_gameBoard[0, columnIndex] != _currentPlayerState ||
            _gameBoard[1, columnIndex] != _currentPlayerState ||
            _gameBoard[2, columnIndex] != _currentPlayerState) {
          continue;
        }
        _gameOver = true;

        for (int rowIndex = 0; rowIndex < BoardSize; rowIndex++) {
          _gameBoard[rowIndex, columnIndex] = PlayerTurn == Player.X ? CellState.WinX : CellState.WinO;
        }
      }
    }

    private void RowCheck() {
      for (int rowIndex = 0; rowIndex < BoardSize; ++rowIndex) {
        if (_gameBoard[rowIndex, 0] != _currentPlayerState ||
            _gameBoard[rowIndex, 1] != _currentPlayerState ||
            _gameBoard[rowIndex, 2] != _currentPlayerState) {
          continue;
        }
        _gameOver = true;

        for (int columnIndex = 0; columnIndex < BoardSize; columnIndex++) {
          _gameBoard[rowIndex, columnIndex] = PlayerTurn == Player.X ? CellState.WinX : CellState.WinO;
        }
      }
    }
  }
}
