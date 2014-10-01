using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using TicTacToe.Desktop.Model;

namespace TicTacToe.Desktop.ViewModel {
  public class GameViewModel : ViewModelBase {
    private string _playerTurn = "o";

    public GameViewModel() {
      GameBoard = new ObservableCollection<GameCell>();

      for (int i = 0; i < 9; ++i) {
        GameBoard.Add(new GameCell(i));
      }
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

    public ObservableCollection<GameCell> GameBoard { get; private set; } 
  }
}
