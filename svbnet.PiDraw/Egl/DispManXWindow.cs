using System.Runtime.InteropServices;

namespace svbnet.PiDraw.Egl
{
    // include/EGL/eglplatform.h
    [StructLayout(LayoutKind.Sequential)]
    public struct DispManXWindow
    {
        public uint ElementHandle;

        public int Width;

        public int Height;
    }
}