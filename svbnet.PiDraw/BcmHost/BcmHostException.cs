using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw.BcmHost
{
    public class BcmHostException : Exception
    {
        internal BcmHostException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; set; }
    }
}
