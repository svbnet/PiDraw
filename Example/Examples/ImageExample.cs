using System;
using System.Drawing;
using System.Threading;
using CommandLine;
using svbnet.PiDraw.BcmHost;
using svbnet.PiDraw.DispManX;
using svbnet.PiDraw.VcTypes;

namespace Example.Examples
{
    [Verb("ImageExample", HelpText = "Draw an image to the display with a background")]
    public class ImageExample : ExampleBase
    {
        [Option(HelpText = "Image path")]
        public string Path { get; set; }

        public override int Run()
        {
            // Init library
            BcmHostLibrary.Init();
            Console.WriteLine("Initialized library!");

            // Load image
            Console.WriteLine($"Loading image {Path}");
            var image = Image.FromFile(Path);

            // Open the display (0 = default, should use enum)
            using (var display = new Display(0))
            {
                Console.WriteLine($"Opened default display, width = {display.Rectangle.Width}, height = {display.Rectangle.Height}");
                // Create an image resource with the same width and height as our display.
                using (var imageResource = DrawingResource.Create(display.Rectangle))
                {
                    Console.WriteLine("Created drawing resource");
                    // Get a new Graphics instance
                    using (var graphics = imageResource.CreateGraphics())
                    {
                        // Set a background
                        graphics.Clear(Color.HotPink);
                        // Draw the image in the top left corner
                        graphics.DrawImage(image, new Point(0, 0));
                    }
                    // Write the buffer to the display
                    imageResource.Write();
                    Console.WriteLine("Copied drawing");

                    var srcRect = new VcRect
                    {
                        X = 0,
                        Y = 0,
                        Width = display.Rectangle.Width << 16,
                        Height = display.Rectangle.Height << 16
                    };
                    // Add the resource as an element
                    var update = new Update(0);
                    var element = new Element(update, display, 0, display.Rectangle, imageResource, srcRect, Protection.None,
                        new VcAlpha { Flags = AlphaFlags.FromSource, MaskResourceHandle = 0, Opacity = 255 }, null, Transform.NoRotate);
                    update.SubmitSync();
                    Console.WriteLine("Written data to screen");

                    // Wait a bit, then tear everything down
                    Thread.Sleep(10000);
                    update = new Update(0);
                    element.Remove(update);
                    update.SubmitSync();
                }
            }

            return 0;
        }
    }
}
