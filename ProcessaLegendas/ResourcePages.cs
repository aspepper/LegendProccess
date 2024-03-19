
using ProcessaLegendas.ViewModels;

namespace ProcessaLegendas
{
    public static class ResourcePages
    {

        public enum PageName
        {
            MainView,
            Component,
            AnalogicInput,
            ConfigurationAnalogicInput,
            SensorClimatico,
            LocalProtocol,
            SensorMicrocontroladorVRP,
            SensorPositionMarker
        }

        public static ViewModelBase GetPage(PageName pageName)
        {
            ViewModelBase? model = null;
            switch (pageName)
            {
                case PageName.MainView:
                    model = new MainViewModel();
                    break;
                //case PageName.Component:
                //    model = new ComponentViewModel();
                //    break;
                //case PageName.AnalogicInput:
                //    model = new AnalogicInViewModel();
                //    break;
                //case PageName.ConfigurationAnalogicInput:
                //    model = new AnalogicInConfigViewModel();
                //    break;
                //case PageName.SensorClimatico:
                //    model = new SensorClimaticoViewModel();
                //    break;
                //case PageName.SensorMicrocontroladorVRP:
                //    model = new SensorMicrocontroladorVRPViewModel();
                //    break;
                //case PageName.LocalProtocol:
                //    model = new LocalProtocolViewModel();
                //    break;
                //case PageName.SensorPositionMarker:
                //    model = new MarcadorDePosicaoViewModel();
                //    break;
            }
            return model??new ViewModelBase();
        }

    }
}
