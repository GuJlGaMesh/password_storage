using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Password_Storage
{
    public class RuleDigit : IRule
    {
        public double Check(string password) => password.Any(ch => char.IsDigit(ch)) ? 1 : 0;
    }
}
