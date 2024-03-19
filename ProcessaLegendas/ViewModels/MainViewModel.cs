using ReactiveUI;

namespace ProcessaLegendas.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string sourceFileContent = string.Empty;
        private string targetFileContent = string.Empty;

        public string SourceFileContent { get => sourceFileContent; set => this.RaiseAndSetIfChanged(ref sourceFileContent, value); }
        public string TargetFileContent { get => targetFileContent; set => this.RaiseAndSetIfChanged(ref targetFileContent, value); }
    }
}
