using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PasswordHandler.Models;

namespace PasswordHandler.Utils
{
    public class RuleListcs<T>
    {
        private List<T> _rules = new List<T>();
        public RuleListcs(List<T> rules)
        {
            _rules = rules;
        }
        public List<T> GetListWithRules(Store store)
        {
            var rules = new List<T>();
            if (store.SpecialChar)
                rules.Add(_rules[0]); // special
            if (store.LowerChar)
                rules.Add(_rules[1]); // lower
            if (store.UpperChar)
                rules.Add(_rules[2]); // upper
            if (store.Digits) // digits
                rules.Add(_rules[3]);
            if (store.Length)
                rules.Add(_rules[4]); // length
            return rules;
        }
        public List<T> GetListWithRules() => _rules;
    }
}
