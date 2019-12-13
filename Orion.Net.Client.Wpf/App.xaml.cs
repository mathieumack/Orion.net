using System.Windows;
using Orion.Net.Client.Configuration;

namespace Orion.Net.Client.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CareCenterConnector careCenterConnector;

        public App()
        {
            Exit += App_Exit;
        }

        private async void App_Exit(object sender, ExitEventArgs e)
        {
            if (careCenterConnector != null)
                await careCenterConnector.DisposeAsync();
        }
    }
}
