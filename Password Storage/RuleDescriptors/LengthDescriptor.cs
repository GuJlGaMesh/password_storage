using System;
using System.Collections.Generic;
using System.Text;
using Password_Storage.Interfaces;

namespace Password_Storage.RuleDescriptors
{
    public class LengthDescriptor : IRuleDescriptor
    {
        public string Name => "Length";
        public string Description => "special type of rules that set up length of the password.";

        public IRule CreateRule()
        {
            return new RuleLength();
        }

        public IGenerator GetGenerator()
        {
            return new LengthChar();
        }
    }
}
