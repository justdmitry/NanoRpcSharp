namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Returns how many RAW is owned and how many have not yet been received by <see cref="Account"/> list
    /// </summary>
    public class AccountsBalancesRequest : RequestBase<AccountsBalances>
    {
        public AccountsBalancesRequest(params Account[] accounts)
            : base("accounts_balances")
        {
            this.Accounts = accounts;
        }

        public Account[] Accounts { get; set; }
    }
}
