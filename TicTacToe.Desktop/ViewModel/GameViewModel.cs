using System.Collections.ObjectModel;
using System.Diagnostics;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TicTacToe.Desktop.Model;

namespace TicTacToe.Desktop.ViewModel {
  public class GameViewModel : ViewModelBase {
    private string _playerTurn = "o";

    public GameViewModel() {
      NewGameCommand = new RelayCommand(NewGame);
      CellClickedCommand = new RelayCommand<GameCell>(OnCellClicked);
      BackCommand = new RelayCommand(() => Messenger.Default.Send("Options"));
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


    private int _playerXWins;
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


    private int _playerOWins;
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

    private void OnCellClicked(GameCell cell) {
      Debug.WriteLine("Row: {0} Col: {1}", cell.Row, cell.Column);
    }

    private void NewGame() {
      GameBoard = new ObservableCollection<GameCell>();

      for (int i = 0; i < 9; ++i) {
        GameBoard.Add(new GameCell(i));
      }
    }
  }
}
