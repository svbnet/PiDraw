using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw.Egl
{
    public class WindowSurface : Surface
    {
        public WindowSurface(Display display, Config config, IntPtr window, int[] attribList)
        {
            Display = display;
            Handle = ErrorHelper.AssertSuccess(
                EglNativeMethods.EglCreateWindowSurface(display.HandleOrThrow(), config.Handle, window, attribList));
        }

        public WindowSurface(Display display, Config config, IntPtr window) : this(display, config, window, null)
        {

        }
    }
}
