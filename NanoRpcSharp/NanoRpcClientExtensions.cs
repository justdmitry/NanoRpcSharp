namespace NanoRpcSharp
{
    using System.Threading.Tasks;
    using NanoRpcSharp.Messages;

    public static class NanoRpcClientExtensions
    {
        #region Accounts

        /// <summary>
        /// Returns how many RAW is owned and how many have not yet been received by <see cref="Account"/>
        /// </summary>
        public static Task<AccountBalance> AccountBalanceAsync(this NanoRpcClient client, Account account)
        {
            return client.SendAsync(new AccountBalanceRequest(account));
        }

        /// <summary>
        /// Get number of blocks for a specific <see cref="Account"/>
        /// </summary>
        public static async Task<long> AccountBlockCountAsync(this NanoRpcClient client, Account account)
        {
            var r = await client.SendAsync(new AccountBlockCountRequest(account));
            return r.BlockCount;
        }

        /// <summary>
        /// Returns frontier, open block, change representative block, balance, last modified timestamp
        /// from local database & block count for <see cref="Account"/>.
        /// Only works for accounts that have an entry on the ledger, will return "Account not found" otherwise.
        /// </summary>
        public static Task<AccountInfo> AccountInfoAsync(this NanoRpcClient client, Account account, bool representative = false, bool weight = false, bool pending = false)
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

        public static async Task<decimal> KraiFromRawAsync(this NanoRpcClient client, UInt256 amount)
        {
            var r = await client.SendAsync(new KraiFromRawRequest(amount));
            return r.Amount;
        }

        public static async Task<UInt256> KraiToRawAsync(this NanoRpcClient client, decimal amount)
        {
            var r = await client.SendAsync(new KraiToRawRequest(amount));
            return r.Amount;
        }

        public static async Task<decimal> MraiFromRawAsync(this NanoRpcClient client, UInt256 amount)
        {
            var r = await client.SendAsync(new MraiFromRawRequest(amount));
            return r.Amount;
        }

        public static async Task<UInt256> MraiToRawAsync(this NanoRpcClient client, decimal amount)
        {
            var r = await client.SendAsync(new MraiToRawRequest(amount));
            return r.Amount;
        }

        public static async Task<decimal> RaiFromRawAsync(this NanoRpcClient client, UInt256 amount)
        {
            var r = await client.SendAsync(new RaiFromRawRequest(amount));
            return r.Amount;
        }

        public static async Task<UInt256> RaiToRawAsync(this NanoRpcClient client, decimal amount)
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
