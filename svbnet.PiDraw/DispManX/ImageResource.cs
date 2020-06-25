using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using svbnet.PiDraw.VcTypes;

namespace svbnet.PiDraw.DispManX
{
    public class ImageResource : Resource
    {
        public Bitmap Bitmap { get; private set; }

        private int width, height, pitch, alignedHeight, size;

        private ImageResource(VcImageType imageType, int width, int height) : base(imageType, width, height)
        {
            
        }

        public static ImageResource Create(int width, int height)
        {
            // pitch = rounded with * BPP / 8
            var pitch = (width * 32) / 8;
            var alignedHeight = Util.RoundTo16th(height);
            var size = pitch * alignedHeight;
            var imageResource = new ImageResource(VcImageType.VcImageArgb8888, (width | (pitch << 16)),
                (height | (alignedHeight << 16)))
            {
                width = width,
                height = height,
                pitch = pitch,
                alignedHeight = alignedHeight,
                size = size,
                Bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb)
            };
            return imageResource;
        }

        public void Update()
        {
            var vcRect = new VcRect
            {
                X = 0, Y = 0,
                Width = width, Height = height,
            };
            var fwRect = new Rectangle(0, 0, width, height); 
            var data = Bitmap.LockBits(fwRect, ImageLockMode.ReadOnly, Bitmap.PixelFormat);
            try
            {
                WriteData(VcImageType.VcImageArgb8888, pitch, data.Scan0, ref vcRect);
            }
            finally
            {
                Bitmap.UnlockBits(data);
            }
        }
    }
}
