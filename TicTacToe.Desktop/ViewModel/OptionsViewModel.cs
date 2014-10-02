using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace TicTacToe.Desktop.ViewModel {
  public class OptionsViewModel : ViewModelBase {
    public OptionsViewModel() {
      TutorialCommand = new RelayCommand(() => Messenger.Default.Send("Tutorial"));
      StartGameCommand = new RelayCommand(() => Messenger.Default.Send("StartGame"));
    }

    public RelayCommand TutorialCommand { get; private set; }
    public RelayCommand StartGameCommand { get; private set; }
  }
}
