using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Password_Storage.Tests
{
    public class DigitGen
    {
        [Theory]
        [InlineData("0123456789")]
        public void Digit(string expectation)
        {
            var d = new DigitChar();
            var c = d.GetChar();
            var count = expectation.Length;
            while (count-- > 0)
            {
                Assert.Single(c);
                Assert.InRange(c, "0", "9");
            }
        }
    }
}
