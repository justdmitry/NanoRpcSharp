namespace NanoRpcSharp.Messages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Moves accounts from source to wallet
    /// </summary>
    [EnableControlRequired]
    public class AccountMoveRequest : RequestBase<AccountMove>
    {
        public AccountMoveRequest(Hex32 source, Hex32 wallet, params Account[] accounts)
            : base("account_move")
        {
            this.Source = source;
            this.Wallet = wallet;
            this.Accounts = accounts.ToList();
        }

        public Hex32 Source { get; set; }

        public Hex32 Wallet { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
