namespace NanoRpcSharp.Messages
{
    using System.Numerics;

    /// <summary>
    /// Divide a raw amount down by the rai ratio.
    /// </summary>
    public class RaiFromRawRequest : RequestBase<DecimalAmount>
    {
        public RaiFromRawRequest(BigInteger amount)
            : base("rai_from_raw")
        {
            this.Amount = amount;
        }

        public BigInteger Amount { get; set; }
    }
}
