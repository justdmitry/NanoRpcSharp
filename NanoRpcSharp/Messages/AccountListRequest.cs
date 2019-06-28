namespace NanoRpcSharp.Messages
{
    using System;

    /// <summary>
    /// Lists all the accounts inside wallet.
    /// </summary>
    public class AccountListRequest : RequestBase<AccountList>
    {
        public AccountListRequest(Hex32 wallet)
            : base("account_list")
        {
            this.Wallet = wallet;
        }

        public Hex32 Wallet { get; set; }
    }
}
