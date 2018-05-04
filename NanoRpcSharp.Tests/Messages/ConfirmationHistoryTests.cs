namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class ConfirmationHistoryTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new ConfirmationHistoryRequest();
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""confirmation_history""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
   ""confirmations"": [
        {
            ""hash"": ""EA70B32C55C193345D625F766EEA2FCA52D3F2CCE0B3A30838CC543026BB0FEA"",
            ""tally"": ""80394786589602980996311817874549318248""
        },
        {
            ""hash"": ""F2F8DA6D2CA0A4D78EB043A7A29E12BDE5B4CE7DE1B99A93A5210428EE5B8667"",
            ""tally"": ""68921714529890443063672782079965877749""
        }   
   ]
}
";
            var obj = NanoRpcClient.Deserialize<ConfirmationHistory>(validJson);

            Assert.Equal(2, obj.Confirmations.Count);
            Assert.Equal("EA70B32C55C193345D625F766EEA2FCA52D3F2CCE0B3A30838CC543026BB0FEA", obj.Confirmations[0].Hash);
            Assert.Equal(BigInteger.Parse("80394786589602980996311817874549318248"), obj.Confirmations[0].Tally);
            Assert.Equal("F2F8DA6D2CA0A4D78EB043A7A29E12BDE5B4CE7DE1B99A93A5210428EE5B8667", obj.Confirmations[1].Hash);
            Assert.Equal(BigInteger.Parse("68921714529890443063672782079965877749"), obj.Confirmations[1].Tally);
        }
    }
}
