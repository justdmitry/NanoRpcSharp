namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Returns a list of pairs of delegator names given <see cref="Account"/> a representative and its balance.
    /// </summary>
    public class DelegatorsRequest : RequestBase<Delegators>
    {
        public DelegatorsRequest(Account account)
            : base("delegators")
        {
            this.Account = account;
        }

        public Account Account { get; set; }
    }
}
