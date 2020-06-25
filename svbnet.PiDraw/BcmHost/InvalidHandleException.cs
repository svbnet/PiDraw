using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw.BcmHost
{
    public class InvalidHandleException : Exception
    {
        public InvalidHandleException(string message) : base(message)
        {
        }
    }
}
