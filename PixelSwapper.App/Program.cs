﻿using Microsoft.Extensions.Configuration;
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
            _defaultFileFullPath = _defaultInPath + _defaultFileName;
        }

        private static void StartServices()
        {
            _imageService = new ImageService();
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
                _imageService.CreateEmptyImage(_defaultOutPath, 100, 100, BrushColour.LighterGray);
                Console.WriteLine("Image created");
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
    }
}
