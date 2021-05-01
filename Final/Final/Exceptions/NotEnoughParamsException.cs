using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Exceptions
{
    class NotEnoughParamsException : Exception
    {
        public NotEnoughParamsException(string message)
        : base(message)
        {
        }
    }
}
