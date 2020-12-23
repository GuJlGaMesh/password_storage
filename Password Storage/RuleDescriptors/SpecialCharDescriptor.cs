using Password_Storage.Interfaces;

namespace Password_Storage.RuleDescriptors
{
    public class SpecialCharDescriptor : IRuleDescriptor
    {
        public string Name => "Special";
        public string Description => "produce symbols in that range: \"<>,.\\!@@#$%^&*()_+=-/|\"";

        public IRule CreateRule()
        {
            return new RuleSpecial();
        }

        public IGenerator GetGenerator()
        {
            return new SpecialChar();
        }
    }

}

