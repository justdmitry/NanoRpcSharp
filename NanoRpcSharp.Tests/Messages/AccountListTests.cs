namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountListTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountListRequest("000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""account_list"",
  ""wallet"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{
  ""accounts"" : [
  ""xrb_1111111111111111111111111111111111111111111111111111hifc8npp""
  ]
}
";
            var obj = NanoRpcClient.Deserialize<AccountList>(validJson);

            Assert.Equal("xrb_1111111111111111111111111111111111111111111111111111hifc8npp", obj.Accounts[0]);
        }
    }
}
