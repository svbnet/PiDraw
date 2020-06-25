namespace svbnet.PiDraw.OpenVG
{
    /// <summary>
    /// Exposes methods that are bound to the current drawing context for the current thread.
    /// </summary>
    public static partial class CurrentDrawingContext
    {
        public static float GetFloatParam(int type)
        {
            var ret = OpenVGNativeMethods.VGGetf(type);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public static int GetIntParam(int type)
        {
            var ret = OpenVGNativeMethods.VGGeti(type);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public static int GetParamVectorSize(int type)
        {
            var ret = OpenVGNativeMethods.VGGetVectorSize(type);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public static float[] GetFloatVectorParam(int type)
        {
            var size = GetParamVectorSize(type);
            var ret = new float[size];
            OpenVGNativeMethods.VGGetfv(type, size, ret);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public static float[] GetFloatVectorParam(int type, int count)
        {
            var ret = new float[count];
            OpenVGNativeMethods.VGGetfv(type, count, ret);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public static int[] GetIntVectorParam(int type)
        {
            var size = GetParamVectorSize(type);
            var ret = new int[size];
            OpenVGNativeMethods.VGGetiv(type, size, ret);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public static int[] GetIntVectorParam(int type, int count)
        {
            var ret = new int[count];
            OpenVGNativeMethods.VGGetiv(type, count, ret);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public static void SetParam(int type, float value)
        {
            OpenVGNativeMethods.VGSetf(type, value);
            ErrorHelper.ThrowIfLastError();
        }

        public static void SetParam(int type, int value)
        {
            OpenVGNativeMethods.VGSeti(type, value);
            ErrorHelper.ThrowIfLastError();
        }

        public static void SetParam(int type, float[] values)
        {
            OpenVGNativeMethods.VGSetfv(type, values.Length, values);
            ErrorHelper.ThrowIfLastError();
        }

        public static void SetParam(int type, int[] values)
        {
            OpenVGNativeMethods.VGSetiv(type, values.Length, values);
            ErrorHelper.ThrowIfLastError();
        }
    }
}
