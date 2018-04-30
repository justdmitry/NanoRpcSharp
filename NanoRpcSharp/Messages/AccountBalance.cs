namespace NanoRpcSharp.Messages
{
    using System.Numerics;

    public class AccountBalance
    {
        public BigInteger Balance { get; set; }

        public BigInteger Pending { get; set; }
    }
}
