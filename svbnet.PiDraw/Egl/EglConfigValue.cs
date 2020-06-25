using System;

namespace svbnet.PiDraw.Egl
{
    [Flags]
    public enum EglConfigValue
    {
        /* Config attribute values */
        SlowConfig = 0x3050,   /* EGL_CONFIG_CAVEAT value */
        NonConformantConfig = 0x3051, /* EGL_CONFIG_CAVEAT value */
        TransparentRgb = 0x3052,   /* EGL_TRANSPARENT_TYPE value */
        RgbBuffer = 0x308E,    /* EGL_COLOR_BUFFER_TYPE value */
        LuminanceBuffer = 0x308F,  /* EGL_COLOR_BUFFER_TYPE value */

        /* More config attribute values, for EGL_TEXTURE_FORMAT */
        NoTexture = 0x305C,
        TextureRgb = 0x305D,
        TextureRgba = 0x305E,
        Texture2D = 0x305F,
    }
}