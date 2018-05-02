namespace NanoRpcSharp.Messages
{
    using System.Numerics;

    /// <summary>
    /// Multiply an krai amount by the krai ratio.
    /// </summary>
    public class KraiToRawRequest : RequestBase<BigIntegerAmount>
    {
        public KraiToRawRequest(BigInteger amount)
            : base("krai_to_raw")
        {
            this.Amount = amount;
        }

        public BigInteger Amount { get; set; }
    }
}
