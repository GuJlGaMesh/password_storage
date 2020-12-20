using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Password_Storage;


namespace PasswordStorage
{
    public class PasswordEstimator
    {
        private readonly List<IRule> _list;

        public PasswordEstimator(IEnumerable<IRule> list)
        {
            _list = (List<IRule>)list;
        }

        public double EstimatePassword(string password)
        {
            double estimate = 0;
            foreach (var r in _list)
            {
                estimate += r.Check(password);
            }
            if (_list is null)
                throw new Exception("list is empty.");
            return estimate / _list.Count;
        }
    }
}
