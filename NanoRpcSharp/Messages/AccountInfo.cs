namespace NanoRpcSharp.Messages
{
    using System;

    public class AccountInfo
    {
        public string Frontier { get; set; }

        public string OpenBlock { get; set; }

        public string RepresentativeBlock { get; set; }

        public UInt256 Balance { get; set; }

        public DateTimeOffset ModifiedTimestamp { get; set; }

        public long BlockCount { get; set; }

        public Account? Representative { get; set; }

        public UInt256 Weight { get; set; }

        public UInt256 Pending { get; set; }
    }
}
