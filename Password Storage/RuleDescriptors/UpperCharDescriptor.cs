using System;
using System.Collections.Generic;
using System.Text;
using Password_Storage.Interfaces;

namespace Password_Storage.RuleDescriptors
{
    public class UpperCharDescriptor : IRuleDescriptor
    {
        public string Name => "Upper";
        public string Description => "produce symbols in that range: \"QWERTYUIOPASDFGHJKLZXCVBNM\"";

        public IRule CreateRule()
        {
            return new RuleUpper();
        }

        public IGenerator GetGenerator()
        {
            return new UpperChar();
        }
    }

}
