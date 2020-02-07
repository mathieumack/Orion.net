using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Services.AppAuthentication;

namespace Orion.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //.ConfigureAppConfiguration((ctx, builder) =>
            //{
            //    var keyVaultEndpoint = "https://orionnetkeyvault.vault.azure.net/";
            //    if (!string.IsNullOrEmpty(keyVaultEndpoint))
            //    {
            //        var azureServiceTokenProvider = new AzureServiceTokenProvider();
            //        var keyVaultClient = new KeyVaultClient(
            //            new KeyVaultClient.AuthenticationCallback(
            //                azureServiceTokenProvider.KeyVaultTokenCallback));
            //        builder.AddAzureKeyVault(
            //            keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
            //    }
            //})
            .UseStartup<Startup>();
    }
}