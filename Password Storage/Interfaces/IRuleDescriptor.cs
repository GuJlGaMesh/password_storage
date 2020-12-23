using System;
using System.Collections.Generic;
using System.Text;

namespace Password_Storage.Interfaces
{
    public interface IRuleDescriptor
    {
        string Name { get; }
        string Description { get; }

        IRule CreateRule();
        IGenerator GetGenerator();
    }

}
