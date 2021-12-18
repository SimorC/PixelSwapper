using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PixelSwapper.Domain
{
    public class IOService
    {
        public static Image LoadImage(string path)
            => Image.FromFile(path);

        public static void SaveImage(string path, Bitmap image)
        {
            var fileName = Guid.NewGuid();
            var dirInfo = new System.IO.DirectoryInfo(path);
            CheckDirectoryExists(dirInfo);

            image.Save(path + fileName + ".png");
        }

        private static void CheckDirectoryExists(System.IO.DirectoryInfo dirInfo)
        {
            if (!dirInfo.Exists)
            {
                System.IO.Directory.CreateDirectory(dirInfo.FullName);
            }
        }
    }
}
