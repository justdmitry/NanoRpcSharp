namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Check whether <see cref="Account"/> is a valid account number.
    /// </summary>
    public class ValidateAccountNumberRequest : RequestBase<ValidateAccountNumber>
    {
        public ValidateAccountNumberRequest(string account)
            : base("validate_account_number")
        {
            this.Account = account;
        }

        public string Account { get; set; }
    }
}
