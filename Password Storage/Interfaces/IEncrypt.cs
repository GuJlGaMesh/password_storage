using System;
using System.Collections.Generic;
using System.Text;

namespace Password_Storage
{
    interface IEncrypt
    {
        public string Crypt(string toCrypt, string masterKey);
        public string Decrypt(string toDecrypt, string masterKey);
    }
}
