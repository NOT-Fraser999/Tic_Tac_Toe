using GalaSoft.MvvmLight;

namespace TicTacToe.Desktop.Model {
  public class GameCell : ObservableObject {
    private int _column;
    private int _row;

    public GameCell(int cellIndex) {
      Row = cellIndex / 3;
      Column = cellIndex % 3;
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
  }
}
