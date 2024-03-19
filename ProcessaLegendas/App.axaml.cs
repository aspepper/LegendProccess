using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ProcessaLegendas.ViewModels;
using ProcessaLegendas.Views;
using System.Globalization;

namespace ProcessaLegendas
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            /* Os idiomas estão na pasta Assets/Resources.resx, Assets/Resources.xx-YY.resx, onde xx=cultura; YY=Bigrama País */
            Assets.Resources.Culture = new CultureInfo("pt-BR"); // Português
            //Assets.Resources.Culture = new CultureInfo("en-US"); // Inglês
            //Assets.Resources.Culture = new CultureInfo("it-IT"); // Italiano
            //Assets.Resources.Culture = new CultureInfo("es-ES"); // Espanhol

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}