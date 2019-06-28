namespace NanoRpcSharp.Extensions
{
    using System;
    using Xunit;

    public class ArrayExtensionsTest
    {
        [Fact]
        public void ReverseTests()
        {
            var array = new[] { 1, 2, 3, 4, 5 };
            array.Reverse();
            Assert.Equal(new[] { 5, 4, 3, 2, 1 }, array);
        }
    }
}
