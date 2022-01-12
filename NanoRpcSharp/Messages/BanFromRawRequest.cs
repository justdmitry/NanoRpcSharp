namespace NanoRpcSharp.Messages
{
    using System.Numerics;

    /// <summary>
    /// Divide a raw amount down by the BAN ratio.
    /// </summary>
    public class BanFromRawRequest : RequestBase<BigIntegerAmount>
    {
        public BanFromRawRequest(BigInteger amount)
            : base("ban_from_raw")
        {
            this.Amount = amount;
        }

        public BigInteger Amount { get; set; }
    }
}