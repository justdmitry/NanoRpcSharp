namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;

    public class AccountInfo
    {
        public Hex32 Frontier { get; set; }

        public Hex32 OpenBlock { get; set; }

        public Hex32 RepresentativeBlock { get; set; }

        public BigInteger Balance { get; set; }

        public DateTimeOffset ModifiedTimestamp { get; set; }

        public long BlockCount { get; set; }

        public Account? Representative { get; set; }

        public BigInteger Weight { get; set; }

        public BigInteger Pending { get; set; }
    }
}
