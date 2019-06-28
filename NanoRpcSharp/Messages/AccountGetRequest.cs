namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Get account number for the public key.
    /// </summary>
    public class AccountGetRequest : RequestBase<AccountGet>
    {
        public AccountGetRequest(Hex32 key)
            : base("account_get")
        {
            this.Key = key;
        }

        public Hex32 Key { get; set; }
    }
}
