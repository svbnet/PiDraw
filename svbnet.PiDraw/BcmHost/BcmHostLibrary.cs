using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace svbnet.PiDraw.BcmHost
{

    public class DisplaySize
    {
        public uint Width { get; set; }
        public uint Height { get; set; }
    }

    public static class BcmHostLibrary
    {
        internal static void AssertSuccess(int result, string message)
        {
            if (result < 0)
            {
                throw new BcmHostException(message, result);
            }
        }

        public static void Init()
        {
            BcmHostNativeMethods.BcmHostInit();
        }

        public static DisplaySize GetDisplaySize(ushort displayNumber)
        {
            AssertSuccess(BcmHostNativeMethods.GraphicsGetDisplaySize(displayNumber, out var width, out var height), "graphics_get_display_size");
            return new DisplaySize
            {
                Height = height,
                Width = width
            };
        }
    }
}
