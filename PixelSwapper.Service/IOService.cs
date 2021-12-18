using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PixelSwapper.Service
{
    public class IOService
    {
        public static Image LoadImage(string path)
            => Image.FromFile(path);
    }
}
