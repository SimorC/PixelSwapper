using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PixelSwapper.Domain
{
    public interface IImageService
    {
        Color[,] GetImagePixelColours(Image image);
        Bitmap CreateEmptyImage(string path, int width, int height, BrushColour backgroundColour);
        Bitmap WriteTextOnImage(bool[,] pixels, Bitmap image);
        Bitmap WriteTextOnImage(Color[,] pixels, Bitmap image);
    }
}