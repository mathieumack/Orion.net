using System.Windows;
using Orion.Net.Client.Configuration;
using Orion.Net.Scripts.Common.Diagnostics;

namespace Orion.Net.Client.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void connectToServer_Click(object sender, RoutedEventArgs e)
        {
            App.careCenterConnector = new Connector();

            if(EnableProcess.IsChecked.HasValue && EnableProcess.IsChecked.Value)
                App.careCenterConnector.AddCommandService(new ExecuteProcessClientScript(App.careCenterConnector));
            if (EnableSendImage.IsChecked.HasValue && EnableSendImage.IsChecked.Value)
                App.careCenterConnector.AddCommandService(new SendImageContentClientScript(App.careCenterConnector));
            if (EnableSendFile.IsChecked.HasValue && EnableSendFile.IsChecked.Value)
                App.careCenterConnector.AddCommandService(new ExportFileClientScript(App.careCenterConnector));

            await App.careCenterConnector.Connect(ServeurUri.Text, MyName.Text, SupportID.Text);
        }
    }
}