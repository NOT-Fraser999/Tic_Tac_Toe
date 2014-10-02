using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace TicTacToe.Desktop.Converters {
  internal class CellStateConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      var cellState = value.ToString();
      string resourceKey;
      switch (cellState) {
        case "0":
          return string.Empty;
        case "1":
          resourceKey = "BlueOImage";
          break;
        case "2":
          resourceKey = "BlueXImage";
          break;
        default:
          throw new NotImplementedException();
      }
      return Application.Current.FindResource(resourceKey) as Image;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }
}
