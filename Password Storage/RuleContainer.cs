using System;
using System.Collections.Generic;
using System.Linq;
using Password_Storage.Interfaces;

namespace Password_Storage
{
    public class RuleContainer
    {
        private readonly Dictionary<string, IRuleDescriptor> _descriptors;

        public RuleContainer(IEnumerable<IRuleDescriptor> descriptors)
        {
            _descriptors = descriptors.ToDictionary(_ => _.Name, _ => _);
        }

        public IRuleDescriptor GetByName(string name)
        {
            if (_descriptors.TryGetValue(name, out var descriptor))
            {
                return descriptor;
            }
            throw new KeyNotFoundException($"Rule with name {name} not found.");
        }

        public IEnumerable<IRuleDescriptor> GetAll()
        {
            return _descriptors.Values.ToList();
        }
        public IEnumerable<string> GetNames()
        {
            return _descriptors.Keys.ToList();
        }
    }

}
