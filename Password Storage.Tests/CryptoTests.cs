using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Password_Storage.Tests
{
    public class CryptoTests
    {
        [Theory]
        [InlineData("passwordToReverse", "masterKey")]
        public void ReversibilityTest(string password, string masterKey)
        {
            var c = new Crypto();
            string actual = c.Decrypt(c.Crypt(password, masterKey), masterKey);
            Assert.Equal(password, actual);
        }
    }
}
