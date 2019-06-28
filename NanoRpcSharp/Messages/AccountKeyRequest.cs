namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Get the public key for <see cref="Account"/>.
    /// </summary>
    public class AccountKeyRequest : RequestBase<AccountKey>
    {
        public AccountKeyRequest(Account account)
            : base("account_key")
        {
            this.Account = account;
        }

        public Account Account { get; set; }
    }
}
