using System;
using System.Collections.Generic;
using System.Text;
using svbnet.PiDraw.BcmHost;

namespace svbnet.PiDraw.DispManX
{
    public class Display : HandleResource
    {
        public Display(uint device)
        {
            Handle = BcmHostNativeMethods.VcDispmanxDisplayOpen(device);
            if (Handle == 0)
            {
                throw new InvalidHandleException("Could not open display");
            }
        }

        protected override void Free()
        {
            BcmHostNativeMethods.VcDispmanxDisplayClose(Handle);
            Handle = 0;
        }
    }
}
