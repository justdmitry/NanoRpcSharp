namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class RaiFromRawTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new RaiFromRawRequest(BigInteger.Parse("1000000000000000000000000"));
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""rai_from_raw"",  
  ""amount"": ""1000000000000000000000000""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""amount"": ""1""
}
";
            var obj = NanoRpcClient.Deserialize<DecimalAmount>(validJson);

            Assert.Equal(1M, obj.Amount);
        }
    }
}
