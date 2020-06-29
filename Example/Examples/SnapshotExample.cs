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
    [Verb("SnapshotExample", HelpText = "Takes a screenshot of the current display and saves it to a file.")]
    public class SnapshotExample : ExampleBase
    {
        [Option(HelpText = "Image path to save to.")]
        public string Path { get; set; }

        public override int Run()
        {
            // Init library
            BcmHostLibrary.Init();
            Console.WriteLine("Initialized library!");

            // Open the display (0 = default, should use enum)
            using (var display = new Display(0))
            {
                Console.WriteLine($"Opened default display, width = {display.Rectangle.Width}, height = {display.Rectangle.Height}");
                // Create an image resource with the same width and height as our display.
                using (var imageResource = DrawingResource.Create(display.Rectangle))
                {
                    Console.WriteLine("Created drawing resource");

                    Console.WriteLine("Taking snapshot...");
                    display.TakeSnapshot(imageResource);

                    Console.WriteLine("Copying to memory...");
                    imageResource.Read();

                    Console.WriteLine($"Saving to {Path}...");
                    imageResource.Image.Save(Path);
                }
            }

            return 0;
        }
    }
}
