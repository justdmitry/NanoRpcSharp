﻿namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Returns frontier, open block, change representative block, balance, last modified timestamp
    /// from local database & block count for <see cref="Account"/>.
    /// Only works for accounts that have an entry on the ledger, will return "Account not found" otherwise.
    /// </summary>
    public class AccountInfoRequest : RequestBase<AccountInfo>
    {
        public AccountInfoRequest(Account account)
            : base("account_info")
        {
            this.Account = account;
        }

        public Account Account { get; set; }

        /// <summary>
        /// Additionally returns representative for account.
        /// </summary>
        public bool? Representative { get; set; }

        /// <summary>
        /// Additionally returns voting weight for account.
        /// </summary>
        public bool? Weight { get; set; }

        /// <summary>
        /// Additionally returns pending balance for account.
        /// </summary>
        public bool? Pending { get; set; }
    }
}
