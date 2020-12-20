using System;
using System.Collections.Generic;
using System.Text;
using Password_Storage.Interfaces;

namespace Password_Storage
{
    public interface IRule : IAction
    {
        double Check(string password);
    }
}
