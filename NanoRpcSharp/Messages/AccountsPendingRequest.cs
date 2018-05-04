namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Returns a list of block hashes which have not yet been received by these <see cref="Account"/>
    /// </summary>
    /// <remarks>See also: <seealso cref="AccountsPendingWithAmountRequest"/>, <seealso cref="AccountsPendingWithAmountSourceRequest"/></remarks>
    public class AccountsPendingRequest : RequestBase<AccountsPending>
    {
        public AccountsPendingRequest(int count, params Account[] accounts)
            : base("accounts_pending")
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Must be positive");
            }

            this.Accounts = accounts;
            this.Count = count;
        }

        public Account[] Accounts { get; set; }

        public int Count { get; set; }
    }
}
