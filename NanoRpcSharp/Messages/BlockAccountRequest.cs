namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Returns the account containing block.
    /// </summary>
    public class BlockAccountRequest : RequestBase<BlockAccount>
    {
        public BlockAccountRequest(Hex32 block)
            : base("block_account")
        {
            this.Block = block;
        }

        public Hex32 Block { get; set; }
    }
}
