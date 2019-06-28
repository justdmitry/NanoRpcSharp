namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Returns how many RAW is owned and how many have not yet been received by <see cref="Account"/>.
    /// </summary>
    public class AccountBalanceRequest : RequestBase<AccountBalance>
    {
        public AccountBalanceRequest(Account account)
            : base("account_balance")
        {
            this.Account = account;
        }

        public Account Account { get; set; }
    }
}
