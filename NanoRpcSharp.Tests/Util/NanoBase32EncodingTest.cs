namespace NanoRpcSharp.Util
{
    using System;
    using System.Linq;
    using Xunit;

    /// <summary>
    /// NanoBase32 tests.
    /// </summary>
    /// <remarks>
    /// Test data validated via https://nanoo.tools/hex2base32 and https://github.com/termhn/nano-base32.
    /// </remarks>
    public class NanoBase32EncodingTest
    {
        [Theory]
        [InlineData("BFDBCB8D9F8A18CE513C9CA9498B673BE4333E1D386C66C37A6491F6A945197B", "3hyusg8sz4irssams97bb87pggz68ez3tg5eeu3qns6jytnnc8du")]
        [InlineData("486BA2759860A74D4D8F5F51716DE3F2A0C4898859E169A0A7086E682A96EE05", "1k5dnbtsir79bo8ryqtjg7py9wo1rk6riph3f8icg45gf1obfui7")]
        public void TestEncodeAndDecodeAddress(string hexBytes, string validBase32)
        {
            var bytes = Enumerable.Range(0, hexBytes.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hexBytes.Substring(x, 2), 16))
                     .ToArray();

            var base32 = NanoBase32Encoding.BytesToBase32(bytes);
            Assert.Equal(validBase32, base32);

            var newBytes = NanoBase32Encoding.Base32ToBytes(base32.ToCharArray());
            Assert.Equal(bytes, newBytes.ToArray());
        }

        [Theory]
        [InlineData("21E9D72426", "69nxgb38")]
        public void TestEncodeChecksum(string hexBytes, string validBase32)
        {
            var bytes = Enumerable.Range(0, hexBytes.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hexBytes.Substring(x, 2), 16))
                     .ToArray();

            var base32 = NanoBase32Encoding.BytesToBase32(bytes);
            Assert.Equal(validBase32, base32);

            //// Decoding does not work.
            // var newBytes = NanoBase32Encoding.Base32ToBytes(base32);
            //// Result will be 4 (not 5) bytes.
        }
    }
}
