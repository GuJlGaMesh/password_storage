using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Password_Storage;


namespace PasswordStorage
{
    public class PasswordGenerator
    {
        private readonly IGenerator[] _arrayOfRules;
        private readonly Random _random;

        public PasswordGenerator(IEnumerable<IGenerator> list)
        {
            _arrayOfRules = list.ToArray();
            _random = new Random();
        }

        public string GetPassword()
        {
            var minLength = _arrayOfRules.Max(_ => _.MinLength);
            minLength = Math.Max(minLength, _arrayOfRules.Length);
            minLength = _random.Next(minLength, minLength * 2);
            var password = new StringBuilder("");
            for (var i = 0; i < minLength; i++)
            {
                var rule = _arrayOfRules.OrderBy(_ => _random.Next()).ToList();
                password.Append(rule[0].GetChar());
            }
            return password.ToString();
        }
    }
}
