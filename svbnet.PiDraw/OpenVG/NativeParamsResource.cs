using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw.OpenVG
{
    public abstract class NativeParamsResource : NativeResource
    {
        public float GetFloatParam(int type)
        {
            var ret = OpenVGNativeMethods.VGGetParameterf(Handle, type);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public int GetIntParam(int type)
        {
            var ret = OpenVGNativeMethods.VGGetParameteri(Handle, type);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public int GetParamVectorSize(int type)
        {
            var ret = OpenVGNativeMethods.VGGetParameterVectorSize(Handle, type);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public float[] GetFloatVectorParam(int type)
        {
            var size = GetParamVectorSize(type);
            var ret = new float[size];
            OpenVGNativeMethods.VGGetParameterfv(Handle, type, size, ret);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public float[] GetFloatVectorParam(int type, int count)
        {
            var ret = new float[count];
            OpenVGNativeMethods.VGGetParameterfv(Handle, type, count, ret);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public int[] GetIntVectorParam(int type)
        {
            var size = GetParamVectorSize(type);
            var ret = new int[size];
            OpenVGNativeMethods.VGGetParameteriv(Handle, type, size, ret);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public int[] GetIntVectorParam(int type, int count)
        {
            var ret = new int[count];
            OpenVGNativeMethods.VGGetParameteriv(Handle, type, count, ret);
            ErrorHelper.ThrowIfLastError();
            return ret;
        }

        public void SetParam(int type, float value)
        {
            OpenVGNativeMethods.VGSetParameterf(Handle, type, value);
            ErrorHelper.ThrowIfLastError();
        }

        public void SetParam(int type, int value)
        {
            OpenVGNativeMethods.VGSetParameteri(Handle, type, value);
            ErrorHelper.ThrowIfLastError();
        }

        public void SetParam(int type, float[] values)
        {
            OpenVGNativeMethods.VGSetParameterfv(Handle, type, values.Length, values);
            ErrorHelper.ThrowIfLastError();
        }

        public void SetParam(int type, int[] values)
        {
            OpenVGNativeMethods.VGSetParameteriv(Handle, type, values.Length, values);
            ErrorHelper.ThrowIfLastError();
        }
    }
}
