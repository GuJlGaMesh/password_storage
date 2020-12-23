using System;

namespace Password_Storage
{
    public class DigitChar : IGenerator
    {
        private const string digits = "0123456789";
        private readonly Random random = new Random();

        public int MinLength => 1;

        public string GetChar() => digits[random.Next(0, digits.Length)].ToString();
    }
}
