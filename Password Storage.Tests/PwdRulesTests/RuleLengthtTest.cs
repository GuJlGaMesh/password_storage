using System;
using Xunit;
using PasswordStorage;
using Password_Storage;
namespace Password_Storage
{
    public class RuleLengthTest
    {
        [Theory]
        [InlineData("asdfghgj")]
        public void RuleLegnthDefaultTest(string password)
        {
            double expected = 1;
            var r = new RuleLength();
            double actual = r.Check(password);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("odin12")]
        public void RuleLengthLessThanDefaultTest(string password)
        {
            double expected = 6.0 / 8.0;
            var r = new RuleLength();
            double actual = r.Check(password);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("odin12")]
        public void RuleLengthCustomTest(string password)
        {
            double expected = 6.0 / 10.0;
            var r = new RuleLength(10);
            double actual = r.Check(password);
            Assert.Equal(expected, actual);
        }
    }
}
