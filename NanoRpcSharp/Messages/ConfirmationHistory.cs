namespace NanoRpcSharp.Messages
{
    using System.Collections.Generic;
    using System.Numerics;

    public class ConfirmationHistory
    {
        public List<ElectionWinner> Confirmations { get; set; }

        public class ElectionWinner
        {
            public Hex32 Hash { get; set; }

            public BigInteger Tally { get; set; }
        }
    }
}
