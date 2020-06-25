using System;

namespace svbnet.PiDraw.OpenVG
{
    [Flags]
    public enum PathCapability
    {
        AppendFrom = (1 << 0),
        AppendTo = (1 << 1),
        Modify = (1 << 2),
        TransformFrom = (1 << 3),
        TransformTo = (1 << 4),
        InterpolateFrom = (1 << 5),
        InterpolateTo = (1 << 6),
        PathLength = (1 << 7),
        PointAlongPath = (1 << 8),
        TangentAlongPath = (1 << 9),
        PathBounds = (1 << 10),
        PathTransformedBounds = (1 << 11),
        All = (1 << 12) - 1,
    }
}