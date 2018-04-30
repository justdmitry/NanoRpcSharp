namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;

    public class AccountInfo
    {
        public string Frontier { get; set; }

        public string OpenBlock { get; set; }

        public string RepresentativeBlock { get; set; }

        public BigInteger Balance { get; set; }

        public DateTimeOffset ModifiedTimestamp { get; set; }

        public long BlockCount { get; set; }

        public Account? Representative { get; set; }

        public BigInteger Weight { get; set; }

        public BigInteger Pending { get; set; }
    }
}
