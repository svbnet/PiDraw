using System;

namespace svbnet.PiDraw.DispManX
{
    [Flags]
    public enum ClampFlags
    {
        None = 0,
        LumaTransparent = 1,
        Transparent = 2,
        Replace = 3,
    }
}