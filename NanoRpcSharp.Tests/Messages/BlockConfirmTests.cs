namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class BlockConfirmTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new BlockConfirmRequest("000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""block_confirm"",  
  ""hash"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""started"" : ""1""
}
";
            var obj = NanoRpcClient.Deserialize<BlockConfirm>(validJson);

            Assert.Equal(1, obj.Started);
        }
    }
}
