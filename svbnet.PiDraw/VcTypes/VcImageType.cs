namespace svbnet.PiDraw.VcTypes
{
    // interface/vctypes/vc_image_types.h
    public enum VcImageType
    {
        VcImageRgb565 = 1,
        VcImage1Bpp,
        VcImageYuv420,
        VcImage48Bpp,
        VcImageRgb888,
        VcImage8Bpp,
        VcImage4Bpp,    // 4bpp palettised image
        VcImage3D32,    /* A separated format of 16 colour/light shorts followed by 16 z values */
        VcImage3D32B,   /* 16 colours followed by 16 z values */
        VcImage3D32Mat, /* A separated format of 16 material/colour/light shorts followed by 16 z values */
        VcImageRgb2X9,   /* 32 bit format containing 18 bits of 6.6.6 RGB, 9 bits per short */
        VcImageRgb666,   /* 32-bit format holding 18 bits of 6.6.6 RGB */
        VcImagePal4Obsolete,     // 4bpp palettised image with embedded palette
        VcImagePal8Obsolete,     // 8bpp palettised image with embedded palette
        VcImageRgba32,   /* RGB888 with an alpha byte after each pixel */ /* xxx: isn't it BEFORE each pixel? */
        VcImageYuv422,   /* a line of Y (32-byte padded), a line of U (16-byte padded), and a line of V (16-byte padded) */
        VcImageRgba565,  /* RGB565 with a transparent patch */
        VcImageRgba16,   /* Compressed (4444) version of RGBA32 */
        VcImageYuvUv,   /* VCIII codec format */
        VcImageTfRgba32, /* VCIII T-format RGBA8888 */
        VcImageTfRgbx32,  /* VCIII T-format RGBx8888 */
        VcImageTfFloat, /* VCIII T-format float */
        VcImageTfRgba16, /* VCIII T-format RGBA4444 */
        VcImageTfRgba5551, /* VCIII T-format RGB5551 */
        VcImageTfRgb565, /* VCIII T-format RGB565 */
        VcImageTfYa88, /* VCIII T-format 8-bit luma and 8-bit alpha */
        VcImageTfByte, /* VCIII T-format 8 bit generic sample */
        VcImageTfPal8, /* VCIII T-format 8-bit palette */
        VcImageTfPal4, /* VCIII T-format 4-bit palette */
        VcImageTfEtc1, /* VCIII T-format Ericsson Texture Compressed */
        VcImageBgr888,  /* RGB888 with R & B swapped */
        VcImageBgr888Np,  /* RGB888 with R & B swapped, but with no pitch, i.e. no padding after each row of pixels */
        VcImageBayer,  /* Bayer image, extra defines which variant is being used */
        VcImageCodec,  /* General wrapper for codec images e.g. JPEG from camera */
        VcImageYuvUv32,   /* VCIII codec format */
        VcImageTfY8,   /* VCIII T-format 8-bit luma */
        VcImageTfA8,   /* VCIII T-format 8-bit alpha */
        VcImageTfShort,/* VCIII T-format 16-bit generic sample */
        VcImageTf1Bpp, /* VCIII T-format 1bpp black/white */
        VcImageOpengl,
        VcImageYuv444I, /* VCIII-B0 HVS YUV 4:4:4 interleaved samples */
        VcImageYuv422Planar,  /* Y, U, & V planes separately (VC_IMAGE_YUV422 has them interleaved on a per line basis) */
        VcImageArgb8888,   /* 32bpp with 8bit alpha at MS byte, with R, G, B (LS byte) */
        VcImageXrgb8888,   /* 32bpp with 8bit unused at MS byte, with R, G, B (LS byte) */

        VcImageYuv422Yuyv,  /* interleaved 8 bit samples of Y, U, Y, V */
        VcImageYuv422Yvyu,  /* interleaved 8 bit samples of Y, V, Y, U */
        VcImageYuv422Uyvy,  /* interleaved 8 bit samples of U, Y, V, Y */
        VcImageYuv422Vyuy,  /* interleaved 8 bit samples of V, Y, U, Y */

        VcImageRgbx32,      /* 32bpp like RGBA32 but with unused alpha */
        VcImageRgbx8888,    /* 32bpp, corresponding to RGBA with unused alpha */
        VcImageBgrx8888,    /* 32bpp, corresponding to BGRA with unused alpha */

        VcImageYuv420Sp,    /* Y as a plane, then UV byte interleaved in plane with with same pitch, half height */

        VcImageYuv444Planar,  /* Y, U, & V planes separately 4:4:4 */

        VcImageTfU8,   /* T-format 8-bit U - same as TF_Y8 buf from U plane */
        VcImageTfV8,   /* T-format 8-bit U - same as TF_Y8 buf from V plane */

        VcImageYuv42016,  /* YUV4:2:0 planar, 16bit values */
        VcImageYuvUv16,  /* YUV4:2:0 codec format, 16bit values */
        VcImageYuv420S,   /* YUV4:2:0 with U,V in side-by-side format */
        VcImageYuv10Col,   /* 10-bit YUV 420 column image format */

        VcImageRgba1010102, /* 32-bpp, 10-bit R/G/B, 2-bit Alpha */
    }
}