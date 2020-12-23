using System;

namespace Password_Storage
{
    public class LowerChar : IGenerator
    {
        
        private const string lowerCase = "abcdefghijklmnopqursuvwxyz";
        private readonly Random random = new Random();

        public virtual int MinLength => 1;

        public string GetChar() => lowerCase[random.Next(0, lowerCase.Length)].ToString();
    }
}

