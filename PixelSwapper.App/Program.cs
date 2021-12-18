using Microsoft.Extensions.Configuration;
using System;

namespace PixelSwapper.App
{
    class Program
    {
        private static IConfigurationRoot _config;

        public static void SetupConfig()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appsettings.json", true, true);

            _config = builder.Build();
        }

        static void Main(string[] args)
        {
            SetupConfig();

            var defaultFileName = _config["DefaultFileName"];
            Console.WriteLine($"Press enter to process 'in/{defaultFileName}'...");
            Console.ReadKey();


        }
    }
}
