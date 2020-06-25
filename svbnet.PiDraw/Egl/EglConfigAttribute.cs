namespace svbnet.PiDraw.Egl
{
    public enum EglConfigAttribute
    {
        BufferSize = 0x3020,
        AlphaSize = 0x3021,
        BlueSize = 0x3022,
        GreenSize = 0x3023,
        RedSize = 0x3024,
        DepthSize = 0x3025,
        StencilSize = 0x3026,
        ConfigCaveat = 0x3027,
        ConfigId = 0x3028,
        Level = 0x3029,
        MaxPbufferHeight = 0x302A,
        MaxPbufferPixels = 0x302B,
        MaxPbufferWidth = 0x302C,
        NativeRenderable = 0x302D,
        NativeVisualId = 0x302E,
        NativeVisualType = 0x302F,
        Samples = 0x3031,
        SampleBuffers = 0x3032,
        SurfaceType = 0x3033,
        TransparentType = 0x3034,
        TransparentBlueValue = 0x3035,
        TransparentGreenValue = 0x3036,
        TransparentRedValue = 0x3037,
        None = 0x3038,  /* Attrib list terminator */
        BindToTextureRgb = 0x3039,
        BindToTextureRgba = 0x303A,
        MinSwapInterval = 0x303B,
        MaxSwapInterval = 0x303C,
        LuminanceSize = 0x303D,
        AlphaMaskSize = 0x303E,
        ColorBufferType = 0x303F,
        RenderableType = 0x3040,
        MatchNativePixmap = 0x3041,   /* Pseudo-attribute (not queryable) */
        Conformant = 0x3042,
    }
}