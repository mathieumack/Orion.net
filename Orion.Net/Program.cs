using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Configuration;


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
            //    var keyVaultEndpoint = GetKeyVaultEndpoint();
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

        //private static string GetKeyVaultEndpoint() => "https://orionnetkeyvault.vault.azure.net/";

    }
}