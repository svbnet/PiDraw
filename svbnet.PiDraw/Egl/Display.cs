using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace svbnet.PiDraw.Egl
{
    public sealed class Display : NativeResource
    {
        public int MajorVersion { get; }

        public int MinorVersion { get; }

        public Display(IntPtr displayId)
        {
            Handle = EglNativeMethods.EglGetDisplay(displayId);
            ErrorHelper.ThrowIfLastError();
            if (Handle == IntPtr.Zero)
            {
                throw new ArgumentException("No display matching displayId was found.", nameof(displayId));
            }

            ErrorHelper.AssertSuccess(EglNativeMethods.EglInitialize(Handle, out var major, out var minor));
            MajorVersion = major;
            MinorVersion = minor;
        }

        public Config[] ChooseConfig(int[] attribList, int configSize)
        {
            ThrowIfDisposed();
            var buffer = Marshal.AllocCoTaskMem(IntPtr.Size * configSize);
            try
            {
                ErrorHelper.AssertSuccess(EglNativeMethods.EglChooseConfig(Handle, attribList, ref buffer, configSize,
                    out var numConfig));
                if (numConfig > 0)
                {
                    var configPtrs = new IntPtr[numConfig];
                    Marshal.Copy(buffer, configPtrs, 0, numConfig);
                    return configPtrs.Select(ptr => new Config(ptr)).ToArray();
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                Marshal.FreeCoTaskMem(buffer);
            }
        }

        protected override void Free()
        {
            if (Disposed) return;
            ErrorHelper.AssertSuccess(EglNativeMethods.EglTerminate(Handle));
        }
    }
}
