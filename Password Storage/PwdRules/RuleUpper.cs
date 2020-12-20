using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Password_Storage
{
    public class RuleUpper : IRule
    {
        public double Check(string password) => password.Any(ch => char.IsUpper(ch)) ? 1 : 0;
    }
}
