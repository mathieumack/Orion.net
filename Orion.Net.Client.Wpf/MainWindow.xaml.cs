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
            App.careCenterConnector.AddCommandService(new ExecuteProcessClientScript());

            await App.careCenterConnector.Connect("https://supporttoolscarecenter20191127043415.azurewebsites.net/carecenterhub", MyName.Text);
        }
    }
}
