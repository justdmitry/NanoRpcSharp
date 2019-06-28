namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Returns a list of pairs of account and block hash representing the head block for <see cref="Account"/> list.
    /// </summary>
    public class AccountsFrontiersRequest : RequestBase<AccountsFrontiers>
    {
        public AccountsFrontiersRequest(params Account[] accounts)
            : base("accounts_frontiers")
        {
            this.Accounts = accounts;
        }

        public Account[] Accounts { get; set; }
    }
}
