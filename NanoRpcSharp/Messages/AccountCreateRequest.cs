namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Creates a new account, insert next deterministic key in Wallet
    /// </summary>
    [EnableControlRequired]
    public class AccountCreateRequest : RequestBase<AccountCreate>
    {
        public AccountCreateRequest(Hex32 wallet)
            : base("account_create")
        {
            this.Wallet = wallet;
        }

        public Hex32 Wallet { get; set; }

        public bool? Work { get; set; }
    }
}
