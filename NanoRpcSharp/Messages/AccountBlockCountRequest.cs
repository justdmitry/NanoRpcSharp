namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Get number of blocks for a specific <see cref="Account"/>.
    /// </summary>
    public class AccountBlockCountRequest : RequestBase<AccountBlockCount>
    {
        public AccountBlockCountRequest(Account account)
            : base("account_block_count")
        {
            this.Account = account;
        }

        public Account Account { get; set; }
    }
}
