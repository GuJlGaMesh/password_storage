using PasswordStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Password_Storage
{
    public class Storage : IStorage
    {
        private List<Record> _storage;
        public Storage() => _storage = new List<Record>();
        public void Add(Record record) => _storage.Add(record);
        public List<Record> Get() => _storage.Select(s => s).ToList();
        public Record GetByResource(string resource) => _storage.FirstOrDefault(record => record.Resource.Contains(resource, StringComparison.OrdinalIgnoreCase));
    }
    public class Record
    {
        public string Password { get; set; }
        public string Resource { get; set; }
        public string Login { get; set; }
        public string Synopsis { get; set; }
    }
}
