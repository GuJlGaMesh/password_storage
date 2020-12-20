using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Password_Storage
{
    public class RuleLower : IRule
    {
        public double Check(string password) => password.Any(ch => char.IsLower(ch)) ? 1 : 0;
    }
}
