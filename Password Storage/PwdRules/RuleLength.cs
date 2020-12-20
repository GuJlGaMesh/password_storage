using System;
using System.Collections.Generic;
using System.Text;

namespace Password_Storage
{
    public class RuleLength : IRule
    {
        private double _ethos;
        public RuleLength() => _ethos = 8;
        public RuleLength(int length)
        {
            if (length > 0) _ethos = length;
            else _ethos = 8;
        }
        public double Check(string password) => Math.Min(1, password.Length / _ethos);

    }
}
