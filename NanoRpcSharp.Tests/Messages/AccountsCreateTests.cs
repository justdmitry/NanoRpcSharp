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
     ""xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000"",   
     ""xrb_1e5aqegc1jb7qe964u4adzmcezyo6o146zb8hm6dft8tkp79za3s00000000""
  ]  
}
";
            var obj = NanoRpcClient.Deserialize<AccountsCreate>(validJson);

            Assert.Equal(
                new Account[] 
                {
                    "xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000",
                    "xrb_1e5aqegc1jb7qe964u4adzmcezyo6o146zb8hm6dft8tkp79za3s00000000",
                },
                obj.Accounts);
        }
    }
}
