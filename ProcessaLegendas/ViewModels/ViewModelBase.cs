using Avalonia.Controls;
using ProcessaLegendas.Services;
using ReactiveUI;

namespace ProcessaLegendas.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {

        public ViewModelBase CurrentContentView
        {
            get => PageService.CurrentPage;
            set => PageService.CurrentPage = value;
        }

        public void NavigateTo(TransitioningContentControl tcc, ResourcePages.PageName pageName)
        {
            PageService.CurrentPage = ResourcePages.GetPage(pageName);
            tcc.Content = CurrentContentView;
        }
    }
}
