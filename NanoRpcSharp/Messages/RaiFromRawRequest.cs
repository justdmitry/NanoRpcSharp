namespace NanoRpcSharp.Messages
{
    public class RaiFromRawRequest : RequestBase<DecimalAmount>
    {
        public RaiFromRawRequest(UInt256 amount)
            : base("rai_from_raw")
        {
            this.Amount = amount;
        }

        public UInt256 Amount { get; set; }
    }
}
