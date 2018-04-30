namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountInfoTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountInfoRequest("xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""account_info"",  
  ""account"": ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void RequestOk2()
        {
            var req = new AccountInfoRequest("xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3")
            {
                Pending = true,
                Representative = true,
                Weight = true,
            };

            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""account_info"",  
  ""account"": ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"",
  ""representative"": ""true"",  
  ""weight"": ""true"",  
  ""pending"": ""true""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
    ""frontier"": ""FF84533A571D953A596EA401FD41743AC85D04F406E76FDE4408EAED50B473C5"",   
    ""open_block"": ""991CF190094C00F0B68E2E5F75F6BEE95A2E0BD93CEAA4A6734DB9F19B728948"",   
    ""representative_block"": ""991CF190094C00F0B68E2E5F75F6BEE95A2E0BD93CEAA4A6734DB9F19B728948"",   
    ""balance"": ""235580100176034320859259343606608761791"",   
    ""modified_timestamp"": ""1501793775"",   
    ""block_count"": ""33""
}
";
            var obj = NanoRpcClient.Deserialize<AccountInfo>(validJson);

            Assert.Equal("FF84533A571D953A596EA401FD41743AC85D04F406E76FDE4408EAED50B473C5", obj.Frontier);
            Assert.Equal("991CF190094C00F0B68E2E5F75F6BEE95A2E0BD93CEAA4A6734DB9F19B728948", obj.OpenBlock);
            Assert.Equal("991CF190094C00F0B68E2E5F75F6BEE95A2E0BD93CEAA4A6734DB9F19B728948", obj.RepresentativeBlock);
            Assert.Equal(BigInteger.Parse("235580100176034320859259343606608761791"), obj.Balance);
            Assert.Equal(new DateTimeOffset(2017, 8, 3, 20, 56, 15, TimeSpan.Zero), obj.ModifiedTimestamp);
            Assert.Equal(33, obj.BlockCount);
        }

        [Fact]
        public void ResponseOk2()
        {
            var validJson = @"
{  
    ""frontier"": ""FF84533A571D953A596EA401FD41743AC85D04F406E76FDE4408EAED50B473C5"",   
    ""open_block"": ""991CF190094C00F0B68E2E5F75F6BEE95A2E0BD93CEAA4A6734DB9F19B728948"",   
    ""representative_block"": ""991CF190094C00F0B68E2E5F75F6BEE95A2E0BD93CEAA4A6734DB9F19B728948"",   
    ""balance"": ""235580100176034320859259343606608761791"",   
    ""modified_timestamp"": ""1501793775"",   
    ""block_count"": ""33"",
    ""representative"": ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"",   
    ""weight"": ""1105577030935649664609129644855132177"",   
    ""pending"": ""2309370929000000000000000000000000""  
}
";
            var obj = NanoRpcClient.Deserialize<AccountInfo>(validJson);

            Assert.Equal("FF84533A571D953A596EA401FD41743AC85D04F406E76FDE4408EAED50B473C5", obj.Frontier);
            Assert.Equal("991CF190094C00F0B68E2E5F75F6BEE95A2E0BD93CEAA4A6734DB9F19B728948", obj.OpenBlock);
            Assert.Equal("991CF190094C00F0B68E2E5F75F6BEE95A2E0BD93CEAA4A6734DB9F19B728948", obj.RepresentativeBlock);
            Assert.Equal(BigInteger.Parse("235580100176034320859259343606608761791"), obj.Balance);
            Assert.Equal(new DateTimeOffset(2017, 8, 3, 20, 56, 15, TimeSpan.Zero), obj.ModifiedTimestamp);
            Assert.Equal(33, obj.BlockCount);
            Assert.Equal(new Account("xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"), obj.Representative);
            Assert.Equal(BigInteger.Parse("1105577030935649664609129644855132177"), obj.Weight);
            Assert.Equal(BigInteger.Parse("2309370929000000000000000000000000"), obj.Pending);
        }
    }
}
