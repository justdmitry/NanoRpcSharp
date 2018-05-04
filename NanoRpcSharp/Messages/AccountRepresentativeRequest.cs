namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Returns the representative for <see cref="Account"/>
    /// </summary>
    public class AccountRepresentativeRequest : RequestBase<AccountRepresentative>
    {
        public AccountRepresentativeRequest(Account account)
            : base("account_representative")
        {
            this.Account = account;
        }

        public Account Account { get; set; }
    }
}
