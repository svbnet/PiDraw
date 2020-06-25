using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw.Egl
{
    public sealed class Config
    {
        internal IntPtr Handle { get; }

        internal Config(IntPtr handle)
        {
            Handle = handle;
        }
    }
}
