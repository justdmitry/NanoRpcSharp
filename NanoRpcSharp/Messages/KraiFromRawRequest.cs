namespace NanoRpcSharp.Messages
{
    using System.Numerics;

    /// <summary>
    /// Divide a raw amount down by the krai ratio.
    /// </summary>
    public class KraiFromRawRequest : RequestBase<DecimalAmount>
    {
        public KraiFromRawRequest(BigInteger amount)
            : base("krai_from_raw")
        {
            this.Amount = amount;
        }

        public BigInteger Amount { get; set; }
    }
}
