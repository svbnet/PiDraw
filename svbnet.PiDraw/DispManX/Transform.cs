namespace svbnet.PiDraw.DispManX
{
    public enum Transform
    {
        /* Bottom 2 bits sets the orientation */
        NoRotate = 0,
        Rotate90 = 1,
        Rotate180 = 2,
        Rotate270 = 3,

        FlipHorizontal = 1 << 16,
        FlipVertical = 1 << 17,

        /* invert left/right images */
        StereoscopicInvert = 1 << 19,
        /* extra flags for controlling 3d duplication behaviour */
        StereoscopicNone = 0 << 20,
        StereoscopicMono = 1 << 20,
        StereoscopicSbs = 2 << 20,
        StereoscopicTb = 3 << 20,
        StereoscopicMask = 15 << 20,

        /* extra flags for controlling snapshot behaviour */
        SnapshotNoYuv = 1 << 24,
        SnapshotNoRgb = 1 << 25,
        SnapshotFill = 1 << 26,
        SnapshotSwapRedBlue = 1 << 27,
        SnapshotPack = 1 << 28
    }
}