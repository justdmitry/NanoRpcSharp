namespace NanoRpcSharp.Messages
{
    using System.Collections.Generic;

    public class AccountsFrontiers
    {
        public Dictionary<Account, Hex32> Frontiers { get; set; }
    }
}
