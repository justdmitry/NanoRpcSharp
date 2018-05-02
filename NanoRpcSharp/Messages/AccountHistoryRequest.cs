namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Reports send/receive information for an account.
    /// </summary>
    /// <remarks>
    /// Change blocks are skipped, open blocks will appear as receive (unless raw is set to true - see optional parameters below).
    ///
    /// Response will start with the latest block for the account (the frontier), and will list all blocks back to the open block of this account when "count" is set to "-1".
    /// </remarks>
    public class AccountHistoryRequest : RequestBase<AccountHistory>
    {
        public AccountHistoryRequest(Account account, int count = -1)
            : base("account_history")
        {
            this.Account = account;
            this.Count = count > 0 ? count : (int?)null;
        }

        public Account Account { get; set; }

        public int? Count { get; set; }

        public bool Raw { get; set; } = false;

        public Hex32? Head { get; set; }
    }
}
