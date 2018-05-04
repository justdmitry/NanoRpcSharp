namespace NanoRpcSharp.Messages
{
    using System.Collections.Generic;

    public class AccountsPending
    {
        public Dictionary<Account, List<Hex32>> Blocks { get; set; }
    }
}
