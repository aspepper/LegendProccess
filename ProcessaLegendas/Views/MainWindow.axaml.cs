using Avalonia.Controls;
using Avalonia.Platform.Storage;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ProccessTextFiles;
using ProcessaLegendas.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Tmds.DBus.Protocol;

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
            if (topLevel != null)
            {
                if (topLevel.StorageProvider.CanOpen)
                {
                    var file = topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
                    {
                        Title = "Source Legend Text File",
                        AllowMultiple = false,
                    }).Result;
                    foreach (var item in file)
                    {
                        return item.Path.LocalPath;
                    }
                }
                else
                {
                    var box = MessageBoxManager
                        .GetMessageBoxStandard("No Permition", "StorageProvider can not be used on this.",
                            ButtonEnum.Ok);

                    box.ShowWindowDialogAsync(this);
                }
            }
            return "";
            //this.NavigateTo(tcc, ResourcePages.PageName.MainView);
        }

    }
}