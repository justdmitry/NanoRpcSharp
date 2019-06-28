namespace NanoRpcSharp.Util
{
    using Newtonsoft.Json;
    using Xunit;

    public class NullableBooleanConverterTest
    {
        [Fact]
        public void ItWorks()
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new NullableBooleanConverter());

            var json = @"
{
  ""val0"": null,
  ""val1"": ""true"",
  ""val2"": 'true',
  ""val3"": true,
  ""val4"": ""false"",
  ""val5"": 'false',
  ""val6"": false,
}
";
            var obj = JsonConvert.DeserializeObject<TestClass>(json, jsonSettings);
            Assert.Null(obj.Val0);
            Assert.True(obj.Val1);
            Assert.True(obj.Val2);
            Assert.True(obj.Val3);
            Assert.False(obj.Val4);
            Assert.False(obj.Val5);
            Assert.False(obj.Val6);
        }

        private class TestClass
        {
            public bool? Val0 { get; set; }

            public bool? Val1 { get; set; }

            public bool? Val2 { get; set; }

            public bool? Val3 { get; set; }

            public bool? Val4 { get; set; }

            public bool? Val5 { get; set; }

            public bool? Val6 { get; set; }
        }
    }
}