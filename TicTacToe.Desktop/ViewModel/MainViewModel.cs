using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace TicTacToe.Desktop.ViewModel {
  public class MainViewModel : ViewModelBase {
    private readonly GameViewModel _gameViewModel;
    private readonly OptionsViewModel _optionsViewModel;
    private readonly TutorialViewModel _tutorialViewModel;
    private ViewModelBase _currentView;

    public MainViewModel(
      TutorialViewModel tutorialViewModel,
      GameViewModel gameViewModel,
      OptionsViewModel optionsViewModel) {
      _tutorialViewModel = tutorialViewModel;
      _gameViewModel = gameViewModel;
      _optionsViewModel = optionsViewModel;

      Messenger.Default.Register<string>(this, MessageReceived);

      CurrentView = _optionsViewModel;
    }

    public ViewModelBase CurrentView {
      get {
        return _currentView;
      }

      private set {
        if (value == _currentView) {
          return;
        }

        _currentView = value;
        RaisePropertyChanged(() => CurrentView);
      }
    }

    private void MessageReceived(string message) {
      switch (message) {
        case "Tutorial":
          CurrentView = _tutorialViewModel;
          break;
        case "Options":
          CurrentView = _optionsViewModel;
          break;
        case "StartGame":
          CurrentView = _gameViewModel;
          break;
      }
    }
  }
}
