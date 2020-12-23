using System;

namespace Password_Storage
{
    public class SpecialChar : IGenerator
    {
        private const string speacial = "<>,.\\!@#$%^&*()_+=-/|";
        private readonly Random random = new Random();

        public int MinLength => 1;

        public string GetChar()
        {
            return speacial[index: random.Next(0, speacial.Length)].ToString();
        }
    }
}
