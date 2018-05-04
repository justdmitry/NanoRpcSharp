namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Sets the representative for <see cref="Account"/> in wallet
    /// </summary>
    [EnableControlRequired]
    public class AccountRepresentativeSetRequest : RequestBase<AccountRepresentativeSet>
    {
        public AccountRepresentativeSetRequest(Hex32 wallet, Account account, Account representative, Hex8? work = null)
            : base("account_representative_set")
        {
            this.Wallet = wallet;
            this.Account = account;
            this.Representative = representative;
            this.Work = work;
        }

        public Hex32 Wallet { get; set; }

        public Account Account { get; set; }

        public Account Representative { get; set; }

        public Hex8? Work { get; set; }
    }
}
