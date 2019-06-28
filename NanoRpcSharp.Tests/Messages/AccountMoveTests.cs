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
                "xrb_1111111111111111111111111111111111111111111111111111hifc8npp");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""account_move"",
  ""source"": ""3068BB1CA04525BB0E416C485FE6A67FD52540227D267CC8B6E8DA958A7FA039"",
  ""wallet"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F"",
  ""accounts"" : [
  ""xrb_1111111111111111111111111111111111111111111111111111hifc8npp""
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
