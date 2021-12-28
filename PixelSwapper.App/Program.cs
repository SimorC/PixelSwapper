using Microsoft.Extensions.Configuration;
using PixelSwapper.Domain;
using System;

namespace PixelSwapper.App
{
    class Program
    {
        private static IConfigurationRoot _config;
        private static IImageService _imageService;

        private static string _defaultFileName;
        private static string _defaultInPath;
        private static string _defaultOutPath;
        private static string _defaultFileFullPath;
        private static float _finalSizeIncrease;
        private static int _finalSizePadding;

        private static void Startup()
        {
            StartConfig();
            StartServices();
        }

        private static void StartConfig()
        {
            // AppSettings / Config
            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appsettings.json", true, true);

            _config = builder.Build();

            // Set values
            _defaultFileName = _config["DefaultFileName"];
            _defaultInPath = _config["DefaultInFolder"];
            _defaultOutPath = _config["DefaultOutFolder"];
            _finalSizeIncrease = float.Parse(_config["FinalSizeIncrease"]);
            _finalSizePadding = int.Parse(_config["FinalSizePadding"]);
            _defaultFileFullPath = _defaultInPath + _defaultFileName;
        }

        private static void StartServices()
        {
            string fontName = _config["DefaultFont"];
            string character = _config["DefaultSwapper"];
            int fontSize = int.Parse(_config["DefaultFontSize"]);
            
            _imageService = new ImageService(fontName, character, fontSize, _finalSizeIncrease, _finalSizePadding);
        }

        static void Main(string[] args)
        {
            Startup();

            Console.WriteLine($"Press enter to process '{_defaultFileFullPath}'...");
            Console.ReadKey();

            ProcessImage();
            Console.ReadKey();
        }

        private static void ProcessImage()
        {
            try
            {
                var image = IOService.LoadImage(_defaultFileFullPath);
                LogHelper.LogImageLoad(image);

                var colours = _imageService.GetImagePixelColours(image);
                var outImage = CreateOutImage(image);
                Console.WriteLine("Image created");

                outImage = _imageService.WriteTextOnImage(colours, outImage);
                Console.WriteLine("Image modified");

                IOService.SaveImage(_defaultOutPath, outImage);
                Console.WriteLine("Image saved");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception: {ex.Message}");
            }
        }

        private static System.Drawing.Bitmap CreateOutImage(System.Drawing.Image image)
        {
            var sizeX = (int)(image.Width * _finalSizeIncrease) + _finalSizePadding;
            var sizeY = (int)(image.Height * _finalSizeIncrease) + _finalSizePadding;

            return _imageService.CreateEmptyImage(_defaultOutPath, sizeX, sizeY, BrushColour.LighterGray);
        }
    }
}
