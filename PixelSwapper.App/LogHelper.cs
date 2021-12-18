using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PixelSwapper.App
{
    internal static class LogHelper
    {
        internal static void LogImageLoad(System.Drawing.Image image)
        {
            Console.WriteLine("Image loaded.");
            Console.WriteLine($"Width: {image.Width}");
            Console.WriteLine($"Height: {image.Height}");
        }
    }
}