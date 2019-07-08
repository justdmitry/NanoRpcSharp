namespace NanoRpcSharp
{
    using System;
    using System.IO;
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
                .AddJsonFile("appsettings.json", optional: false)
                .AddUserSecrets(typeof(Program).Assembly)
                .Build();

            var endpoint = new Uri(config["Endpoint"]);
            var auth = config["Authorization"];

            var services = new ServiceCollection()
                .AddLogging(x => x.AddConfiguration(config.GetSection("Logging")).AddConsole())
                .AddNanoRpcClient(endpoint)
                    .ConfigureHttpClient(c =>
                    {
                        if (!string.IsNullOrEmpty(auth))
                        {
                            c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                        }
                    })
                    .Services
                .BuildServiceProvider();

            var logger = services.GetRequiredService<ILoggerFactory>().CreateLogger("Program");
            var nanoClient = services.GetRequiredService<INanoRpcClient>();

            var ver = await nanoClient.VersionAsync();
            logger.LogInformation($"Server type: {ver.NetworkType}");
            logger.LogInformation($"Server: {ver.NodeVendor}, RPC ver {ver.RpcVersion}, Store ver {ver.StoreVersion}");

            var genesisAccount = "xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3";
            var balance = await nanoClient.AccountBalanceAsync(genesisAccount);
            logger.LogInformation($"Account: {genesisAccount}");
            logger.LogInformation($"Balance  RAW: {balance.Balance}");

            var raiBalance = await nanoClient.RaiFromRawAsync(balance.Balance);
            logger.LogInformation($"Balance  RAI: {raiBalance}");
            var kraiBalance = await nanoClient.KraiFromRawAsync(balance.Balance);
            logger.LogInformation($"Balance KRAI: {kraiBalance}");
            var mraiBalance = await nanoClient.MraiFromRawAsync(balance.Balance);
            logger.LogInformation($"Balance MRAI: {mraiBalance}");

            var info = await nanoClient.AccountInfoAsync(genesisAccount, true, true, true);
            logger.LogInformation($"Open block: {info.OpenBlock}");

            var hist = await nanoClient.AccountHistoryAsync(genesisAccount, true, 10);
            logger.LogInformation($"Last 10 in history count: {hist.History.Count}");

            var invalidAccount = "xrb_3i7qx5qp645sdjd4ncq1q34fby95zmwotzbi9x1gt1c96ix4uqyian8f0000";
            logger.LogInformation($"Account: {invalidAccount}");
            var valid = await nanoClient.ValidateAccountNumberAsync(invalidAccount);
            logger.LogInformation($"Valid by node: {valid}");
            logger.LogInformation($"Valid by parsing: {Account.TryParse(invalidAccount, out _)}");

            var genesis = "991CF190094C00F0B68E2E5F75F6BEE95A2E0BD93CEAA4A6734DB9F19B728948";
            var genesisUnchecked = await nanoClient.UncheckedGetAsync(genesis);
            logger.LogInformation($"Block {genesis} unchecked: {(genesisUnchecked == null ? " NO " : "YES")}");
            var genesisInfo = await nanoClient.BlockInfoAsync(genesis);
            logger.LogInformation($"Block {genesis} height: {genesisInfo.Height}");

            await Task.Delay(500);
        }
    }
}
