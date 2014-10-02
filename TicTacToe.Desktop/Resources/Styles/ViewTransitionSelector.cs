using System;
using System.Windows;
using PixelLab.Wpf.Transitions;
using TicTacToe.Desktop.ViewModel;

namespace TicTacToe.Desktop.Resources.Styles {
  internal class ViewTransitionSelector : TransitionSelector {
    private readonly Transition _backward;
    private readonly Transition _forward;

    public ViewTransitionSelector() {
      _forward = new TranslateTransition {
        Duration = new Duration(new TimeSpan(0, 0, 0, 0, 300)),
        StartPoint = new Point(1, 0)
      };
      _backward = new TranslateTransition {
        Duration = new Duration(new TimeSpan(0, 0, 0, 0, 300)),
        EndPoint = new Point(1, 0),
        IsNewContentTopmost = false
      };
    }

    public override Transition SelectTransition(object oldContent, object newContent) {
      var optionsViewModel = newContent as OptionsViewModel;
      return optionsViewModel != null ? _backward : _forward;
    }
  }
}
