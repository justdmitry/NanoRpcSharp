namespace NanoRpcSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using Xunit;

    /// <summary>
    /// Test to proof <see cref="Newtonsoft.Json.Linq.JToken.DeepEquals"/> behavior (used in messages tests)
    /// </summary>
    public class DeepEqualTests
    {
        [Fact]
        public void EqualValuesAreEqual()
        {
            var val1 = @"
{
  ""att1"" : ""val1"",
  ""att2"" : ""val2""
}
";
            var val2 = val1;

            Assert.True(JToken.DeepEquals(JObject.Parse(val1), JObject.Parse(val2)));
        }

        [Fact]
        public void WhitespaceDoesNotMatter()
        {
            var val1 = @"{ ""att1"" : ""val1"", ""att2"" : ""val2"" }";
            var val2 = "{\"att1\":\"val1\",\r\n\"att2\":\"val2\"}";

            Assert.True(JToken.DeepEquals(JObject.Parse(val1), JObject.Parse(val2)));
        }

        [Fact]
        public void OrderDoesNotMatter()
        {
            var val1 = @"{ ""att1"" : ""val1"", ""att2"" : ""val2"" }";
            var val2 = @"{ ""att2"" : ""val2"", ""att1"" : ""val1"" }";

            Assert.True(JToken.DeepEquals(JObject.Parse(val1), JObject.Parse(val2)));
        }

        [Fact]
        public void DeepValuesAreOk()
        {
            var val1 = @"{ ""att1"" : { ""att2"" : ""val2"" } }";
            var val2 = @"{ ""att1"" : { ""att2"" : ""val2"" } }";

            Assert.True(JToken.DeepEquals(JObject.Parse(val1), JObject.Parse(val2)));
        }

        [Fact]
        public void NotEqualOnDifferentValues()
        {
            var val1 = @"{ ""att1"" : ""val1"", ""att2"" : ""val2"" }";
            var val2 = @"{ ""att1"" : ""val11"", ""att2"" : ""val22"" }";

            Assert.False(JToken.DeepEquals(JObject.Parse(val1), JObject.Parse(val2)));
        }

        [Fact]
        public void NotEqualOnDifferentAttributes()
        {
            var val1 = @"{ ""att1"" : ""val1"", ""att2"" : ""val2"" }";
            var val2 = @"{ ""att1"" : ""val1"", ""att2"" : ""val2"", ""att3"" : ""val3"" }";

            Assert.False(JToken.DeepEquals(JObject.Parse(val1), JObject.Parse(val2)));
        }

        [Fact]
        public void NotEqualOnDeepAttributesMismatch1()
        {
            var val1 = @"{ ""att1"" : { ""att2"" : ""val2"" }}";
            var val2 = @"{ ""att1"" : { ""att2"" : ""val22"" }}";

            Assert.False(JToken.DeepEquals(JObject.Parse(val1), JObject.Parse(val2)));
        }

        [Fact]
        public void NotEqualOnDeepAttributesMismatch2()
        {
            var val1 = @"{ ""att1"" : { ""att2"" : ""val2"" }}";
            var val2 = @"{ ""att1"" : { ""att2"" : ""val2"", ""att3"" : ""val3"" } }";

            Assert.False(JToken.DeepEquals(JObject.Parse(val1), JObject.Parse(val2)));
        }
    }
}
