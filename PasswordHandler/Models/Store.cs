using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Password_Storage;
using PasswordHandler.Models;

namespace PasswordHandler.Models
{
    public class Resource : Record
    {
        public int Id { get; set; }
    }

    public class Store : Resource
    {
        public bool Generation { get; set; }
        public bool CheckingPassword { get; set; }
        public string MasterKey { get; set; }
        public bool Digits { get; set; }
        public bool Length { get; set; }
        public int LengthValue { get; set; } = 0;
        public bool LowerChar { get; set; }
        public bool UpperChar { get; set; }
        public bool SpecialChar { get; set; }
        public string Estimate { get; set; }
    }
}

