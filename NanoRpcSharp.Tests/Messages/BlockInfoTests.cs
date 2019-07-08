namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class BlockInfoTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new BlockInfoRequest("87434F8041869A01C8F6F263B87972D7BA443A72E0A97D7A3FD0CCC2358FD6F9");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""block_info"",
  ""hash"": ""87434F8041869A01C8F6F263B87972D7BA443A72E0A97D7A3FD0CCC2358FD6F9""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{
  ""block_account"": ""xrb_1ipx847tk8o46pwxt5qjdbncjqcbwcc1rrmqnkztrfjy5k7z4imsrata9est"",
  ""amount"": ""30000000000000000000000000000000000"",
  ""balance"": ""5606157000000000000000000000000000000"",
  ""height"": ""58"",
  ""local_timestamp"": ""0"",
  ""confirmed"": ""false"",
  ""contents"" : ""{\n
      \""type\"": \""state\"",\n
      \""account\"": \""xrb_1ipx847tk8o46pwxt5qjdbncjqcbwcc1rrmqnkztrfjy5k7z4imsrata9est\"",\n
      \""previous\"": \""CE898C131AAEE25E05362F247760F8A3ACF34A9796A5AE0D9204E86B0637965E\"",\n
      \""representative\"": \""xrb_1stofnrxuz3cai7ze75o174bpm7scwj9jn3nxsn8ntzg784jf1gzn1jjdkou\"",\n
      \""balance\"": \""5606157000000000000000000000000000000\"",\n
      \""link\"": \""5D1AA8A45F8736519D707FCB375976A7F9AF795091021D7E9C7548D6F45DD8D5\"",\n
      \""link_as_account\"": \""xrb_1qato4k7z3spc8gq1zyd8xeqfbzsoxwo36a45ozbrxcatut7up8ohyardu1z\"",\n
      \""signature\"": \""82D41BC16F313E4B2243D14DFFA2FB04679C540C2095FEE7EAE0F2F26880AD56DD48D87A7CC5DD760C5B2D76EE2C205506AA557BF00B60D8DEE312EC7343A501\"",\n
      \""work\"": \""8a142e07a10996d5\""\n
   }\n"",
   ""subtype"": ""send""
}
";
            var obj = NanoRpcClient.Deserialize<BlockInfo>(validJson);

            Assert.Equal("xrb_1ipx847tk8o46pwxt5qjdbncjqcbwcc1rrmqnkztrfjy5k7z4imsrata9est", obj.BlockAccount);
            Assert.Equal(BigInteger.Parse("30000000000000000000000000000000000"), obj.Amount);
            Assert.Equal("5606157000000000000000000000000000000", obj.Balance);
            Assert.Equal(58, obj.Height);
            Assert.Equal(new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero), obj.LocalTimestamp);
            Assert.False(obj.Confirmed);
            Assert.Contains(@"""work"": ""8a142e07a10996d5""", obj.Contents);
            Assert.Equal("send", obj.Subtype);
        }
    }
}
