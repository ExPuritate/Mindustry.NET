namespace Arc.Utility
{
    /// <summary>
    /// Use this to avoid being incompatible with Java version
    /// </summary>
    public class ColorCodes
    {
        public static string
            flush = "\033[H\033[2J",
            reset = "\u001B[0m",
            bold = "\u001B[1m",
            italic = "\u001B[3m",
            underline = "\u001B[4m",
            black = "\u001B[30m",
            red = "\u001B[31m",
            green = "\u001B[32m",
            yellow = "\u001B[33m",
            blue = "\u001B[34m",
            purple = "\u001B[35m",
            cyan = "\u001B[36m",
            lightBlack = "\u001b[90m",
            lightRed = "\u001B[91m",
            lightGreen = "\u001B[92m",
            lightYellow = "\u001B[93m",
            lightBlue = "\u001B[94m",
            lightMagenta = "\u001B[95m",
            lightCyan = "\u001B[96m",
            lightWhite = "\u001b[97m",
            white = "\u001B[37m",

            backDefault = "\u001B[49m",
            backRed = "\u001B[41m",
            backGreen = "\u001B[42m",
            backYellow = "\u001B[43m",
            backBlue = "\u001B[44m";

        public static readonly string[] codes, values;

        static ColorCodes()
        {
            if (
                (OperatingSystem.IsWindows() && Environment.GetEnvironmentVariable("WT_SESSION") is not null)
                || OperatingSystem.IsAndroid())
            {
                flush = reset = bold = underline = black = red = green = yellow = blue = purple = cyan = lightWhite
                = lightBlack = lightRed = lightGreen = lightYellow = lightBlue = lightMagenta = lightCyan
                = white = backDefault = backRed = backYellow = backBlue = backGreen = italic = "";
            }

            Dictionary<string, string> map = new()
            {
                { "bd", backDefault },
                { "br", backRed },
                { "bg", backGreen },
                { "by", backYellow },
                { "bb", backBlue },

                { "ff", flush },
                { "fr", reset },
                { "fb", bold },
                { "fi", italic },
                { "fu", underline },
                { "k", black },
                { "lk", lightBlack },
                { "lw", lightWhite },
                { "r", red },
                { "g", green },
                { "y", yellow },
                { "b", blue },
                { "p", purple },
                { "c", cyan },
                { "lr", lightRed },
                { "lg", lightGreen },
                { "ly", lightYellow },
                { "lm", lightMagenta },
                { "lb", lightBlue },
                { "lc", lightCyan },
                { "w", white }
            };

            codes = [.. map.Keys];
            values = [.. map.Values];
        }
    }
}
