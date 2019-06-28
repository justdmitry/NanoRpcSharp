namespace NanoRpcSharp
{
    using System;
    using Xunit;

    public class AccountTests
    {
        [Theory]
        [InlineData("xrb_1111111111111111111111111111111111111111111111111111hifc8npp")]
        [InlineData("nano_1111111111111111111111111111111111111111111111111111hifc8npp")]
        [InlineData("ban_1111111111111111111111111111111111111111111111111111hifc8npp")]
        public void ValidPrefixes(string value)
        {
            Assert.True(Account.TryParse(value, out var account));
            Assert.Equal(value, account.ToString());
        }

        [Theory]
        [InlineData("bla_1111111111111111111111111111111111111111111111111111hifc8npp")]
        public void InvalidPrefixes(string value)
        {
            Assert.False(Account.TryParse(value, out _));
        }

        [Theory]
        [InlineData(null)] // null
        [InlineData("")] // empty string
        [InlineData(" ")] // whitespaces
        public void NullValues(string value)
        {
            Assert.Throws<ArgumentNullException>(() => Account.Parse(value));
        }

        [Fact]
        public void EmptyTests()
        {
            Assert.Equal("xrb_1111111111111111111111111111111111111111111111111111hifc8npp", Account.Empty.ToString());
            Assert.Equal("xrb_1111111111111111111111111111111111111111111111111111hifc8npp", default(Account).ToString());
        }

        [Theory]
        [InlineData("xxx_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3", false)] // wrong prefix
        [InlineData("xrb_1111111111111111111111111111111111111111111111111111hifc8n", false)] // wrong length
        [InlineData("xrb_1111111111111111111111111111111111111111111111111111hifc8npp111", false)] // wrong length #2
        [InlineData("xrb_11111111111111111111111111111111_11111#1111111111111hifc8npp", false)] // wrong chars
        [InlineData("xrb_1111111111111111111111111111111111111111111111111111hifc9npp", false)] // wrong checksum
        [InlineData("xrb_1111111111111111111111111111111111111111111111111111hifc8npp", true)]
        [InlineData("xrb_1ipx847tk8o46pwxt5qjdbncjqcbwcc1rrmqnkztrfjy5k7z4imsrata9est", true)]
        [InlineData("xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3", true)]
        [InlineData("xrb_15dng9kx49xfumkm4q6qpaxneie6oynebiwpums3ktdd6t3f3dhp69nxgb38", true)]
        public void TryParseTests(string value, bool expectedResult)
        {
            if (expectedResult)
            {
                Assert.True(Account.TryParse(value, out var account));
                Assert.Equal(value, account.ToString());
            }
            else
            {
                Assert.False(Account.TryParse(value, out _));
            }
        }
    }
}
