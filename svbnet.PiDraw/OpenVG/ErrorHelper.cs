using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw.OpenVG
{
    internal static class ErrorHelper
    {
        /// <summary>
        /// Throw an OpenVGException if result == false.
        /// </summary>
        /// <param name="result">Function result</param>
        public static void AssertSuccess(bool result)
        {
            if (result) return;
            throw new OpenVGException(OpenVGNativeMethods.VGGetError());
        }

        /// <summary>
        /// Throw an OpenVGException if result == zero (null pointer).
        /// </summary>
        /// <param name="result">Function result</param>
        /// <returns>Result</returns>
        public static IntPtr AssertSuccess(IntPtr result)
        {
            if (result != IntPtr.Zero) return result;
            throw new OpenVGException(OpenVGNativeMethods.VGGetError());
        }

        /// <summary>
        /// Throw an OpenVGException if vgGetError != success.
        /// </summary>
        public static void ThrowIfLastError()
        {
            var error = OpenVGNativeMethods.VGGetError();
            if (error == OpenVGError.VgNoError) return;
            throw new OpenVGException(error);
        }
    }
}
