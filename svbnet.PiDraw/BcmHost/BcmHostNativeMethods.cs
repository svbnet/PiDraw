using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using svbnet.PiDraw.DispManX;
using svbnet.PiDraw.VcTypes;

namespace svbnet.PiDraw.BcmHost
{
    /// <summary>
    /// Methods as defined in include/bcm_host.h.
    /// </summary>
    public class BcmHostNativeMethods
    {
        private const string BcmHost = "libbcm_host";

        #region " Functions defined in include/bcm_host.h "
        [DllImport(BcmHost, EntryPoint = "bcm_host_init", CallingConvention = CallingConvention.Cdecl)]
        public static extern void BcmHostInit();

        [DllImport(BcmHost, EntryPoint = "bcm_host_deinit", CallingConvention = CallingConvention.Cdecl)]
        public static extern void BcmHostDeinit();

        [DllImport(BcmHost, EntryPoint = "graphics_get_display_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GraphicsGetDisplaySize(ushort displayNumber, ref uint width, ref uint height);
        #endregion

        #region " Functions defined in include/interface/vmcs_host/vc_dispmanx.h "

            #region " Resources "
        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_resource_create", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint VcDispmanxResourceCreate(VcImageType type, uint width, uint height, ref uint nativeImageHandle);

        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_resource_write_data",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int VcDispmanxResourceWriteData(uint res, VcImageType srcType, int srcPitch,
            IntPtr srcAddress, ref VcRect rect);

        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_resource_read_data", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VcDispmanxResourceReadData(uint handle, ref VcRect pRect, IntPtr dstAddress,
            uint dstPitch);

        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_resource_delete", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VcDispmanxResourceDelete(uint res);
        #endregion

        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_display_open", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint VcDispmanxDisplayOpen(uint device);

        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_display_open_mode", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint VcDispmanxDisplayOpenMode(uint device, uint mode);

        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_display_reconfigure", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VcDispmanxDisplayReconfigure(uint displayHandle, uint mode);

        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_display_set_background", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VcDispmanxDisplaySetBackground(uint updateHandle, uint displayHandle, byte red,
            byte green, byte blue);

        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_display_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VcDispmanxDisplayClose(uint displayHandle);


        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_update_start", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint VcDispmanxUpdateStart(int priority);

        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_element_add", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint VcDispmanxElementAdd(uint updateHandle, uint displayHandle, int layer,
            ref VcRect destRect, uint srcResourceHandle, ref VcRect srcRect, 
            Protection protection, VcAlpha alpha, Clamp clamp, Transform transform);

        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_element_remove", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VcDispmanxElementRemove(uint updateHandle, uint elementHandle);

        [DllImport(BcmHost, EntryPoint = "vc_dispmanx_update_submit_sync", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VcDispmanxUpdateSubmitSync(uint updateHandle);

        #endregion
    }
}
