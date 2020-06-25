using System;

namespace svbnet.PiDraw.OpenVG
{
    [Flags]
    public enum PathSegment
    {
        ClosePath = (0 << 1),
        MoveTo = (1 << 1),
        LineTo = (2 << 1),
        HlineTo = (3 << 1),
        VlineTo = (4 << 1),
        QuadTo = (5 << 1),
        CubicTo = (6 << 1),
        SquadTo = (7 << 1),
        ScubicTo = (8 << 1),
        SccwarcTo = (9 << 1),
        ScwarcTo = (10 << 1),
        LccwarcTo = (11 << 1),
        LcwarcTo = (12 << 1),

        SegmentMask = 0xf << 1,
    }
}