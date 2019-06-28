namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountsCreateTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountsCreateRequest("000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F", 2);
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""accounts_create"",
  ""wallet"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F"",
  ""count"": 2,
  ""work"": ""false""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{
  ""accounts"": [
     ""xrb_1111111111111111111111111111111111111111111111111111hifc8npp"",
     ""xrb_1ipx847tk8o46pwxt5qjdbncjqcbwcc1rrmqnkztrfjy5k7z4imsrata9est""
  ]
}
";
            var obj = NanoRpcClient.Deserialize<AccountsCreate>(validJson);

            Assert.Equal(
                new Account[]
                {
                    "xrb_1111111111111111111111111111111111111111111111111111hifc8npp",
                    "xrb_1ipx847tk8o46pwxt5qjdbncjqcbwcc1rrmqnkztrfjy5k7z4imsrata9est",
                },
                obj.Accounts);
        }
    }
}
