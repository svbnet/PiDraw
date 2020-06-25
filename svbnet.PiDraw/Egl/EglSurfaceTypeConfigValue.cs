using System;

namespace svbnet.PiDraw.Egl
{
    [Flags]
    public enum EglSurfaceTypeConfigValue
    {
        /* Config attribute mask bits */
        PbufferBit = 0x0001,   /* EGL_SURFACE_TYPE mask bits */
        PixmapBit = 0x0002,    /* EGL_SURFACE_TYPE mask bits */
        WindowBit = 0x0004,    /* EGL_SURFACE_TYPE mask bits */
        VgColorspaceLinearBit = 0x0020,  /* EGL_SURFACE_TYPE mask bits */
        VgAlphaFormatPreBit = 0x0040,   /* EGL_SURFACE_TYPE mask bits */
        MultisampleResolveBoxBit = 0x0200,   /* EGL_SURFACE_TYPE mask bits */
        SwapBehaviorPreservedBit = 0x0400,   /* EGL_SURFACE_TYPE mask bits */
    }
}