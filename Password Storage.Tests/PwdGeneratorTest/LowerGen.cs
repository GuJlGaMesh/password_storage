using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Password_Storage.Tests
{
    public class LowerGen
    {
        [Theory]
        [InlineData("qwertyuiopasdfghjklzxcvbnm")]
        public void Lower(string expectation)
        {
            var d = new LowerChar();
            var count = expectation.Length;
            while (count-- > 0)
            {
                var c = d.GetChar();
                Assert.Single(c);
                Assert.Contains(c, expectation);
            }
        }

    }
}
