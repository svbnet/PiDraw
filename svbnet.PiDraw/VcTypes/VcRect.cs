using System.Runtime.InteropServices;

namespace svbnet.PiDraw.VcTypes
{
    // interface/vctypes/vc_image_types.h
    [StructLayout(LayoutKind.Sequential)]
    public struct VcRect
    {
        public int X;

        public int Y;

        public int Width;

        public int Height;
    }
}