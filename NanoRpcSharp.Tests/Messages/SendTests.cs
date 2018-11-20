namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class SendTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new SendRequest(
                "000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F",
                "xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000",
                "xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000",
                1000000,
                "7081e2b8fec9146e");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""send"",  
  ""wallet"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F"",  
  ""source"": ""xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000"",  
  ""destination"": ""xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000"",
  ""amount"": ""1000000"",
  ""id"": ""7081e2b8fec9146e""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""block"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F""
}
";
            var obj = NanoRpcClient.Deserialize<Send>(validJson);

            Assert.Equal("000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F", obj.Block);
        }
    }
}
