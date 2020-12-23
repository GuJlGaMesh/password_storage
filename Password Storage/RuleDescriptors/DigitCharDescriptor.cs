using Password_Storage.Interfaces;

namespace Password_Storage.RuleDescriptors
{
    public class DigitCharDescriptor : IRuleDescriptor
    {

        public string Name => "Digit";
        public string Description => "produce symbols in that range: \"0123456789\"";

        public IRule CreateRule()
        {
            return new RuleDigit();
        }

        public IGenerator GetGenerator()
        {
            return new DigitChar();
        }
    }
}
