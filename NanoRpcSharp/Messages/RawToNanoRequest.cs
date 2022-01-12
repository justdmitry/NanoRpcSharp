namespace NanoRpcSharp.Messages
{
    using System.Numerics;

    /// <summary>
    /// Convert raw amount (10^0) into nano (10^30 raw).
    /// </summary>
    public class RawToNanoRequest : RequestBase<BigIntegerAmount>
    {
        public RawToNanoRequest(BigInteger amount)
            : base("raw_to_nano")
        {
            this.Amount = amount;
        }

        public BigInteger Amount { get; set; }
    }
}
