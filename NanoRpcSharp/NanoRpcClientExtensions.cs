namespace NanoRpcSharp
{
    using System.Numerics;
    using System.Threading.Tasks;
    using NanoRpcSharp.Messages;

    public static class NanoRpcClientExtensions
    {
        #region Accounts

        /// <summary>
        /// Sends <see cref="AccountBalanceRequest"/>
        /// </summary>
        public static Task<AccountBalance> AccountBalanceAsync(this NanoRpcClient client, Account account)
        {
            return client.SendAsync(new AccountBalanceRequest(account));
        }

        /// <summary>
        /// Sends <see cref="AccountBlockCountRequest"/>
        /// </summary>
        public static async Task<long> AccountBlockCountAsync(this NanoRpcClient client, Account account)
        {
            var r = await client.SendAsync(new AccountBlockCountRequest(account));
            return r.BlockCount;
        }

        /// <summary>
        /// Sends <see cref="AccountInfoRequest"/>
        /// </summary>
        public static Task<AccountInfo> AccountInfoAsync(this NanoRpcClient client, Account account, bool? representative = null, bool? weight = null, bool? pending = null)
        {
            return client.SendAsync(new AccountInfoRequest(account)
            {
                Representative = representative,
                Weight = weight,
                Pending = pending,
            });
        }

        /// <summary>
        /// Check whether <see cref="Account"/> is a valid account number
        /// </summary>
        public static async Task<byte> ValidateAccountNumberAsync(this NanoRpcClient client, Account account)
        {
            var r = await client.SendAsync(new ValidateAccountNumberRequest(account));
            return r.Valid;
        }

        #endregion

        #region Conversion

        /// <summary>
        /// Sends <see cref="KraiFromRawRequest"/>
        /// </summary>
        public static async Task<decimal> KraiFromRawAsync(this NanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new KraiFromRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="KraiToRawRequest"/>
        /// </summary>
        public static async Task<BigInteger> KraiToRawAsync(this NanoRpcClient client, decimal amount)
        {
            var r = await client.SendAsync(new KraiToRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="MraiFromRawRequest"/>
        /// </summary>
        public static async Task<decimal> MraiFromRawAsync(this NanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new MraiFromRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="MraiToRawRequest"/>
        /// </summary>
        public static async Task<BigInteger> MraiToRawAsync(this NanoRpcClient client, decimal amount)
        {
            var r = await client.SendAsync(new MraiToRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="RaiFromRawRequest"/>
        /// </summary>
        public static async Task<decimal> RaiFromRawAsync(this NanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new RaiFromRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="RaiToRawRequest"/>
        /// </summary>
        public static async Task<BigInteger> RaiToRawAsync(this NanoRpcClient client, decimal amount)
        {
            var r = await client.SendAsync(new RaiToRawRequest(amount));
            return r.Amount;
        }

        #endregion

        public static Task<Version> VersionAsync(this NanoRpcClient client)
        {
            return client.SendAsync(new VersionRequest());
        }
    }
}
