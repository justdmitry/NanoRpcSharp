namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountMoveTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountMoveRequest(
                "3068BB1CA04525BB0E416C485FE6A67FD52540227D267CC8B6E8DA958A7FA039",
                "000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F",
                "xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""account_move"",  
  ""source"": ""3068BB1CA04525BB0E416C485FE6A67FD52540227D267CC8B6E8DA958A7FA039"",  
  ""wallet"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F"",  
  ""accounts"" : [
  ""xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000""  
  ]
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""moved"" : ""1""
}
";
            var obj = NanoRpcClient.Deserialize<AccountMove>(validJson);

            Assert.Equal(1, obj.Moved);
        }
    }
}
