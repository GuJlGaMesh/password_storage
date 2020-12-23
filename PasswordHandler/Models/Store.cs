using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Password_Storage;
using PasswordHandler.Models;
using PasswordHandler.Utils;

namespace PasswordHandler.Models
{
    public class Store : Resource, ICloneable
    {
        public List<RuleActivity> Rules { get; set; }
        public bool Generation { get; set; }
        public bool CheckingPassword { get; set; }
        public string MasterKey { get; set; }
        public string Estimate { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

