namespace NanoRpcSharp.Messages
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Remove account from source to wallet.
    /// </summary>
    [EnableControlRequired]
    public class AccountRemoveRequest : RequestBase<AccountRemove>
    {
        public AccountRemoveRequest(Hex32 wallet, Account account)
            : base("account_remove")
        {
            this.Wallet = wallet;
            this.Account = account;
        }

        public Hex32 Wallet { get; set; }

        public Account Account { get; set; }
    }
}
