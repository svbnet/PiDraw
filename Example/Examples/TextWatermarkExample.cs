using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using svbnet.PiDraw.BcmHost;
using svbnet.PiDraw.DispManX;
using svbnet.PiDraw.VcTypes;

namespace Example.Examples
{
    [Verb("TextWatermarkExample", HelpText = "Display text and a watermark near the bottom of the screen")]
    public class TextWatermarkExample : ExampleBase
    {
        private bool running = false;

        [Option(HelpText = "Image path")]
        public string ImagePath { get; set; }

        [Option(HelpText = "Text to display")]
        public string Text { get; set; }

        [Option(HelpText = "DispManX layer", Default = 0)]
        public int Layer { get; set; }

        [Option(HelpText = "Opacity of the layer", Default = 127)]
        public int Opacity { get; set; }

        public override int Run()
        {
            Console.CancelKeyPress += (sender, args) =>
            {
                running = false;
                args.Cancel = true;
            };
            // Init library
            BcmHostLibrary.Init();
            Console.WriteLine("Initialized library!");

            // Load image
            Console.WriteLine($"Loading image {ImagePath}");
            var image = Image.FromFile(ImagePath);
            

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
                        // Draw the text in the top left corner
                        graphics.DrawString(Text, new Font(FontFamily.GenericSansSerif, 24), new SolidBrush(Color.HotPink), 0, 0);
                        // Draw the image in the bottom right corner
                        graphics.DrawImage(image, new Point(imageResource.Width - image.Width, imageResource.Height - image.Height));
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
                    // AlphaFlags.FixedAllPixels will make DispManX do alpha compositing for us
                    var element = new Element(update, display, Layer, display.Rectangle, imageResource, srcRect, Protection.None,
                        new VcAlpha { Flags = AlphaFlags.FixedAllPixels, MaskResourceHandle = 0, Opacity = (uint)Opacity }, null, Transform.NoRotate);
                    update.SubmitSync();
                    Console.WriteLine("Written data to screen");
                    running = true;

                    while (running) ;
                    update = new Update(0);
                    element.Remove(update);
                    update.SubmitSync();
                }
            }

            return 0;
        }
    }
}
