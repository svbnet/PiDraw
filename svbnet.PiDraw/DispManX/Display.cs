using System;
using System.Collections.Generic;
using System.Text;
using svbnet.PiDraw.BcmHost;
using svbnet.PiDraw.VcTypes;

namespace svbnet.PiDraw.DispManX
{
    public class Display : HandleResource
    {
        private readonly VcRect rect = new VcRect();

        public Display(uint device)
        {
            Handle = BcmHostNativeMethods.VcDispmanxDisplayOpen(device);
            if (Handle == 0)
            {
                throw new InvalidHandleException("Could not open display");
            }
            uint width = 0, height = 0;
            BcmHostNativeMethods.GraphicsGetDisplaySize((ushort)device, ref width, ref height);
            rect.Width = (int) width;
            rect.Height = (int) height;
        }

        public VcRect Rectangle => rect;

        protected override void Free()
        {
            BcmHostNativeMethods.VcDispmanxDisplayClose(Handle);
            Handle = 0;
        }
    }
}
