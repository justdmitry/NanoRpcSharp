namespace NanoRpcSharp
{
    using System.Collections.Generic;
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
        /// Sends <see cref="AccountCreateRequest"/>
        /// </summary>
        public static async Task<Account> AccountCreateAsync(this NanoRpcClient client, Hex32 wallet, bool work = true)
        {
            var r = await client.SendAsync(new AccountCreateRequest(wallet) { Work = work });
            return r.Account;
        }

        /// <summary>
        /// Sends <see cref="AccountGet"/>
        /// </summary>
        public static async Task<Account> AccountGetAsync(this NanoRpcClient client, Hex32 key)
        {
            var r = await client.SendAsync(new AccountGetRequest(key));
            return r.Account;
        }

        /// <summary>
        /// Sends <see cref="AccountHistoryAsync"/>
        /// </summary>
        public static Task<AccountHistory> AccountHistoryAsync(this NanoRpcClient client, Account account, bool raw = false, int count = -1, Hex32? head = null)
        {
            return client.SendAsync(new AccountHistoryRequest(account, count)
            {
                Raw = raw,
                Head = head,
            });
        }

        /// <summary>
        /// Sends <see cref="AccountListAsync"/>
        /// </summary>
        public static async Task<List<Account>> AccountListAsync(this NanoRpcClient client, Hex32 wallet)
        {
            var r = await client.SendAsync(new AccountListRequest(wallet));
            return r.Accounts;
        }

        /// <summary>
        /// Sends <see cref="AccountMoveRequest"/>
        /// </summary>
        public static async Task<int> AccountsMoveAsync(this NanoRpcClient client, Hex32 source, Hex32 wallet, params Account[] accounts)
        {
            var r = await client.SendAsync(new AccountMoveRequest(source, wallet, accounts));
            return r.Moved;
        }

        /// <summary>
        /// Sends <see cref="AccountKeyRequest"/>
        /// </summary>
        public static Task<AccountKey> AccountKeyAsync(this NanoRpcClient client, Account account)
        {
            return client.SendAsync(new AccountKeyRequest(account));
        }

        /// <summary>
        /// Sends <see cref="AccountRemoveRequest"/>
        /// </summary>
        public static async Task<int> AccountsRemoveAsync(this NanoRpcClient client, Hex32 wallet, Account account)
        {
            var r = await client.SendAsync(new AccountRemoveRequest(wallet, account));
            return r.Removed;
        }

        /// <summary>
        /// Sends <see cref="ValidateAccountNumberRequest"/>
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
        public static async Task<BigInteger> KraiFromRawAsync(this NanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new KraiFromRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="KraiToRawRequest"/>
        /// </summary>
        public static async Task<BigInteger> KraiToRawAsync(this NanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new KraiToRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="MraiFromRawRequest"/>
        /// </summary>
        public static async Task<BigInteger> MraiFromRawAsync(this NanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new MraiFromRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="MraiToRawRequest"/>
        /// </summary>
        public static async Task<BigInteger> MraiToRawAsync(this NanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new MraiToRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="RaiFromRawRequest"/>
        /// </summary>
        public static async Task<BigInteger> RaiFromRawAsync(this NanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new RaiFromRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="RaiToRawRequest"/>
        /// </summary>
        public static async Task<BigInteger> RaiToRawAsync(this NanoRpcClient client, BigInteger amount)
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
