using System;
using System.Runtime.InteropServices;

namespace svbnet.PiDraw.OpenVG
{
    internal static class OpenVGNativeMethods
    {
        private const string LibraryName = "libOpenVG";

        [DllImport(LibraryName, EntryPoint = "vgGetError", CallingConvention = CallingConvention.Cdecl)]
        public static extern OpenVGError VGGetError();

        [DllImport(LibraryName, EntryPoint = "vgFlush", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VGFlush();

        [DllImport(LibraryName, EntryPoint = "vgFinish", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VGFinish();

        #region " Current context param functions "
        [DllImport(LibraryName, EntryPoint = "vgGetf", CallingConvention = CallingConvention.Cdecl)]
        public static extern float VGGetf(int type);

        [DllImport(LibraryName, EntryPoint = "vgGeti", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VGGeti(int type);

        [DllImport(LibraryName, EntryPoint = "vgGetVectorSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VGGetVectorSize(int type);

        [DllImport(LibraryName, EntryPoint = "vgGetfv", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VGGetfv(int type, int count, [In, Out] float[] values);

        [DllImport(LibraryName, EntryPoint = "vgGetiv", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VGGetiv(int type, int count, [In, Out] int[] values);

        [DllImport(LibraryName, EntryPoint = "vgSetf", CallingConvention = CallingConvention.Cdecl)]
        public static extern float VGSetf(int type, float value);

        [DllImport(LibraryName, EntryPoint = "vgSeti", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VGSeti(int type, int value);

        [DllImport(LibraryName, EntryPoint = "vgSetfv", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VGSetfv(int type, int count, [In, Out] float[] values);

        [DllImport(LibraryName, EntryPoint = "vgSetiv", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VGSetiv(int type, int count, [In, Out] int[] values);
        #endregion

        #region " Instance param functions "
        [DllImport(LibraryName, EntryPoint = "vgGetParameterf", CallingConvention = CallingConvention.Cdecl)]
        public static extern float VGGetParameterf(IntPtr obj, int type);

        [DllImport(LibraryName, EntryPoint = "vgGetParameteri", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VGGetParameteri(IntPtr obj, int type);

        [DllImport(LibraryName, EntryPoint = "vgGetParameterVectorSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VGGetParameterVectorSize(IntPtr obj, int type);

        [DllImport(LibraryName, EntryPoint = "vgGetParameterfv", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VGGetParameterfv(IntPtr obj, int type, int count, [In, Out] float[] values);

        [DllImport(LibraryName, EntryPoint = "vgGetParameteriv", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VGGetParameteriv(IntPtr obj, int type, int count, [In, Out] int[] values);

        [DllImport(LibraryName, EntryPoint = "vgSetParameterf", CallingConvention = CallingConvention.Cdecl)]
        public static extern float VGSetParameterf(IntPtr obj, int type, float value);

        [DllImport(LibraryName, EntryPoint = "vgSetParameteri", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VGSetParameteri(IntPtr obj, int type, int value);

        [DllImport(LibraryName, EntryPoint = "vgSetParameterfv", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VGSetParameterfv(IntPtr obj, int type, int count, [In, Out] float[] values);

        [DllImport(LibraryName, EntryPoint = "vgSetParameteriv", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VGSetParameteriv(IntPtr obj, int type, int count, [In, Out] int[] values);
        #endregion
    }
}
