namespace svbnet.PiDraw.OpenVG
{
    public enum OpenVGError
    {
        VgNoError = 0,
        VgBadHandleError = 0x1000,
        VgIllegalArgumentError = 0x1001,
        VgOutOfMemoryError = 0x1002,
        VgPathCapabilityError = 0x1003,
        VgUnsupportedImageFormatError = 0x1004,
        VgUnsupportedPathFormatError = 0x1005,
        VgImageInUseError = 0x1006,
        VgNoContextError = 0x1007,
    }
}