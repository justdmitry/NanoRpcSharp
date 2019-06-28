namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Returns a list of block hashes which have not yet been received by these <see cref="Account"/>.
    /// </summary>
    /// <remarks>See also: <seealso cref="AccountsPendingRequest"/>,. <seealso cref="AccountsPendingWithAmountSourceRequest"/></remarks>
    public class AccountsPendingWithAmountRequest : RequestBase<AccountsPendingWithAmount>
    {
        public AccountsPendingWithAmountRequest(BigInteger threshold, int count, params Account[] accounts)
            : base("accounts_pending")
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Must be positive");
            }

            this.Accounts = accounts;
            this.Count = count;
            this.Threshold = threshold;
        }

        public Account[] Accounts { get; set; }

        public int Count { get; set; }

        public BigInteger Threshold { get; set; }
    }
}
