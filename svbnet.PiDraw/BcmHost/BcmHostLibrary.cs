using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace svbnet.PiDraw.BcmHost
{
    
    public static class BcmHostLibrary
    {

        public static void Init()
        {
            BcmHostNativeMethods.BcmHostInit();
        }
    }
}
