namespace NanoRpcSharp.Messages
{
    public class ValidateAccountNumberRequest : RequestBase<ValidateAccountNumber>
    {
        public ValidateAccountNumberRequest(Account account)
            : base("validate_account_number")
        {
            this.Account = account;
        }

        public Account Account { get; set; }
    }
}
