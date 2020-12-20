using System;
using System.Collections.Generic;
using System.Text;

namespace Password_Storage
{
    public class Length : LowerChar
    {
        private readonly int _minLength;

        public Length(int minLegnth = 8)
        {
            if (minLegnth > 0)
                _minLength = minLegnth;
            else _minLength = 8;
        }

        public override int MinLength => _minLength;

    }
}
