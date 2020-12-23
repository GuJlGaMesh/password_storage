using System;
using System.Collections.Generic;
using System.Text;


namespace Password_Storage
{
    public interface IGenerator
    {
        int MinLength { get; }
        string GetChar();
    }
}
