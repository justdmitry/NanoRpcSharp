namespace NanoRpcSharp
{
    using System;
    using Xunit;

    public class AccountTests
    {
        [Theory]
        [InlineData("xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3")]
        [InlineData("xrb_1111111111111111111111111111111111111111111111111111hifc8npp")]
        [InlineData("nano_1111111111111111111111111111111111111111111111111111hifc8npp")]
        [InlineData("ban_1111111111111111111111111111111111111111111111111111hifc8npp")]
        public void ValidAccount(string value)
        {
            var account = new Account(value);
            Assert.Equal(value, account.ToString());
        }

        [Theory]
        [InlineData("xxx_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3")] // wrong prefix
        [InlineData("xrb_1111111111111111111111111111111111111111111111111111hifc8n")] // wrong length
        [InlineData("xrb_1111111111111111111111111111111111111111111111111111hifc8npp111")] // wrong length #2
        [InlineData("xrb_11111111111111111111111111111111_11111#1111111111111hifc8npp")] // wrong chars
        public void InvalidAccount(string value)
        {
            Assert.Throws<ArgumentException>(() => new Account(value));
        }
    }
}
