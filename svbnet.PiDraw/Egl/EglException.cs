using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw.Egl
{
    public sealed class EglException : Exception
    {
        private static string ExplainError(int error)
        {
            var explanation = "Unknown error";
            switch ((EglError)error)
            {
                case EglError.Success:
                    explanation = "Succeeded";
                    break;

                case EglError.NotInitialized:
                    explanation = "EGL is not initialized, or could not be initialized, for the specified display.";
                    break;

                case EglError.BadAccess:
                    explanation =
                        "EGL cannot access a requested resource.";
                    break;

                case EglError.BadAlloc:
                    explanation = "EGL failed to allocate resources for the requested operation.";
                    break;

                case EglError.BadAttribute:
                    explanation = "An unrecognized attribute or attribute value was passed in an attribute list.";
                    break;

                case EglError.BadConfig:
                    explanation = "An EGLConfig argument does not name a valid EGLConfig.";
                    break;

                case EglError.BadContext:
                    explanation = "An EGLContext argument does not name a valid EGLContext.";
                    break;

                case EglError.BadCurrentSurface:
                    explanation =
                        "The current surface of the calling thread is a window, pbuffer, or pixmap that is no longer valid.";
                    break;

                case EglError.BadDisplay:
                    explanation = "An EGLDisplay argument does not name a valid EGLDisplay.";
                    break;

                case EglError.BadMatch:
                    explanation = "Arguments are inconsistent";
                    break;

                case EglError.BadNativePixmap:
                    explanation = "An EGLNativePixmapType argument does not refer to a valid native pixmap.";
                    break;

                case EglError.BadNativeWindow:
                    explanation = "An EGLNativeWindowType argument does not refer to a valid native window.";
                    break;

                case EglError.BadParameter:
                    explanation = "One or more argument values are invalid.";
                    break;

                case EglError.BadSurface:
                    explanation =
                        "An EGLSurface argument does not name a valid surface (window, pbuffer, or pixmap) configured for rendering.";
                    break;

                case EglError.ContextLost:
                    explanation =
                        "A power management event has occurred. The application must destroy all contexts and reinitialise client API state and objects to continue rendering.";
                    break;
            }

            return explanation;
        }

        public int Error { get; }

        public EglException(int error) : base($"0x{error:X} {ExplainError(error)}")
        {
            Error = error;
        }
    }
}
