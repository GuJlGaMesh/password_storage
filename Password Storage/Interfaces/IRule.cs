using System;
using System.Collections.Generic;
using System.Text;


namespace Password_Storage
{
    public interface IRule 
    {
        double Check(string password);
    }
}
