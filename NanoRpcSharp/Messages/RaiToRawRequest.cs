namespace NanoRpcSharp.Messages
{
    public class RaiToRawRequest : RequestBase<UInt256Amount>
    {
        public RaiToRawRequest(decimal amount)
            : base("rai_to_raw")
        {
            this.Amount = amount;
        }

        public decimal Amount { get; set; }
    }
}
