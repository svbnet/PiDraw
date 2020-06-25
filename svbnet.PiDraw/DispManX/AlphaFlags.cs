using System;

namespace svbnet.PiDraw.DispManX
{
    // include/interface/vmcs_host/vc_dispmanx_types.h
    [Flags]
    public enum AlphaFlags
    {
        FromSource = 0,
        FixedAllPixels = 1,
        FixedNonZero = 2,
        FixedExceed0x07 = 3,

        Premult = 1 << 16,
        Mix = 1 << 17,
        DiscardLowerLayers = 1 << 18,
    }
}