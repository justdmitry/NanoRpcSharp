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

        public BigInteger? ConfirmedBalance { get; set; }

        public DateTimeOffset ModifiedTimestamp { get; set; }

        public long BlockCount { get; set; }

        public int AccountVersion { get; set; }

        public int ConfirmedHeight { get; set; }

        public Hex32? ConfirmedFrontier { get; set; }

        public Account? Representative { get; set; }

        public Account? ConfirmedRepresentative { get; set; }

        public BigInteger Weight { get; set; }

        public BigInteger Pending { get; set; }

        public BigInteger Receivable { get; set; }

        public BigInteger ConfirmedPending { get; set; }

        public BigInteger ConfirmedReceivable { get; set; }
    }
}
