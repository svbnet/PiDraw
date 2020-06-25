namespace svbnet.PiDraw.OpenVG
{
    public enum ImageFormat
    {
        /* RGB{A,X} channel ordering */
        SRGBX8888 = 0,
        SRGBA8888 = 1,
        SRGBA8888Pre = 2,
        SRGB565 = 3,
        SRGBA5551 = 4,
        SRGBA4444 = 5,
        SL8 = 6,
        LRGBX8888 = 7,
        LRGBA8888 = 8,
        LRGBA8888Pre = 9,
        LL8 = 10,
        A8 = 11,
        BW1 = 12,
        A1 = 13,
        A4 = 14,

        /* {A,X}RGB channel ordering */
        SXRGB8888 = 0 | (1 << 6),
        SARGB8888 = 1 | (1 << 6),
        SARGB8888Pre = 2 | (1 << 6),
        SARGB1555 = 4 | (1 << 6),
        SARGB4444 = 5 | (1 << 6),
        LXRGB8888 = 7 | (1 << 6),
        LARGB8888 = 8 | (1 << 6),
        LARGB8888Pre = 9 | (1 << 6),

        /* BGR{A,X} channel ordering */
        SBGRX8888 = 0 | (1 << 7),
        SBGRA8888 = 1 | (1 << 7),
        SBGRA8888Pre = 2 | (1 << 7),
        SBGR565 = 3 | (1 << 7),
        SBGRA5551 = 4 | (1 << 7),
        SBGRA4444 = 5 | (1 << 7),
        LBGRX8888 = 7 | (1 << 7),
        LBGRA8888 = 8 | (1 << 7),
        LBGRA8888Pre = 9 | (1 << 7),

        /* {A,X}BGR channel ordering */
        SXBGR8888 = 0 | (1 << 6) | (1 << 7),
        SABGR8888 = 1 | (1 << 6) | (1 << 7),
        SABGR8888Pre = 2 | (1 << 6) | (1 << 7),
        SABGR1555 = 4 | (1 << 6) | (1 << 7),
        SABGR4444 = 5 | (1 << 6) | (1 << 7),
        LXBGR8888 = 7 | (1 << 6) | (1 << 7),
        LABGR8888 = 8 | (1 << 6) | (1 << 7),
        LABGR8888Pre = 9 | (1 << 6) | (1 << 7),
    }
}