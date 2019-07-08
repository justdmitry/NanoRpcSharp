namespace NanoRpcSharp.Messages
{
    using System.Numerics;

    /// <summary>
    /// Multiply an BAN amount by the BAN ratio.
    /// </summary>
    public class BanToRawRequest : RequestBase<BigIntegerAmount>
    {
        public BanToRawRequest(BigInteger amount)
            : base("ban_to_raw")
        {
            this.Amount = amount;
        }

        public BigInteger Amount { get; set; }
    }
}