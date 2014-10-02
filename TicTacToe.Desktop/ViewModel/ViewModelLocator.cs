using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace TicTacToe.Desktop.ViewModel {
  public class ViewModelLocator {
    static ViewModelLocator() {
      ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
      SimpleIoc.Default.Register<MainViewModel>();
      SimpleIoc.Default.Register<GameViewModel>();
      SimpleIoc.Default.Register<TutorialViewModel>();
      SimpleIoc.Default.Register<OptionsViewModel>();
    }

    [SuppressMessage("Microsoft.Performance",
      "CA1822:MarkMembersAsStatic",
      Justification = "This non-static member is needed for data binding purposes.")]
    public MainViewModel Main {
      get {
        return ServiceLocator.Current.GetInstance<MainViewModel>();
      }
    }

    public static void Cleanup() {}
  }
}
