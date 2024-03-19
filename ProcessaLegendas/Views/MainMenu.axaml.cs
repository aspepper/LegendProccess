using Avalonia.Controls;
using ProccessTextFiles;
using ProcessaLegendas.ViewModels;
using Splat.ApplicationPerformanceMonitoring;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ProcessaLegendas.Views
{
    public partial class MainMenu : UserControl
    {

        private IEnumerable<string>? fileSourceContent;
        private IEnumerable<string>? fileTargetContent;

        public MainMenu()
        {
            InitializeComponent();
            ButtonOpenSourceFile.Click += ButtonOpenSourceFile_Click;
            ButtonOpenTargetFile.Click += ButtonOpenTargetFile_Click;
        }

        private void ButtonOpenSourceFile_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var w = this.Parent;
            while (w is not Window)
                if (w!.Parent == null)
                    break;
                else
                    w = w.Parent;

            if (w is Window)
            {
                var FilePath = ((MainWindow)w).OpenFileDialog();
                if (FilePath != null)
                {
                    ProcessTextFiles pf = new();
                    fileSourceContent = pf.ReadFileSBV(FilePath).Result;
                    ((MainViewModel)((MainWindow)w).CurrentContentView.Content!).SourceFileContent = pf.ListToString(fileSourceContent);
                }
            }
        }

        private void ButtonOpenTargetFile_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var w = this.Parent;
            while (w is not Window)
                if (w!.Parent == null)
                    break;
                else
                    w = w.Parent;

            if (w is Window)
            {
                var filePath = ((MainWindow)w).OpenFileDialog();
                if (filePath != null)
                {
                    ProcessTextFiles pf = new();
                    fileTargetContent = pf.ReadFileSBV(filePath).Result;
                    string pathDestination = Path.GetDirectoryName(filePath);
                    ((MainViewModel)((MainWindow)w).CurrentContentView.Content!).TargetFileContent = pf.InsertTimes(fileSourceContent, fileTargetContent, Path.Combine(pathDestination, "destination.sbv"));
                }
            }
        }
    }
}
