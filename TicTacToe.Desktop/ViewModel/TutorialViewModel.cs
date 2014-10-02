using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace TicTacToe.Desktop.ViewModel {
  public class TutorialViewModel : ViewModelBase {
    public TutorialViewModel() {
      BackCommand = new RelayCommand(() => Messenger.Default.Send("Options"));
    }

    public RelayCommand BackCommand { get; private set; }
  }
}
