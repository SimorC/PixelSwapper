using System.Drawing;

namespace PixelSwapper.Domain
{
    public interface IImageService
    {
        Color[,] GetImagePixelColours(Image image);
        Bitmap CreateEmptyImage(string path, int width, int height, BrushColour backgroundColour);
        Bitmap WriteTextOnImage(Color[,] pixels, Bitmap image);
    }
}