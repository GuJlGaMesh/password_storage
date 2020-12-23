using System;

namespace Password_Storage
{
   public class UpperChar : IGenerator
    {
        private const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly Random random = new Random();

        public int MinLength => 1;

        public string GetChar() => upperCase[random.Next(0, upperCase.Length)].ToString();
    }
}
