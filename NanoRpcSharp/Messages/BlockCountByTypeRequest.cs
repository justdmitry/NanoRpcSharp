namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Reports the number of blocks in the ledger by type (send, receive, open, change).
    /// </summary>
    public class BlockCountByTypeRequest : RequestBase<BlockCountByType>
    {
        public BlockCountByTypeRequest()
            : base("block_count_type")
        {
            // Nothing
        }
    }
}
