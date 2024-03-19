using Avalonia.Controls;
using ReactiveUI;
using System.Windows.Input;

namespace ProcessaLegendas.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
#pragma warning disable CA1822 // Mark members as static
        public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

        public ICommand? OpenLoadOriginalLegends { get; }

        public MainMenuViewModel() {
            OpenLoadOriginalLegends = ReactiveCommand.Create((TransitioningContentControl tcc) => OpenLoadOriginalLegends_Action(tcc));
        }

        private void OpenLoadOriginalLegends_Action(TransitioningContentControl tcc)
        {
            this.NavigateTo(tcc, ResourcePages.PageName.MainView);
        }

    }
}
