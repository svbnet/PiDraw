using System.Runtime.InteropServices;
using svbnet.PiDraw.VcTypes;

namespace svbnet.PiDraw.DispManX
{
    // include/interface/vctypes/vc_display_types.h
    [StructLayout(LayoutKind.Sequential)]
    public struct ModeInfo
    {
        public int Width;

        public int Height;

        public Transform Transform;

        public VcosDisplayInputFormat InputFormat;

        public uint DisplayNum;
    }
}