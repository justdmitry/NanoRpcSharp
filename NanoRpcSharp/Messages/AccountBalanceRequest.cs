namespace NanoRpcSharp.Messages
{
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
