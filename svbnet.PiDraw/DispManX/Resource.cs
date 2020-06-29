using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using svbnet.PiDraw.BcmHost;
using svbnet.PiDraw.VcTypes;

namespace svbnet.PiDraw.DispManX
{
    /// <summary>
    /// Represents a DispManX Resource object.
    /// </summary>
    public class Resource : HandleResource
    {
        public VcImageType ImageType { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        /// <summary>
        /// Create a new resource.
        /// </summary>
        /// <param name="imageType">The image type of the resource.</param>
        /// <param name="width">The resource width</param>
        /// <param name="height">The resource height</param>
        public Resource(VcImageType imageType, int width, int height)
        {
            uint temp = 0;
            Handle = BcmHostNativeMethods.VcDispmanxResourceCreate(imageType, (uint)width, (uint)height, ref temp);
            ImageType = imageType;
            Width = width;
            Height = height;
        }

        public void WriteData(VcImageType imageType, int srcPitch, IntPtr srcData, ref VcRect rect)
        {
            var result = BcmHostNativeMethods.VcDispmanxResourceWriteData(Handle, imageType, srcPitch, srcData, ref rect);
            if (result != 0)
            {
                throw new BcmHostException("Could not write data to resource", result);
            }
        }

        public void ReadData(uint dstPitch, IntPtr dstBuffer, ref VcRect rect)
        {
            var result = BcmHostNativeMethods.VcDispmanxResourceReadData(Handle, ref rect, dstBuffer, dstPitch);
            if (result != 0)
            {
                throw new BcmHostException("Could not read data from the resource", result);
            }
        }

        protected override void Free()
        {
            BcmHostNativeMethods.VcDispmanxResourceDelete(Handle);
            Handle = 0;
        }
    }
}
