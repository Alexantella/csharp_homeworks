using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Exceptions
{
    class NotADirectoryException : Exception
    {
        public NotADirectoryException(string message)
        : base(message)
        {
        }
    }
}
