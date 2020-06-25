using System.Runtime.InteropServices;

namespace svbnet.PiDraw.DispManX
{
    [StructLayout(LayoutKind.Sequential)]
    public class Clamp
    {
        public ClampFlags Mode;

        public KeymaskFlags KeyMask;

        public ClampKeys KeyValue;

        public uint ReplaceValue;
    }
}