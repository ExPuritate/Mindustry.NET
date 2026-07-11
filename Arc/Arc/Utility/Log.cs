using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Arc.Utility
{
    public class Logger
    {
        public bool useColors;
        public LogLevel level =
#if DEBUG
            LogLevel.Debug
#else
            LogLevel.Info
#endif
            ;
        public LogHandler logger = DefaultLogHandler;
        public LogFormatter formatter = DefaultLogFormatter;

        public static Logger Instance = new();

        public void Log(LogLevel level, string text, params ReadOnlySpan<object?> args)
        {
            if (((int) this.level) > ((int) level))
            {
                return;
            }
            logger(this, level, Format(text, args));
        }

        public void Debug(string text, params ReadOnlySpan<object?> args) => Log(LogLevel.Debug, text, args);
        public void Debug(object obj) => Debug(obj.ToString()!);

        public void InfoList(params ReadOnlySpan<object?> args)
        {
            if (((int) this.level) > ((int) level))
            {
                return;
            }
            StringBuilder builder = new();
            foreach (object? val in args)
            {
                builder.Append(val);
                builder.Append(' ');
            }
            Info(builder.ToString());
        }
        public void InfoTag(string tag, string text) => Log(LogLevel.Info, "[" + tag + "] " + text);
        public void Info(string text, params ReadOnlySpan<object?> args) => Log(LogLevel.Info, text, args);
        public void Info(object obj) => Info(obj.ToString()!);

        public void Warn(string text, params ReadOnlySpan<object?> args) => Log(LogLevel.Warn, text, args);

        public void ErrTag(string tag, string text) => Log(LogLevel.Err, "[" + tag + "] " + text);
        public void Err(string text, params ReadOnlySpan<object?> args) => Log(LogLevel.Err, text, args);
        public void Err(Exception ex) => Err(ex.ToString());

        public void Err(string text, Exception ex) => Err(text + ": " + ex.ToString());

        public string Format(string text, params ReadOnlySpan<object?> args) =>
            FormatColors(text, useColors, args);

        public string FormatColors(string text, bool useColors, params ReadOnlySpan<object?> args) =>
            formatter(text, useColors, args);

        public static string RemoveColors(string text)
        {
            foreach (string color in ColorCodes.codes)
            {
                text = text.Replace("&" + color, "");
            }
            return text;
        }
        public static string AddColors(string text)
        {
            foreach ((string colorCode, string colorValue) in ColorCodes.codes.Zip(ColorCodes.values))
            {
                text = text.Replace("&" + colorCode, colorValue);
            }
            return text;
        }

        public static string DefaultLogFormatter(
            string text,
            bool useColors,
            params ReadOnlySpan<object?> args)
        {
            text = string.Format(text, args);
            return useColors ? AddColors(text) : RemoveColors(text);
        }

        public static void DefaultLogHandler(Logger that, LogLevel level, string text) =>
            Console.WriteLine(that.Format((
                level == LogLevel.Debug ? "&lc&fb" :
                level == LogLevel.Info ? "&fb" :
                level == LogLevel.Warn ? "&ly&fb" :
                level == LogLevel.Err ? "&lr&fb" :
                "") + text + "&fr"));
        public static void NoopLogHandler(Logger that, LogLevel level, string text)
        {
        }
    }

    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Err,
        None,
    }

    public delegate string LogFormatter(
        [StringSyntax(StringSyntaxAttribute.CompositeFormat)] string text,
        bool useColors,
        params ReadOnlySpan<object?> args);

    public delegate void LogHandler(Logger that, LogLevel level, string text);
}
