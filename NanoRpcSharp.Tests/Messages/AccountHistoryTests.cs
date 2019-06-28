namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountHistoryTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountHistoryRequest("xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3", 1);
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""account_history"",
  ""account"": ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"",
  ""count"": 1,
  ""raw"": ""false""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void RequestRawOk()
        {
            var req = new AccountHistoryRequest("xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3")
            {
                Raw = true,
                Head = "991CF190094C00F0B68E2E5F75F6BEE95A2E0BD93CEAA4A6734DB9F19B728948",
            };
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""account_history"",
  ""account"": ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"",
  ""raw"": ""true"",
  ""head"": ""991CF190094C00F0B68E2E5F75F6BEE95A2E0BD93CEAA4A6734DB9F19B728948"",
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{
    ""history"": [{
            ""hash"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F"",
            ""type"": ""receive"",
            ""account"": ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"",
            ""amount"": ""100000000000000000000000000000000""
    }],
    ""previous"": ""EA7A3E46EE1BAB24C078AEA6F82D552E645874C858636BEB81ECA0A340CE7550""
}
";
            var obj = NanoRpcClient.Deserialize<AccountHistory>(validJson);

            Assert.Single(obj.History);
            Assert.Equal("000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F", obj.History[0].Hash);
            Assert.Equal("receive", obj.History[0].Type);
            Assert.Equal("xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3", obj.History[0].Account);
            Assert.Equal(BigInteger.Parse("100000000000000000000000000000000"), obj.History[0].Amount);

            Assert.Equal("EA7A3E46EE1BAB24C078AEA6F82D552E645874C858636BEB81ECA0A340CE7550", obj.Previous);
        }

        [Fact]
        public void ResponseRawOk()
        {
            var validJson = @"
{
    ""history"": [
        {
            ""type"": ""send"",
            ""account"": ""xrb_1111111111111111111111111111111111111111111111111111hifc8npp"",
            ""amount"": ""205676479000000000000000000000000000000"",
            ""destination"": ""xrb_1111111111111111111111111111111111111111111111111111hifc8npp"",
            ""balance"": ""325586539664609129644855132177"",
            ""hash"": ""ECCB8CB65CD3106EDA8CE9AA893FEAD497A91BCA903890CBD7A5C59F06AB9113"",
            ""work"": ""7202df8a7c380578"",
            ""signature"": ""047115CB577AC78F5C66AD79BBF47540DE97A441456004190F22025FE4255285F57010D962601AE64C266C98FA22973DD95AC62309634940B727AC69F0C86D03""
        },
        {
            ""type"": ""send"",
            ""account"": ""xrb_1ipx847tk8o46pwxt5qjdbncjqcbwcc1rrmqnkztrfjy5k7z4imsrata9est"",
            ""amount"": ""7000000000000000000000000000000000000"",
            ""destination"": ""xrb_1ipx847tk8o46pwxt5qjdbncjqcbwcc1rrmqnkztrfjy5k7z4imsrata9est"",
            ""balance"": ""205676479325586539664609129644855132177"",
            ""hash"": ""4270F4FB3A820FE81827065F967A9589DF5CA860443F812D21ECE964AC359E05"",
            ""work"": ""edfd7157025ea461"",
            ""signature"": ""30A5850305AA61185008D4A732AA8527682D239D85457368B6A581F517D5F8C0078DB99B5741B79CC29880387292B64F668C964BE1B50790D3EC7D948396D007""
        }
    ],
    ""previous"": ""4A039AD482C917C266A3D4A2C97849CE69173B6BC775AFC779B9EA5CE446426F""
}
";
            var obj = NanoRpcClient.Deserialize<AccountHistory>(validJson);

            Assert.Equal(2, obj.History.Count);
            Assert.Equal("send", obj.History[0].Type);
            Assert.Equal("xrb_1111111111111111111111111111111111111111111111111111hifc8npp", obj.History[0].Account);
            Assert.Equal(BigInteger.Parse("205676479000000000000000000000000000000"), obj.History[0].Amount);
            Assert.Equal("xrb_1111111111111111111111111111111111111111111111111111hifc8npp", obj.History[0].Destination);
            Assert.Equal(BigInteger.Parse("325586539664609129644855132177"), obj.History[0].Balance);
            Assert.Equal("ECCB8CB65CD3106EDA8CE9AA893FEAD497A91BCA903890CBD7A5C59F06AB9113", obj.History[0].Hash);
            Assert.Equal("7202df8a7c380578", obj.History[0].Work);
            Assert.Equal("047115CB577AC78F5C66AD79BBF47540DE97A441456004190F22025FE4255285F57010D962601AE64C266C98FA22973DD95AC62309634940B727AC69F0C86D03", obj.History[0].Signature);
        }
    }
}
