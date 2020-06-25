using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw.Egl
{
    public abstract class Surface : NativeResource
    {
        protected Display Display;

        public void SwapBuffers()
        {
            ErrorHelper.AssertSuccess(EglNativeMethods.EglSwapBuffers(Display.HandleOrThrow(), Handle));
        }

        protected override void Free()
        {
            if (Disposed) return;
            ErrorHelper.AssertSuccess(EglNativeMethods.EglDestroySurface(Display.HandleOrThrow(), Handle));
        }
    }
}
