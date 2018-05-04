namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Returns the voting weight for <see cref="Account"/>
    /// </summary>
    public class AccountWeightRequest : RequestBase<AccountWeight>
    {
        public AccountWeightRequest(Account account)
            : base("account_weight")
        {
            this.Account = account;
        }

        public Account Account { get; set; }
    }
}
