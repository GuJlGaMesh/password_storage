using System;
using System.Collections.Generic;
using System.Text;

namespace Password_Storage
{
    public class LengthChar : LowerChar
    {
        private readonly int _minLength;

        public LengthChar(int minLegnth = 16)
        {
            if (minLegnth > 0)
                _minLength = minLegnth;
            else _minLength = 16;
        }

        public override int MinLength => _minLength;

    }
}
