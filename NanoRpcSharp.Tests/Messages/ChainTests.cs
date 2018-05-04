namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class ChainTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new ChainRequest("000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F", 1);
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""chain"",
  ""block"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F"",  
  ""count"": 1
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
 ""blocks"" : [  
  ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F""
  ] 
}
";
            var obj = NanoRpcClient.Deserialize<Chain>(validJson);

            Assert.Single(obj.Blocks);
            Assert.Equal("000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F", obj.Blocks[0]);
        }
    }
}
