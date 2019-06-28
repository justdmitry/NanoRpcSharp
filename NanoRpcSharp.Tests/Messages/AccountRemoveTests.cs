namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountRemoveTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountRemoveRequest(
                "000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F",
                "xrb_1111111111111111111111111111111111111111111111111111hifc8npp");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""account_remove"",
  ""wallet"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F"",
  ""account"" : ""xrb_1111111111111111111111111111111111111111111111111111hifc8npp""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{
  ""removed"" : ""1""
}
";
            var obj = NanoRpcClient.Deserialize<AccountRemove>(validJson);

            Assert.Equal(1, obj.Removed);
        }
    }
}
