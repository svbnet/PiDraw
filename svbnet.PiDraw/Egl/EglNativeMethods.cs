using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace svbnet.PiDraw.Egl
{
    internal static class EglNativeMethods
    {
        private const string LibraryName = "libEGL";

        [DllImport(LibraryName, EntryPoint = "eglGetError", CallingConvention = CallingConvention.Cdecl)]
        public static extern int EglGetError();

        [DllImport(LibraryName, EntryPoint = "eglGetDisplay", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr EglGetDisplay(IntPtr displayId);

        [DllImport(LibraryName, EntryPoint = "eglInitialize", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool EglInitialize(IntPtr dpy, out int major, out int minor);

        [DllImport(LibraryName, EntryPoint = "eglTerminate", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool EglTerminate(IntPtr dpy);

        [DllImport(LibraryName, EntryPoint = "eglChooseConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool EglChooseConfig(IntPtr dpy, [In] int[] attribList, ref IntPtr configs, int configSize,
            out int numConfig);

        [DllImport(LibraryName, EntryPoint = "eglBindAPI", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool EglBindApi(uint api);

        [DllImport(LibraryName, EntryPoint = "eglCreateContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr EglCreateContext(IntPtr dpy, IntPtr config, IntPtr shareContext,
            [In] int[] attribList);

        [DllImport(LibraryName, EntryPoint = "EglDestroyContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool EglDestroyContext(IntPtr dpy, IntPtr ctx);

        [DllImport(LibraryName, EntryPoint = "eglCreateWindowSurface", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr EglCreateWindowSurface(IntPtr dpy, IntPtr config, IntPtr win, [In] int[] attribList);

        [DllImport(LibraryName, EntryPoint = "eglDestroySurface", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool EglDestroySurface(IntPtr dpy, IntPtr surface);

        [DllImport(LibraryName, EntryPoint = "eglMakeCurrent", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool EglMakeCurrent(IntPtr dpy, IntPtr draw, IntPtr read, IntPtr ctx);

        [DllImport(LibraryName, EntryPoint = "eglSwapBuffers", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool EglSwapBuffers(IntPtr dpy, IntPtr surface);
    }
}
