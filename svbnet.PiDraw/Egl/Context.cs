using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw.Egl
{
    public class Context : NativeResource
    {
        private readonly Display display;

        public Context(Display display, Config config, Context shareContext, int[] attribList)
        {
            this.display = display;
            var displayHandle = display.HandleOrThrow();
            var configHandle = config.Handle;
            var shareContextHandle = shareContext.Handle == IntPtr.Zero ? IntPtr.Zero : shareContext.Handle;
            Handle = ErrorHelper.AssertSuccess(
                EglNativeMethods.EglCreateContext(displayHandle, configHandle, shareContextHandle, attribList));
        }

        public Context(Display display, Config config) : this(display, config, null, null)
        {
            
        }

        public void MakeCurrent(Surface drawSurface, Surface readSurface)
        {
            ErrorHelper.AssertSuccess(EglNativeMethods.EglMakeCurrent(display.HandleOrThrow(),
                drawSurface.HandleOrThrow(), readSurface.HandleOrThrow(), Handle));
        }

        protected override void Free()
        {
            if (Disposed) return;
            ErrorHelper.AssertSuccess(EglNativeMethods.EglDestroyContext(display.HandleOrThrow(), Handle));
        }
    }
}
