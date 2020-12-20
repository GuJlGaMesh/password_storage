using System;
using Xunit;
using PasswordStorage;
using Password_Storage;
namespace Password_Storage
{
    public class RuleUpperTest
    {
        //добавить тест данных для разнообразия
        [Theory]
        [InlineData("SDGSDFSDFSF")]
        public void RulePositiveUpperTest(string password)
        {
            double expected = 1.0;
            var r = new RuleUpper();
            double actual = r.Check(password);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("asdsf")]
        public void RuleNegativeUpperTest(string password)
        {
            double expected = 0.0;
            var r = new RuleUpper();
            double actual = r.Check(password);
            Assert.Equal(expected, actual);
        }
    }
}
