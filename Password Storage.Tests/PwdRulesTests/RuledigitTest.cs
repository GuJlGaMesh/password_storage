using System;
using Xunit;
using PasswordStorage;
using Password_Storage;
namespace Password_Storage
{
    public class RuleDigitTest
    {
        [Theory]
        [InlineData("ddirjdgneg111")]
        [InlineData("#$^#$asfdsg1")]
        public void RulePositiveDigitTest(string password)
        {
            double expected = 1;
            var r = new RuleDigit();
            double actual = r.Check(password);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("onetwothreefourfivesixequalfalse")]
        [InlineData("#$^$#$^%^sdfassdqdew")]
        public void RuleNegativeDigitTest(string password)
        {
            double expected = 0;
            var r = new RuleDigit();
            double actual = r.Check(password);
            Assert.Equal(expected, actual);
        }
    }
}
