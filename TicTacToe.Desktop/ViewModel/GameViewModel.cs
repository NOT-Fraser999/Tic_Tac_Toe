using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TicTacToe.Desktop.Model;
using TicTacToe.Portable;

namespace TicTacToe.Desktop.ViewModel {
  public class GameViewModel : ViewModelBase {
    private int _playerOWins;
    private string _playerTurn = "o";
    private int _playerXWins;
    private TicTacToeGame _ticTacToeGame;

    public GameViewModel() {
      NewGameCommand = new RelayCommand(NewGame);
      CellClickedCommand = new RelayCommand<GameCell>(OnCellClicked);
      BackCommand = new RelayCommand(() => Messenger.Default.Send("Options"));
      GameBoard = new ObservableCollection<GameCell>();
      NewGame();
    }

    public string PlayerTurn {
      get {
        return _playerTurn;
      }
      set {
        if (value == _playerTurn) {
          return;
        }

        _playerTurn = value;
        RaisePropertyChanged(() => PlayerTurn);
      }
    }

    public int PlayerXWins {
      get {
        return _playerXWins;
      }
      set {
        if (value == _playerXWins) {
          return;
        }

        _playerXWins = value;
        RaisePropertyChanged(() => PlayerXWins);
      }
    }

    public int PlayerOWins {
      get {
        return _playerOWins;
      }
      set {
        if (value == _playerOWins) {
          return;
        }

        _playerOWins = value;
        RaisePropertyChanged(() => PlayerOWins);
      }
    }

    public ObservableCollection<GameCell> GameBoard { get; private set; }
    public RelayCommand BackCommand { get; private set; }
    public RelayCommand NewGameCommand { get; private set; }
    public RelayCommand<GameCell> CellClickedCommand { get; private set; }

    private void UpdateBoardStats() {
      PlayerTurn = _ticTacToeGame.PlayerTurn == Player.O ? "o" : "x";
      PlayerXWins = TicTacToeGame.WinCountX;
      PlayerOWins = TicTacToeGame.WinCountO;
    }

    private void OnCellClicked(GameCell cell) {
      var updatedBoard = _ticTacToeGame.NewMoveMade(cell.Row, cell.Column);
      int count = 0;
      for (int i = 0; i < TicTacToeGame.BoardSize; ++i) {
        for (int j = 0; j < TicTacToeGame.BoardSize; ++j) {
          GameBoard[count++].State = updatedBoard[i, j];
        }
      }

      UpdateBoardStats();
    }

    private void NewGame() {
      _ticTacToeGame = new TicTacToeGame();
      GameBoard.Clear();

      for (int i = 0; i < 9; ++i) {
        GameBoard.Add(new GameCell(i));
      }

      UpdateBoardStats();
    }
  }
}
