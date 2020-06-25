using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw.Egl
{
    internal static class ErrorHelper
    {
        /// <summary>
        /// Throw an EglException if result == false.
        /// </summary>
        /// <param name="result">Function result</param>
        public static void AssertSuccess(bool result)
        {
            if (result) return;
            throw new EglException(EglNativeMethods.EglGetError());
        }

        /// <summary>
        /// Throw an EglException if result == zero (null pointer).
        /// </summary>
        /// <param name="result">Function result</param>
        /// <returns>Result</returns>
        public static IntPtr AssertSuccess(IntPtr result)
        {
            if (result != IntPtr.Zero) return result;
            throw new EglException(EglNativeMethods.EglGetError());
        }

        /// <summary>
        /// Throw an EglException if eglGetError != success.
        /// </summary>
        public static void ThrowIfLastError()
        {
            var error = EglNativeMethods.EglGetError();
            if ((EglError) error == EglError.Success) return;
            throw new EglException(error);
        }
    }
}
