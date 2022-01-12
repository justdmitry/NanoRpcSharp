namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Get number of delegators for a specific representative <see cref="Account"/>.
    /// </summary>
    public class DelegatorsCountRequest : RequestBase<DelegatorsCount>
    {
        public DelegatorsCountRequest(Account account)
            : base("delegators_count")
        {
            this.Account = account;
        }

        public Account Account { get; set; }
    }
}
