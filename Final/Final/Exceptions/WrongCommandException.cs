using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Exceptions
{
    class WrongCommandException : Exception
    {
        public WrongCommandException(string message)
        : base(message)
        {
        }
    }
}
