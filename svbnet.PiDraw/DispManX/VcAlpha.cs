using System.Runtime.InteropServices;

namespace svbnet.PiDraw.DispManX
{
    [StructLayout(LayoutKind.Sequential)]
    public class VcAlpha
    {
        public AlphaFlags Flags;

        public uint Opacity;

        public uint MaskResourceHandle;
    }
}