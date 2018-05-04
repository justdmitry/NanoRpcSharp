namespace NanoRpcSharp.Messages
{
    using System.Collections.Generic;

    public class AccountsBalances
    {
        public Dictionary<Account, AccountBalance> Balances { get; set; }
    }
}
