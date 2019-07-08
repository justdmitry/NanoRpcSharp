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
        /// Sends <see cref="AccountBalanceRequest"/>.
        /// </summary>
        public static Task<AccountBalance> AccountBalanceAsync(this INanoRpcClient client, Account account)
        {
            return client.SendAsync(new AccountBalanceRequest(account));
        }

        /// <summary>
        /// Sends <see cref="AccountBlockCountRequest"/>.
        /// </summary>
        public static async Task<long> AccountBlockCountAsync(this INanoRpcClient client, Account account)
        {
            var r = await client.SendAsync(new AccountBlockCountRequest(account));
            return r.BlockCount;
        }

        /// <summary>
        /// Sends <see cref="AccountInfoRequest"/>.
        /// </summary>
        public static Task<AccountInfo> AccountInfoAsync(this INanoRpcClient client, Account account, bool? representative = null, bool? weight = null, bool? pending = null)
        {
            return client.SendAsync(new AccountInfoRequest(account)
            {
                Representative = representative,
                Weight = weight,
                Pending = pending,
            });
        }

        /// <summary>
        /// Sends <see cref="AccountCreateRequest"/>.
        /// </summary>
        public static async Task<Account> AccountCreateAsync(this INanoRpcClient client, Hex32 wallet, bool work = true)
        {
            var r = await client.SendAsync(new AccountCreateRequest(wallet) { Work = work });
            return r.Account;
        }

        /// <summary>
        /// Sends <see cref="AccountGetRequest"/>.
        /// </summary>
        public static async Task<Account> AccountGetAsync(this INanoRpcClient client, Hex32 key)
        {
            var r = await client.SendAsync(new AccountGetRequest(key));
            return r.Account;
        }

        /// <summary>
        /// Sends <see cref="AccountHistoryRequest"/>.
        /// </summary>
        public static Task<AccountHistory> AccountHistoryAsync(this INanoRpcClient client, Account account, bool raw = false, int count = -1, Hex32? head = null)
        {
            return client.SendAsync(new AccountHistoryRequest(account, count)
            {
                Raw = raw,
                Head = head,
            });
        }

        /// <summary>
        /// Sends <see cref="AccountListRequest"/>.
        /// </summary>
        public static async Task<List<Account>> AccountListAsync(this INanoRpcClient client, Hex32 wallet)
        {
            var r = await client.SendAsync(new AccountListRequest(wallet));
            return r.Accounts;
        }

        /// <summary>
        /// Sends <see cref="AccountMoveRequest"/>.
        /// </summary>
        public static async Task<int> AccountsMoveAsync(this INanoRpcClient client, Hex32 source, Hex32 wallet, params Account[] accounts)
        {
            var r = await client.SendAsync(new AccountMoveRequest(source, wallet, accounts));
            return r.Moved;
        }

        /// <summary>
        /// Sends <see cref="AccountKeyRequest"/>.
        /// </summary>
        public static Task<AccountKey> AccountKeyAsync(this INanoRpcClient client, Account account)
        {
            return client.SendAsync(new AccountKeyRequest(account));
        }

        /// <summary>
        /// Sends <see cref="AccountRemoveRequest"/>.
        /// </summary>
        public static async Task<int> AccountsRemoveAsync(this INanoRpcClient client, Hex32 wallet, Account account)
        {
            var r = await client.SendAsync(new AccountRemoveRequest(wallet, account));
            return r.Removed;
        }

        /// <summary>
        /// Sends <see cref="AccountRepresentativeRequest"/>.
        /// </summary>
        public static async Task<Account> AccountRepresentativeAsync(this INanoRpcClient client, Account account)
        {
            var r = await client.SendAsync(new AccountRepresentativeRequest(account));
            return r.Representative;
        }

        /// <summary>
        /// Sends <see cref="AccountRepresentativeSetRequest"/>.
        /// </summary>
        public static async Task<Hex32> AccountRepresentativeSetAsync(this INanoRpcClient client, Hex32 wallet, Account account, Account representative, Hex8? work = null)
        {
            var r = await client.SendAsync(new AccountRepresentativeSetRequest(wallet, account, representative, work));
            return r.Block;
        }

        /// <summary>
        /// Sends <see cref="AccountWeightRequest"/>.
        /// </summary>
        public static async Task<BigInteger> AccountWeightAsync(this INanoRpcClient client, Account account)
        {
            var r = await client.SendAsync(new AccountWeightRequest(account));
            return r.Weight;
        }

        /// <summary>
        /// Sends <see cref="AccountsBalancesRequest"/>.
        /// </summary>
        public static Task<AccountsBalances> AccountsBalancesAsync(this INanoRpcClient client, params Account[] accounts)
        {
            return client.SendAsync(new AccountsBalancesRequest(accounts));
        }

        /// <summary>
        /// Sends <see cref="AccountsCreateRequest"/>.
        /// </summary>
        public static async Task<Account[]> AccountsCreateAsync(this INanoRpcClient client, Hex32 wallet, byte count, bool work = false)
        {
            var r = await client.SendAsync(new AccountsCreateRequest(wallet, count, work));
            return r.Accounts;
        }

        /// <summary>
        /// Sends <see cref="AccountsFrontiersRequest"/>.
        /// </summary>
        public static Task<AccountsFrontiers> AccountsFrontiersAsync(this INanoRpcClient client, params Account[] accounts)
        {
            return client.SendAsync(new AccountsFrontiersRequest(accounts));
        }

        /// <summary>
        /// Sends <see cref="AccountsPendingRequest"/>.
        /// </summary>
        public static Task<AccountsPending> AccountsPendingAsync(this INanoRpcClient client, int count, params Account[] accounts)
        {
            return client.SendAsync(new AccountsPendingRequest(count, accounts));
        }

        /// <summary>
        /// Sends <see cref="AccountsPendingWithAmountRequest"/>.
        /// </summary>
        public static Task<AccountsPendingWithAmount> AccountsPendingAsync(this INanoRpcClient client, BigInteger threshold, int count, Account[] accounts)
        {
            return client.SendAsync(new AccountsPendingWithAmountRequest(threshold, count, accounts));
        }

        /// <summary>
        /// Sends <see cref="AccountsPendingWithAmountSourceRequest"/>.
        /// </summary>
        public static Task<AccountsPendingWithAmountSource> AccountsPendingWithSourceAsync(this INanoRpcClient client, BigInteger threshold, int count, Account[] accounts)
        {
            return client.SendAsync(new AccountsPendingWithAmountSourceRequest(threshold, count, accounts));
        }

        /// <summary>
        /// Sends <see cref="ValidateAccountNumberRequest"/>.
        /// </summary>
        public static async Task<byte> ValidateAccountNumberAsync(this INanoRpcClient client, string account)
        {
            var r = await client.SendAsync(new ValidateAccountNumberRequest(account));
            return r.Valid;
        }

        #endregion

        #region Blocks

        /// <summary>
        /// Sends <see cref="BlockAccountRequest"/>.
        /// </summary>
        public static async Task<Account> BlockAccountAsync(this INanoRpcClient client, Hex32 block)
        {
            var r = await client.SendAsync(new BlockAccountRequest(block));
            return r.Account;
        }

        /// <summary>
        /// Sends <see cref="BlockCountRequest"/>.
        /// </summary>
        public static Task<BlockCount> BlockCountAsync(this INanoRpcClient client)
        {
            return client.SendAsync(new BlockCountRequest());
        }

        /// <summary>
        /// Sends <see cref="BlockCountByTypeRequest"/>.
        /// </summary>
        public static Task<BlockCountByType> BlockCountByTypeAsync(this INanoRpcClient client)
        {
            return client.SendAsync(new BlockCountByTypeRequest());
        }

        /// <summary>
        /// Sends <see cref="ChainRequest"/>.
        /// </summary>
        public static Task<Chain> ChainAsync(this INanoRpcClient client, Hex32 block, long count = -1)
        {
            return client.SendAsync(new ChainRequest(block, count));
        }

        #endregion

        #region Conversion

        /// <summary>
        /// Sends <see cref="BanToRawRequest"/>.
        /// </summary>
        public static async Task<BigInteger> BanToRawAsync(this INanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new BanToRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="KraiFromRawRequest"/>.
        /// </summary>
        public static async Task<BigInteger> KraiFromRawAsync(this INanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new KraiFromRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="KraiToRawRequest"/>.
        /// </summary>
        public static async Task<BigInteger> KraiToRawAsync(this INanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new KraiToRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="MraiFromRawRequest"/>.
        /// </summary>
        public static async Task<BigInteger> MraiFromRawAsync(this INanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new MraiFromRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="MraiToRawRequest"/>.
        /// </summary>
        public static async Task<BigInteger> MraiToRawAsync(this INanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new MraiToRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="RaiFromRawRequest"/>.
        /// </summary>
        public static async Task<BigInteger> RaiFromRawAsync(this INanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new RaiFromRawRequest(amount));
            return r.Amount;
        }

        /// <summary>
        /// Sends <see cref="RaiToRawRequest"/>.
        /// </summary>
        public static async Task<BigInteger> RaiToRawAsync(this INanoRpcClient client, BigInteger amount)
        {
            var r = await client.SendAsync(new RaiToRawRequest(amount));
            return r.Amount;
        }

        #endregion

        #region Confirmation

        /// <summary>
        /// Sends <see cref="BlockConfirmRequest"/>.
        /// </summary>
        public static async Task<byte> BlockConfirmAsync(this INanoRpcClient client, Hex32 hash)
        {
            var r = await client.SendAsync(new BlockConfirmRequest(hash));
            return r.Started;
        }

        /// <summary>
        /// Sends <see cref="ConfirmationHistoryRequest"/>.
        /// </summary>
        public static Task<ConfirmationHistory> ConfirmationHistoryAsync(this INanoRpcClient client)
        {
            return client.SendAsync(new ConfirmationHistoryRequest());
        }

        #endregion

        public static Task<Version> VersionAsync(this INanoRpcClient client)
        {
            return client.SendAsync(new VersionRequest());
        }
    }
}
