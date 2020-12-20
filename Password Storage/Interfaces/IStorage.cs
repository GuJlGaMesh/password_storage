using PasswordStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Password_Storage
{
    interface IStorage
    {
        
        void Add(Record record);
        List<Record> Get();
        Record GetByResource(string resource);
    }
}
