using Avalonia.Controls;
using Avalonia.Platform.Storage;
using ReactiveUI;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProcessaLegendas.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        public ICommand? OpenLoadOriginalLegends { get; }

        public MainMenuViewModel() {
            //OpenLoadOriginalLegends = ReactiveCommand.Create((TransitioningContentControl tcc) => OpenLoadOriginalLegends_ActionAsync(tcc));
        }

    }
}
