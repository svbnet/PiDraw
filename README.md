# PiDraw
.NET library for drawing directly to the screen on Raspberry Pi or similar Broadcom VideoCore-based devices, using DispManX. At the moment it's just a thin wrapper around the [`bcm_host`](https://github.com/raspberrypi/firmware/blob/master/opt/vc/include/bcm_host.h) and [`vc_dispmanx`](https://github.com/raspberrypi/firmware/blob/master/opt/vc/include/interface/vmcs_host/vc_dispmanx.h) headers, with some OpenVG and EGL functions also implemented.

As well as the examples in the aforementioned repositories, huge thanks to [AndrewFromMelbourne](https://github.com/AndrewFromMelbourne) for his multiple DispManX-based repositories. If you haven't already I strongly encourage you to check out the [raspidmx](https://github.com/AndrewFromMelbourne/raspidmx) repository in order to get a handle on many of the DispManX/VC routines.

At the moment this is a .NET framework library, which seems counterintuitive considering the existence of .NET Standard/Core. This was originally built as a counterpart to a separate project that runs on Mono on the Pi, and it will be tested on the Pi using Mono.

## Background
DispManX is a really basic windowing system that lets multiple processes create, manipulate and draw to one or more layers which are then overlaid on top of each other. Layers from one process also can be overlaid on top of layers of another process.

PiDraw contains a class, `DrawingResource`, that provides an instance of `System.Drawing.Graphics`. Internally, this uses a `System.Drawing.Image` to hold image data exchanged between a DispManX resource and the framework, making it easy to encode, decode and draw images onscreen.

## Examples
See the "Example" project for some examples you can compile and run:

* `TextWatermarkExample`: Draws text and displays an image while enabling the opacity and layer to be set.
* `ImageExample`: Displays an image in the top left corner of the display then quits after 10 seconds.
* `SnapshotExample`: Takes a screenshot of the default display and saves it to a file.

## OpenVG, EGL and Cairo
While the Mono implementation of `System.Drawing` works, it may not be suitable for more advanced functions [(see here)](https://www.mono-project.com/docs/gui/libgdiplus/). 

In the future it might be more suitable to create a resource that Cairo can use, or even better, a fork that writes directly to a DispManX resource. Text can also be handled with Pango.

OpenVG is a GPU implementation of many vector graphics routines, similar to OpenGL.

EGL allows using a DispManX window as an OpenGL ES, OpenMAX or OpenVG surface.

Both of these are partially implemented in PiDraw and OpenVG would probably yield better performance over `System.Drawing`, at the expense of portability. Additionally, OpenVG also provides functions for rendering text, providing functions to store and draw glyphs, with shaping text mostly being the only work being done on the CPU.

