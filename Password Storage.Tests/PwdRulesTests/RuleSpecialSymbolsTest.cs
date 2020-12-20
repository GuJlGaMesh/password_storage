using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Password_Storage.Tests
{
    public class RuleSpecialSymbolsTest
    {
        [Theory]
        [InlineData("asd!@#$asd")]
        public void RuleFullSSTest(string password)
        {
            double expected = 1.0;
            var r = new RuleSpecialSymbols();
            double actual = r.Check(password);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("asdsf()")]
        public void RuleHalfSSTest(string password)
        {
            double expected = 0.5;
            var r = new RuleSpecialSymbols();
            double actual = r.Check(password);
            Assert.Equal(expected, actual);
        }
    
}
}
