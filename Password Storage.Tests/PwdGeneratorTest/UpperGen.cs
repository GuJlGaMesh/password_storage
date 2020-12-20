using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Password_Storage.Tests
{
    public class UpperGen
    {
        [Theory]
        [InlineData("QWERTYUIOPASDFGHJKLZXCVBNM")]
        public void Special(string expectation)
        {
            var d = new UpperChar();
            var c = d.GetChar();
            var count = expectation.Length;
            while (count-- > 0)
            {
                Assert.Single(c);
                Assert.Contains(c, expectation);
            }
        }
    }
}
