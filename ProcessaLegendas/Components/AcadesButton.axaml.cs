using Avalonia;
using Avalonia.Controls.Primitives;
using System.Windows.Input;

namespace ProcessaLegendas.Components
{
    public class AcadesButtonOpenFileDialog : TemplatedControl
    {
        public static readonly StyledProperty<string?> LabelContentProperty
            = AvaloniaProperty.Register<AcadesButtonOpenFileDialog, string?>(nameof(LabelContent), null, true, Avalonia.Data.BindingMode.OneWay);

        public string? LabelContent
        {
            get => GetValue(LabelContentProperty);
            set => SetValue(LabelContentProperty, value);
        }

        public AcadesButtonOpenFileDialog()
        {
            
        }

    }
}
