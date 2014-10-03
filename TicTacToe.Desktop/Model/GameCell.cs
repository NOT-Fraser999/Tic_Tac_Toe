using GalaSoft.MvvmLight;
using TicTacToe.Portable;

namespace TicTacToe.Desktop.Model {
  public class GameCell : ObservableObject {
    private int _column;
    private int _row;
    private CellState _state;

    public GameCell(int cellIndex) {
      Row = cellIndex / 3;
      Column = cellIndex % 3;

      State = CellState.Default;
    }

    public int Row {
      get {
        return _row;
      }
      private set {
        if (value == _row) {
          return;
        }

        _row = value;
        RaisePropertyChanged(() => Row);
      }
    }

    public int Column {
      get {
        return _column;
      }
      private set {
        if (value == _column) {
          return;
        }

        _column = value;
        RaisePropertyChanged(() => Column);
      }
    }

    public CellState State {
      get {
        return _state;
      }
      set {
        if (value == _state) {
          return;
        }

        _state = value;
        RaisePropertyChanged(() => State);
      }
    }
  }
}
