namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Returns hash & tally weight for recent elections winners
    /// </summary>
    public class ConfirmationHistoryRequest : RequestBase<ConfirmationHistory>
    {
        public ConfirmationHistoryRequest()
            : base("confirmation_history")
        {
            // Nothing
        }
    }
}
