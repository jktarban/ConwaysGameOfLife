using System;
using UnityEngine;

public static class ColorHelper
{
    public static Color ParseColor(string colorName)
    {
        var color = Color.white;
      
        if (Enum.TryParse(colorName, out EnumColors enumColor))
        {
            switch (enumColor)
            {
                case EnumColors.White:
                    color = Color.white;
                    break;
                case EnumColors.Green:
                    color = Color.green;
                    break;
                case EnumColors.Red:
                    color = Color.red;
                    break;
                case EnumColors.Blue:
                    color = Color.blue;
                    break;
                case EnumColors.Cyan:
                    color = Color.cyan;
                    break;
                case EnumColors.Gray:
                    color = Color.gray;
                    break;
                case EnumColors.Magenta:
                    color = Color.magenta;
                    break;
                case EnumColors.Yellow:
                    color = Color.yellow;
                    break;
            }
        }

        return color;
    }

    public enum EnumColors
    {
        White,
        Green,
        Red,
        Blue,
        Cyan,
        Gray,
        Magenta,
        Yellow
    }
}
