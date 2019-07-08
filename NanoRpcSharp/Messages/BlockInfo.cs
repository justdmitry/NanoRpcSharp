namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;

    public class BlockInfo
    {
        public Account BlockAccount { get; set; }

        public BigInteger Amount { get; set; }

        /// <summary>
        /// The Balance in contents is a uint128.
        /// However, it will be a hex-encoded (like 0000000C9F2C9CD04674EDEA40000000 for 1 Mnano) when the block is a legacy Send Block.
        /// If the block is a State-Block, the same Balance will be a numeric-string (like 1000000000000000000000000000000).
        /// </summary>
        public string Balance { get; set; }

        public int Height { get; set; }

        public DateTimeOffset LocalTimestamp { get; set; }

        public bool Confirmed { get; set; }

        public string Contents { get; set; }

        public string Subtype { get; set; }
    }
}
