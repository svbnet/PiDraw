using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw
{
    internal static class Util
    {
        public static int RoundTo16th(int val)
        {
            return (val + 15) & ~15;
        }
    }
}
