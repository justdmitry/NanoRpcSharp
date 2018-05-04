namespace NanoRpcSharp.Messages
{
    using System;

    /// <summary>
    /// Returns a consecutive list of block hashes in the account chain starting at block up to count.
    /// Will list all blocks back to the open block of this chain when count is set to "-1".
    /// The requested block hash is included in the answer.
    /// </summary>
    public class ChainRequest : RequestBase<Chain>
    {
        public ChainRequest(Hex32 block, long count = -1)
            : base("chain")
        {
            if (count < 1 && count != -1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Must be -1 or positive");
            }

            this.Block = block;
            this.Count = count;
        }

        public Hex32 Block { get; set; }

        public long Count { get; set; }
    }
}
