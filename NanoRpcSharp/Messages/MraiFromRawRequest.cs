namespace NanoRpcSharp.Messages
{
    using System.Numerics;

    /// <summary>
    /// Divide a raw amount down by the Mrai ratio.
    /// </summary>
    public class MraiFromRawRequest : RequestBase<DecimalAmount>
    {
        public MraiFromRawRequest(BigInteger amount)
            : base("mrai_from_raw")
        {
            this.Amount = amount;
        }

        public BigInteger Amount { get; set; }
    }
}
