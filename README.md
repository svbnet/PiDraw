# PiDraw
.NET library for drawing directly to the screen on Raspberry Pi or similar Broadcom VideoCore-based devices, using DispManX. At the moment it's just a thin wrapper around the `bcm_host` and `vc_dispmanx` functions (see https://github.com/raspberrypi/firmware/blob/master/opt/vc/include/interface/vmcs_host/vc_dispmanx.h and https://github.com/raspberrypi/firmware/blob/master/opt/vc/include/bcm_host.h), with OpenVG and EGL somewhat implemented too.

Thanks to Andrew for creating the raspidmx repository, which implements many common routines for dealing with DispManX directly. See: https://github.com/AndrewFromMelbourne/raspidmx

## Background
DispManX is a really basic windowing system that lets multiple processes create, manipulate and draw to one or more layers which are then overlaid on top of each other. Layers from one process also can be overlaid on top of layers of another process.

PiDraw provides a way to use the `System.Drawing` namespace with DispManX, in theory making it possible to run the same drawing code on any platform.

## Usage
PiDraw is an object-oriented wrapper for most of the DispManX functions. See this example:

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

In this example an image is loaded from disk into an `Image` instance. We then open the default DispManX display and create a new `ImageResource`. The image is then copied using `Graphics` to an `Image` created by the `ImageResource` instance, which is a bridge between the framework `Bitmap` object and a DispManX resource. The image is then written to the resource. Finally, a new element is created which assigns the resource to our display instance. The image is displayed for a little while, then the element and other objects created are destroyed.

## OpenVG and EGL
OpenVG is a GPU implementation of many vector graphics routines, similar to OpenGL but 2D only.

EGL allows using a DispManX window as an OpenGL ES, OpenMAX or OpenVG surface.

Both of these are partially implemented and OpenVG would probably yield better performance over `System.Drawing`, at the expense of portability.
