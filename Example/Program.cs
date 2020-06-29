using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using CommandLine;
using Example.Examples;
using svbnet.PiDraw.BcmHost;
using svbnet.PiDraw.DispManX;
using svbnet.PiDraw.VcTypes;

namespace Example
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<ImageExample, TextWatermarkExample, SnapshotExample>(args)
                .WithParsed((ExampleBase example) => example.Run());
        }
    }
}
