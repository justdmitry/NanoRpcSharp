namespace NanoRpcSharp.Messages
{
    using System.Numerics;

    /// <summary>
    /// Multiply an rai amount by the rai ratio.
    /// </summary>
    public class RaiToRawRequest : RequestBase<BigIntegerAmount>
    {
        public RaiToRawRequest(BigInteger amount)
            : base("rai_to_raw")
        {
            this.Amount = amount;
        }

        public BigInteger Amount { get; set; }
    }
}
