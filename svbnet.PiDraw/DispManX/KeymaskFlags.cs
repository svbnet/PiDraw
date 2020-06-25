using System;

namespace svbnet.PiDraw.DispManX
{
    [Flags]
    public enum KeymaskFlags
    {
        Override = 1,
        Smooth =  1 << 1,
        CrInv = 1 << 2,
        CbInv = 1 << 3,
        YyInv = 1 << 4,
    }
}