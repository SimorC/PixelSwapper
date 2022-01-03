using System;

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