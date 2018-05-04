namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Returns a list of block hashes which have not yet been received by these <see cref="Account"/>
    /// </summary>
    /// <remarks>See also: <seealso cref="AccountsPendingWithAmountRequest"/>, <seealso cref="AccountsPendingRequest"/></remarks>
    public class AccountsPendingWithAmountSourceRequest : RequestBase<AccountsPendingWithAmountSource>
    {
        public AccountsPendingWithAmountSourceRequest(BigInteger threshold, int count, params Account[] accounts)
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

        public bool Source { get; } = true;
    }
}
