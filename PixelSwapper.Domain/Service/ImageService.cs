using System;
using System.Drawing;

namespace PixelSwapper.Domain
{
    public class ImageService : IImageService
    {
        private Bitmap ImageToBitmap(Image image)
            => new Bitmap(image);
        
        public Color[,] GetImagePixelColours(Image originalImage)
        {
            var width = originalImage.Width;
            var height = originalImage.Height;
            var colours = new Color[width, height];
            var image = ImageToBitmap(originalImage);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    colours[i, j] = image.GetPixel(i, j);
                }
            }

            return colours;
        }

        public Bitmap CreateEmptyImage(string path, int width, int height, BrushColour backgroundColour)
        {
            var newImage = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(newImage))
            {
                var solidBrush = Brush.EnumToBrush(backgroundColour);
                gfx.FillRectangle(solidBrush, 0, 0, width, height);
            }

            IOService.SaveImage(path, newImage); // To be removed on next commit
            return newImage;
        }

        public Bitmap WriteTextOnImage(bool[,] pixels, Bitmap image)
        {
            throw new NotImplementedException();
        }

        public Bitmap WriteTextOnImage(Color[,] pixels, Bitmap image)
        {
            throw new NotImplementedException();
        }
    }
}