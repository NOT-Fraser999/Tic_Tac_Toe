using System;
using GalaSoft.MvvmLight;

namespace TicTacToe.Desktop.Model {
  public class GameCell : ObservableObject {
    private string _cellState;

    public GameCell(int state) {
      CellState = state % 3 == 0 ? "0" : state % 2 == 0 ? "1" : "2";
    }

    public string CellState {
      get {
        return _cellState;
      }
      set {
        if (value == _cellState) {
          return;
        }

        _cellState = value;
        RaisePropertyChanged(() => CellState);
      }
    }
  }
}
