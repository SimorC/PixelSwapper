using System;
using System.Drawing;
using System.Threading.Tasks;

namespace PixelSwapper.Domain
{
    public class ImageService : IImageService
    {
        private string FontName { get; }
        private string Character { get; }
        private int FontSize { get; }
        private float FinalSizeIncrease { get; }
        private int FinalSizePadding { get; }

        public ImageService(string fontName, string character, int fontSize, float finalSizeIncrease, int finalSizePadding)
        {
            FontName = fontName;
            Character = character;
            FontSize = fontSize;
            FinalSizeIncrease = finalSizeIncrease;
            FinalSizePadding = finalSizePadding;
        }

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

            return newImage;
        }

        public Bitmap WriteTextOnImage(Color[,] pixels, Bitmap image)
        {
            Graphics graphics = Graphics.FromImage(image);
            Font font = new Font(FontName, FontSize, FontStyle.Bold);

            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    Draw(pixels, graphics, font, i, j);
                }
            }

            // Manually disposing instead of `using` mostly for code readability
            graphics.Dispose();
            font.Dispose();

            return image;
        }

        private void Draw(Color[,] pixels, Graphics graphics, Font font, int i, int j)
        {
            float x = i * FinalSizeIncrease + (FinalSizePadding / 2);
            float y = j * FinalSizeIncrease + (FinalSizePadding / 2);

            graphics.DrawString(Character, font, Brush.ColorToBrush(pixels[i, j]), x, y);
        }
    }
}