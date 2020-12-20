using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Password_Storage.Tests
{
    public class SpecialGen
    {
        [Theory]
        [InlineData("<>,.\\!@#$%^&*()_+=-/|")]
        public void Special(string expectation)
        {
            var d = new SpecialChar();
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
