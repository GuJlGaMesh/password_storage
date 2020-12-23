using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Password_Storage
{
    public class RuleSpecial : IRule
    {
        private double _proportion;

        public RuleSpecial() => _proportion = 4;
        public RuleSpecial(double proportion) => _proportion = proportion;
        public double Check(string password)
        {
            int sum = 0;
            foreach (var s in password)
                sum += SpecialSymbols(s);
            return Math.Min(1.0, sum/_proportion);
        }

        private short SpecialSymbols(char s)
        {
            foreach (var c in "<>,.\\!@#$%^&*()_+=-/|")
                if (c == s) return 1;
            return 0;
        }
    }
}
