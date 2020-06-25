using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw.Egl
{
    /// <summary>
    /// Exposes methods that are bound to the calling thread.
    /// </summary>
    public static class CurrentThread
    {
        /// <summary>
        /// Sets the rendering API for the current thread.
        /// </summary>
        /// <param name="api">The API to bind.</param>
        public static void BindApi(uint api)
        {
            ErrorHelper.AssertSuccess(EglNativeMethods.EglBindApi(api));
        }

        /// <summary>
        /// Sets the rendering API for the current thread.
        /// </summary>
        /// <param name="api">The API to bind.</param>
        public static void BindApi(EglApi api)
        {
            BindApi((uint)api);
        }
    }
}
