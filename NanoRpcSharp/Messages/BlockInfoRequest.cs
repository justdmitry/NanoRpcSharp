namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Retrieves a json representation of block (or <b>null</b> when block not found).
    /// </summary>
    /// <remarks>
    /// Returns block account, amount, balance, block height in account chain & local timestamp since version 18.0.
    /// Returns confirmation status & subtype for state block since version 19.0.
    /// </remarks>
    public class BlockInfoRequest : RequestBase<BlockInfo>
    {
        public BlockInfoRequest(Hex32 hash)
            : base("block_info")
        {
            this.Hash = hash;
            this.WellKnownErrors = ErrorsBlockNotFound;
        }

        public Hex32 Hash { get; set; }
    }
}
