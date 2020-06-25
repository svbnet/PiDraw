using System;

namespace svbnet.PiDraw.OpenVG
{
    [Flags]
    public enum ImageChannel
    {
        Red = (1 << 3),
        Green = (1 << 2),
        Blue = (1 << 1),
        Alpha = (1 << 0),
    }
}