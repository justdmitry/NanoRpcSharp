namespace NanoRpcSharp
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets(typeof(Program).Assembly)
                .Build();

            var endpoint = config["Endpoint"];
            var auth = config["Authorization"];

            var services = new ServiceCollection()
                .AddLogging(x => x.SetMinimumLevel(LogLevel.Debug).AddConsole())
                .BuildServiceProvider();

            var client = new HttpClient() { BaseAddress = new Uri(endpoint) };
            if (!string.IsNullOrEmpty(auth))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
            }

            var logger = services.GetService<ILoggerFactory>().CreateLogger("Program");

            logger.LogDebug("Using endpoint: " + client.BaseAddress);

            var nanoClient = new NanoRpcClient(client, services.GetRequiredService<ILogger<NanoRpcClient>>());

            var ver = await nanoClient.VersionAsync();
            logger.LogInformation($"Server: {ver.NodeVendor}, RPC ver {ver.RpcVersion}, Store ver {ver.StoreVersion}");

            var account = "xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3";
            var balance = await nanoClient.AccountBalanceAsync(account);
            logger.LogInformation($"Account: {account}");
            logger.LogInformation($"Balance RAW:  {balance.Balance.ToBigInteger()}");

            var nanoBalance = await nanoClient.RaiFromRawAsync(balance.Balance);
            logger.LogInformation($"Balance RAI:  {nanoBalance}");
            logger.LogInformation($"Balance NANO: {nanoBalance / 1000000}");

            var valid = await nanoClient.ValidateAccountNumberAsync("xrb_3i7qx5qp645sdjd4ncq1q34fby95zmwotzbi9x1gt1c96ix4uqyian8f0000");
            logger.LogInformation($"Valid: {valid}");

            var info = await nanoClient.AccountInfoAsync(account, true, true, true);
            logger.LogInformation(info.OpenBlock);

            info = await nanoClient.AccountInfoAsync("xrb_3i7qx5qp645sdjd4ncq1q34fby95zmwotzbi9x1gt1c96ix4uqyian8fnao9");
            logger.LogInformation(info.OpenBlock);
        }
    }
}
