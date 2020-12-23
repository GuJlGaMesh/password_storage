using System;
using System.Collections.Generic;
using System.Text;
using Password_Storage.Interfaces;

namespace Password_Storage.RuleDescriptors
{
    public class LowerCharDescriptor : IRuleDescriptor
    {
        public string Name => "Lower";
        public string Description => "produce symbols in that range: \"qwertyuiopasdfghjklzxcvbnm\"";

        public IRule CreateRule()
        {
            return new RuleLower();
        }

        public IGenerator GetGenerator()
        {
            return new LowerChar();
        }
    }

}
