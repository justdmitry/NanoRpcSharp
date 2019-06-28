namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Creates new accounts, insert next deterministic keys in wallet up to count.
    /// </summary>
    [EnableControlRequired]
    public class AccountsCreateRequest : RequestBase<AccountsCreate>
    {
        public AccountsCreateRequest(Hex32 wallet, byte count, bool work = false)
            : base("accounts_create")
        {
            this.Wallet = wallet;
            this.Count = count;
            this.Work = work;
        }

        public Hex32 Wallet { get; set; }

        public byte Count { get; set; }

        public bool Work { get; set; }
    }
}
