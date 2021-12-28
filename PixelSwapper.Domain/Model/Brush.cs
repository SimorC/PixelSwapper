using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PixelSwapper.Domain
{
    public class Brush
    {
        public static string EnumToHex (BrushColour colour)
        {
            switch (colour)
            {
                case BrushColour.LightGray:
                    return "#C8C8C8";
                case BrushColour.DarkGray:
                    return "#383838";
                case BrushColour.DarkerGray:
                    return "#080808";
                default: // LighterGray
                    return "#F8F8F8";
            }
        }
        public static SolidBrush HexToBrush(string hex)
        {
            var color = ColorTranslator.FromHtml(hex);
            return new SolidBrush(color);
        }
        public static SolidBrush EnumToBrush(BrushColour colour)
            => HexToBrush(EnumToHex(colour));
        public static SolidBrush ColorToBrush(Color colour)
            => new SolidBrush(colour);
    }

    public enum BrushColour
    {
        LightGray,
        LighterGray,
        DarkGray,
        DarkerGray
    }
}
