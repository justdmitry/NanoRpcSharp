namespace NanoRpcSharp.Messages
{
    using System.Collections.Generic;
    using System.Numerics;

    public class AccountsPendingWithAmountSource
    {
        public Dictionary<Account, Dictionary<Hex32, AmountAndSource>> Blocks { get; set; }

        public class AmountAndSource
        {
            public BigInteger Amount { get; set; }

            public Account Source { get; set; }
        }
    }
}
