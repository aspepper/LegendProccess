using Avalonia;
using Avalonia.Controls.Primitives;
using System.Windows.Input;

namespace ProcessaLegendas.Components
{
    public class AcadesButton : TemplatedControl
    {
        public static readonly StyledProperty<ICommand?> ButtonCommandProperty
            = AvaloniaProperty.Register<AcadesButton, ICommand?>(nameof(ButtonCommand), null, true, Avalonia.Data.BindingMode.OneWay);

        public ICommand? ButtonCommand
        {
            get => GetValue(ButtonCommandProperty);
            set => SetValue(ButtonCommandProperty, value);
        }

        public static readonly StyledProperty<string?> LabelContentProperty
            = AvaloniaProperty.Register<AcadesButton, string?>(nameof(LabelContent), null, true, Avalonia.Data.BindingMode.OneWay);

        public string? LabelContent
        {
            get => GetValue(LabelContentProperty);
            set => SetValue(LabelContentProperty, value);
        }

    }
}
