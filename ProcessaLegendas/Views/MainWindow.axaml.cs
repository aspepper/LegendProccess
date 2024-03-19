using Avalonia.Controls;
using Avalonia.Platform.Storage;
using ProccessTextFiles;
using ProcessaLegendas.ViewModels;
using System;
using System.Diagnostics;

namespace ProcessaLegendas.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string OpenFileDialog()
        {
            var topLevel = TopLevel.GetTopLevel(this);
            var file = topLevel!.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Source Legend Text File",
                AllowMultiple = false,
            }).Result;
            foreach (var item in file)
            {
                return item.Path.LocalPath;
            }
            return "";
            //this.NavigateTo(tcc, ResourcePages.PageName.MainView);
        }

    }
}