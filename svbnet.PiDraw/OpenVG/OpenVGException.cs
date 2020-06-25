using System;

namespace svbnet.PiDraw.OpenVG
{
    public sealed class OpenVGException : Exception
    {
        private static string GetErrorFriendlyName(OpenVGError error)
        {
            switch (error)
            {
                case OpenVGError.VgNoError:
                    return "No error";
                    
                case OpenVGError.VgBadHandleError:
                    return "Bad handle";

                case OpenVGError.VgIllegalArgumentError:
                    return "Illegal argument";

                case OpenVGError.VgOutOfMemoryError:
                    return "Out of memory";

                case OpenVGError.VgPathCapabilityError:
                    return "Path not capable";

                case OpenVGError.VgUnsupportedImageFormatError:
                    return "Unsupported image format";

                case OpenVGError.VgUnsupportedPathFormatError:
                    return "Unsupported path format";

                case OpenVGError.VgImageInUseError:
                    return "Image in use";

                case OpenVGError.VgNoContextError:
                    return "No context";

                default:
                    return "Unknown error";
            }
        }

        public OpenVGException(OpenVGError error) : base($"0x{error:X}: {GetErrorFriendlyName(error)}")
        {

        }
    }
}
