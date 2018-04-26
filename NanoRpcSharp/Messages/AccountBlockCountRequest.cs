namespace NanoRpcSharp.Messages
{
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
