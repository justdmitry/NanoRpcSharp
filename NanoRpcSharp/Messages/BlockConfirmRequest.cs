namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Request confirmation for block from known online representative nodes.
    /// Check results with <see cref="ConfirmationHistoryRequest"/>
    /// </summary>
    public class BlockConfirmRequest : RequestBase<BlockConfirm>
    {
        public BlockConfirmRequest(Hex32 hash)
            : base("block_confirm")
        {
            this.Hash = hash;
        }

        public Hex32 Hash { get; set; }
    }
}
