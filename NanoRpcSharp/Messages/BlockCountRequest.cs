namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Reports the number of blocks in the ledger and unchecked synchronizing blocks.
    /// </summary>
    public class BlockCountRequest : RequestBase<BlockCount>
    {
        public BlockCountRequest()
            : base("block_count")
        {
            // Nothing
        }
    }
}
