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
            App.careCenterConnector.AddCommandService(new ExecuteProcessClientScript(App.careCenterConnector));
            App.careCenterConnector.AddCommandService(new SendImageContentClientScript(App.careCenterConnector));

            await App.careCenterConnector.Connect("https://localhost:44359/", MyName.Text, SupportID.Text);
        }
    }
}