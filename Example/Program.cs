using System;
using System.Drawing;
using System.Threading;
using svbnet.PiDraw.BcmHost;
using svbnet.PiDraw.DispManX;
using svbnet.PiDraw.VcTypes;

namespace Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Init library
            BcmHostLibrary.Init();

            // Load image
            var image = Image.FromFile(args[0]);

            // Open the display (0 = default, should use enum)
            using (var display = new Display(0))
            {
                // Create an image resource with the same width and height as our image.
                using (var imageResource = ImageResource.Create(image.Width, image.Height))
                {
                    // Draw our loaded image to the resource's image.
                    using (var graphics = Graphics.FromImage(imageResource.Bitmap))
                    {
                        graphics.DrawImage(image, new Point(0, 0));
                        graphics.Save();
                    }
                    // Write the image
                    imageResource.Update();

                    var destRect = new VcRect
                    {
                        X = 0, Y = 0,
                        Width = image.Width, Height = image.Height
                    };
                    var srcRect = new VcRect
                    {
                        X = 0, Y = 0,
                        Width = image.Width << 16, Height = image.Height << 16
                    };
                    // Add the resource as an element
                    var update = new Update(0);
                    var element = new Element(update, display, 0, destRect, imageResource, srcRect, Protection.None, 
                        new VcAlpha { Flags = AlphaFlags.FromSource, MaskResourceHandle = 0, Opacity = 255}, null, Transform.NoRotate );
                    update.SubmitSync();

                    // Wait a bit, then tear everything down
                    Thread.Sleep(10000);
                    update = new Update(0);
                    element.Remove(update);
                    update.SubmitSync();
                }
            }
        }
    }
}
