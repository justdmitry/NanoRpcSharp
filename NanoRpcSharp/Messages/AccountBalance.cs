namespace NanoRpcSharp.Messages
{
    public class AccountBalance
    {
        public UInt256 Balance { get; set; }

        public UInt256 Pending { get; set; }
    }
}
