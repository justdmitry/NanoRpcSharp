namespace NanoRpcSharp.Messages
{
    public class KraiToRawRequest : RequestBase<UInt256Amount>
    {
        public KraiToRawRequest(decimal amount)
            : base("krai_to_raw")
        {
            this.Amount = amount;
        }

        public decimal Amount { get; set; }
    }
}
