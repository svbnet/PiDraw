using System;

namespace svbnet.PiDraw.Egl
{
    [Flags]
    public enum EglRenderableTypeConfigValue
    {
        OpenGlEsBit = 0x0001, /* EGL_RENDERABLE_TYPE mask bits */
        OpenVgBit = 0x0002,    /* EGL_RENDERABLE_TYPE mask bits */
        OpenGlEs2Bit = 0x0004,    /* EGL_RENDERABLE_TYPE mask bits */
        OpenGlBit = 0x0008,	/* EGL_RENDERABLE_TYPE mask bits */
    }
}