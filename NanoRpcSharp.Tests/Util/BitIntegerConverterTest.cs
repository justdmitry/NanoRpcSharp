namespace NanoRpcSharp.Util
{
    using System.Numerics;
    using Newtonsoft.Json;
    using Xunit;

    public class BitIntegerConverterTest
    {
        [Fact]
        public void ItWorks()
        {
            var json = @"
{
  ""val1"": ""123"",
  ""val2"": 12345,
  ""val3"": ""20000000000000000000000000000000000""
}
";
            var obj = JsonConvert.DeserializeObject<TestClass>(json);
            Assert.Equal(123, obj.Val1);
            Assert.Equal(12345, obj.Val2);
            Assert.Equal(BigInteger.Parse("20000000000000000000000000000000000"), obj.Val3);
        }

        private class TestClass
        {
            public BigInteger Val1 { get; set; }

            public BigInteger Val2 { get; set; }

            public BigInteger Val3 { get; set; }
        }
    }
}