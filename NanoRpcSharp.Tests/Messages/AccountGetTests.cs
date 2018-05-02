namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountGetTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountGetRequest("3068BB1CA04525BB0E416C485FE6A67FD52540227D267CC8B6E8DA958A7FA039");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""account_get"",  
  ""key"": ""3068BB1CA04525BB0E416C485FE6A67FD52540227D267CC8B6E8DA958A7FA039""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""account"" : ""xrb_1e5aqegc1jb7qe964u4adzmcezyo6o146zb8hm6dft8tkp79za3sxwjym5rx""
}
";
            var obj = NanoRpcClient.Deserialize<AccountCreate>(validJson);

            Assert.Equal("xrb_1e5aqegc1jb7qe964u4adzmcezyo6o146zb8hm6dft8tkp79za3sxwjym5rx", obj.Account);
        }
    }
}
