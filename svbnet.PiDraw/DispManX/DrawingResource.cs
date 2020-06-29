using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using svbnet.PiDraw.VcTypes;

namespace svbnet.PiDraw.DispManX
{
    public class DrawingResource : Resource
    {
        private Bitmap bitmap;
        private int pitch;

        private DrawingResource(VcImageType imageType, int width, int height) : base(imageType, width, height)
        {
        }

        public static DrawingResource Create(VcRect rect)
        {
            return Create(rect.Width, rect.Height);
        }

        public static DrawingResource Create(int width, int height)
        {
            // pitch = rounded with * BPP / 8
            var pitch = (width * 32) / 8;
            var alignedHeight = Util.RoundTo16th(height);
            var imageResource = new DrawingResource(VcImageType.VcImageArgb8888, (width | (pitch << 16)),
                (height | (alignedHeight << 16)))
            {
                Width = width,
                Height = height,
                pitch = pitch,
                bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb)
            };
            return imageResource;
        }

        public new int Width { get; private set; }

        public new int Height { get; private set; }

        public Image Image => bitmap;

        public Graphics CreateGraphics()
        {
            return Graphics.FromImage(bitmap);
        }

        /// <summary>
        /// Copies data from the internal bitmap to the underlying resource.
        /// </summary>
        public void Write()
        {
            var vcRect = new VcRect(0, 0, Width, Height);
            var data = bitmap.LockBits(vcRect.ToFrameworkRectangle(), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            try
            {
                WriteData(VcImageType.VcImageArgb8888, pitch, data.Scan0, ref vcRect);
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }

        /// <summary>
        /// Copies data from the underlying resource to the internal bitmap.
        /// </summary>
        public void Read()
        {
            var vcRect = new VcRect(0, 0, Width, Height);
            var data = bitmap.LockBits(vcRect.ToFrameworkRectangle(), ImageLockMode.WriteOnly, bitmap.PixelFormat);
            try
            {
                ReadData((uint)pitch, data.Scan0, ref vcRect);
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }
    }
}
