namespace NanoRpcSharp.Messages
{
    using System.Collections.Generic;
    using System.Numerics;

    public class AccountsPendingWithAmount
    {
        public Dictionary<Account, Dictionary<Hex32, BigInteger>> Blocks { get; set; }
    }
}
