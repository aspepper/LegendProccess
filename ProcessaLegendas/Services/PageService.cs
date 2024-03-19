using ProcessaLegendas.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProcessaLegendas.Services
{
    public static class PageService
    {
        static PageService()
        {
            // Set current page to first on start up
            _CurrentPage = ResourcePages.GetPage(ResourcePages.PageName.MainView) ?? new MainViewModel();

            // Create Observables which will activate to deactivate our commands based on CurrentPage state
            NavigateToCommand = ReactiveCommand.Create<ResourcePages.PageName>((pagename) => NavigateTo(pagename));
        }

        /// <summary>
        /// Gets if the user can navigate to the next page
        /// </summary>
        public static bool CanNavigateNext { get; set; }

        /// <summary>
        /// Gets if the user can navigate to the previous page
        /// </summary>
        public static bool CanNavigatePrevious { get; set; }

        public static ViewModelBase ViewModelBase { get; set; } = new MainViewModel();

        // The default is the first page
        private static ViewModelBase? _CurrentPage;

        /// <summary>
        /// Gets the current page. The property is read-only
        /// </summary>
        public static ViewModelBase CurrentPage
        {
            get => _CurrentPage ?? new ViewModelBase();
            set => _CurrentPage = value;
        }

        public static ICommand NavigateToCommand { get; }

        public static void NavigateTo(ResourcePages.PageName pageName)
        {
            CurrentPage = ResourcePages.GetPage(pageName);
        }
    }
}
