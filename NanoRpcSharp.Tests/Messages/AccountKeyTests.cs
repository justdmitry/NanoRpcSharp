namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountKeyTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountKeyRequest("xrb_1e5aqegc1jb7qe964u4adzmcezyo6o146zb8hm6dft8tkp79za3sxwjym5rx");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""account_key"",  
  ""account"": ""xrb_1e5aqegc1jb7qe964u4adzmcezyo6o146zb8hm6dft8tkp79za3sxwjym5rx""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""key"" : ""3068BB1CA04525BB0E416C485FE6A67FD52540227D267CC8B6E8DA958A7FA039""
}
";
            var obj = NanoRpcClient.Deserialize<AccountKey>(validJson);

            Assert.Equal("3068BB1CA04525BB0E416C485FE6A67FD52540227D267CC8B6E8DA958A7FA039", obj.Key);
        }
    }
}
