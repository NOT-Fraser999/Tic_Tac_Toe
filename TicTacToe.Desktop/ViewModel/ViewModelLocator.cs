using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace TicTacToe.Desktop.ViewModel {
  public class ViewModelLocator {
    static ViewModelLocator() {
      ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
      SimpleIoc.Default.Register<GameViewModel>();
    }

    [SuppressMessage("Microsoft.Performance",
      "CA1822:MarkMembersAsStatic",
      Justification = "This non-static member is needed for data binding purposes.")]
    public GameViewModel Main {
      get {
        return ServiceLocator.Current.GetInstance<GameViewModel>();
      }
    }

    public static void Cleanup() {}
  }
}
