using System;
using Xunit;
using PasswordStorage;

namespace Password_Storage
{
    public class RuleLowerTest
    {
        [Theory]
        [InlineData("rthrgrgr")]
        public void RulePositiveLowerTest(string password)
        {
            double expected = 1;
            var r = new RuleLower();
            double actual = r.Check(password);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("DFHDFFFFFFGASF")]
        public void RuleNegativeLowerTest(string password)
        {
            double expected = 0;
            var r = new RuleLower();
            double actual = r.Check(password);
            Assert.Equal(expected, actual);
        }
    }
}
