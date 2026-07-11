using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Arc.Utility.Serialization
{
    public class JsonWriter(TextWriter writer): TextWriter, IBaseJsonWriter<JsonWriter>
    {
        readonly TextWriter writer = writer;
        Stack<JsonObject> stack = new();
        JsonObject? current;
        bool named;
        OutputType outputType = OutputType.Json;
        bool quoteLongValues = false;

        public TextWriter Writer => writer;

        public override Encoding Encoding => writer.Encoding;

        public void SetOutputType(OutputType outputType) => this.outputType = outputType;
        public void SetQuoteLongValues(bool quoteLongValues) => this.quoteLongValues = quoteLongValues;
        public JsonWriter Name(string name)
        {
            if (current is null || current.array)
            {
                throw new InvalidOperationException("Current item must be an object.");
            }
            if (!current.needsComma)
            {
                current.needsComma = true;
            } else
            {
                writer.Write(',');
            }
            writer.Write(outputType.QuoteName(name));
            writer.Write(':');
            named = true;
            return this;
        }
        public JsonWriter Object()
        {
            RequireCommaOrName();
            stack.Push(current = new(false, writer));
            return this;
        }
        public JsonWriter Array()
        {
            RequireCommaOrName();
            stack.Push(current = new(true, writer));
            return this;
        }
        public JsonWriter Value(object? value)
        {
            if (quoteLongValues
                && value is long or double or decimal or BigInteger)
            {
                value = value.ToString();
            } else if (value?.__IsNumericType() ?? false)
            {
                long longValue = value.__LongValue();
                if (value.__DoubleValue() == longValue)
                {
                    value = longValue;
                }
            }
            RequireCommaOrName();
            writer.Write(outputType.QuoteValue(value));
            return this;
        }

        private void RequireCommaOrName()
        {
            if (current is null)
            {
                return;
            }
            if (current.array)
            {
                if (!current.needsComma)
                {
                    current.needsComma = true;
                } else
                {
                    writer.Write(',');
                }
            } else
            {
                if (!named)
                {
                    throw new InvalidOperationException("Name must be set.");
                }
                named = false;
            }
        }

        public JsonWriter Object(string name) => Name(name).Object();
        public JsonWriter Array(string name) => Name(name).Array();
        public JsonWriter Set(string name, object? value) => Name(name).Value(value);
        public JsonWriter Pop()
        {
            if (named)
            {
                throw new InvalidOperationException("Expected an object, array, or value since a name was set.");
            }
            stack.Pop().Close(writer);
            current = stack.Count == 0 ? null : stack.Peek();
            return this;
        }

        public override void Write(char[] buffer, int index, int count) => writer.Write(buffer, index, count);
        public override void Flush() => writer.Flush();

        protected override void Dispose(bool disposing)
        {
            while (stack.Count > 0)
            {
                Pop();
            }
            writer.Dispose();
        }

        private class JsonObject
        {
            public bool array;
            public bool needsComma;

            public JsonObject(bool array, TextWriter writer)
            {
                this.array = array;
                writer.Write(array ? '[' : '{');
            }

            public void Close(TextWriter writer) => writer.Write(array ? ']' : '}');
        }
    }

    public enum OutputType
    {
        /// <summary>
        /// Normal JSON, with all its double quotes.
        /// </summary>
        Json,
        /// <summary>
        /// Like JSON, but names are only double quoted if necessary.
        /// </summary>
        Javascript,
        /// <summary>
        /// Like JSON, but:
        /// <list>
        ///     <item>
        ///         Names only require double quotes if they start with <c>space</c> or any of <c>":,}/</c> or they contain
        ///         <c>//</c> or <c>/*</c> or <c>:</c>.
        ///     </item>
        ///     <item>
        ///         Values only require double quotes if they start with <c>space</c> or any of <c>":,{[]/</c> or they
        ///         contain <c>//</c> or <c>/*</c> or any of <c>}],</c> or they are equal to <c>true</c>,
        ///         <c>false</c> , or <c>null</c>.
        ///     </item>
        ///     <item>Newlines are treated as commas, making commas optional in many cases.</item>
        ///     <item>C style comments may be used: <c>//...</c> or <c>/*...*<b></b>/</c></item>
        /// </list>
        /// </summary>
        Minimal,
    }

    public static partial class OutputTypeExtensions
    {
        private static readonly Regex javascriptPattern = JavascriptPattern();
        private static readonly Regex minimalNamePattern = MinimalNamePattern();
        private static readonly Regex minimalValuePattern = MinimalValuePattern();
        extension(object obj)
        {
            internal bool __IsNumericType() => obj switch
            {
                null => false,
                byte
                    or sbyte
                    or ushort
                    or short
                    or uint
                    or int
                    or ulong
                    or long
                    or float
                    or double
                    or decimal => true,
                _ => false,
            };
            internal byte __ByteValue() => obj switch
            {
                byte val => val,
                sbyte val => (byte) val,
                ushort val => (byte) val,
                short val => (byte) val,
                uint val => (byte) val,
                int val => (byte) val,
                ulong val => (byte) val,
                long val => (byte) val,
                float val => (byte) val,
                double val => (byte) val,
                decimal val => (byte) val,
                _ => throw new InvalidOperationException("Not a number"),
            };
            internal short __ShortValue() => obj switch
            {
                byte val => val,
                sbyte val => (byte) val,
                ushort val => (byte) val,
                short val => (byte) val,
                uint val => (byte) val,
                int val => (byte) val,
                ulong val => (byte) val,
                long val => (byte) val,
                float val => (byte) val,
                double val => (byte) val,
                decimal val => (byte) val,
                _ => throw new InvalidOperationException("Not a number"),
            };
            internal int __IntValue() => obj switch
            {
                byte val => val,
                sbyte val => (byte) val,
                ushort val => (byte) val,
                short val => (byte) val,
                uint val => (byte) val,
                int val => (byte) val,
                ulong val => (byte) val,
                long val => (byte) val,
                float val => (byte) val,
                double val => (byte) val,
                decimal val => (byte) val,
                _ => throw new InvalidOperationException("Not a number"),
            };
            internal long __LongValue() => obj switch
            {
                byte val => val,
                sbyte val => val,
                ushort val => val,
                short val => val,
                uint val => val,
                int val => val,
                ulong val => (long) val,
                long val => val,
                float val => (long) val,
                double val => (long) val,
                decimal val => (long) val,
                _ => throw new InvalidOperationException("Not a number"),
            };
            internal float __FloatValue() => obj switch
            {
                byte val => val,
                sbyte val => val,
                ushort val => val,
                short val => val,
                uint val => val,
                int val => val,
                ulong val => val,
                long val => val,
                float val => val,
                double val => (float) val,
                decimal val => (float) val,
                _ => throw new InvalidOperationException("Not a number"),
            };
            internal double __DoubleValue() => obj switch
            {
                byte val => val,
                sbyte val => val,
                ushort val => val,
                short val => val,
                uint val => val,
                int val => val,
                ulong val => val,
                long val => val,
                float val => val,
                double val => val,
                decimal val => (double) val,
                _ => throw new InvalidOperationException("Not a number"),
            };
        }

        extension(OutputType type)
        {
            public string QuoteValue(object? value)
            {
                if (value is null)
                {
                    return "null";
                }
                string? str = value.ToString();
                if (value.__IsNumericType() || value is bool)
                {
                    return str!;
                }
                StringBuilder buffer = new(str);
                buffer.Replace("\\", "\\\\");
                buffer.Replace("\r", "\\r");
                buffer.Replace("\n", "\\n");
                buffer.Replace("\t", "\\t");
                if (
                    type == OutputType.Minimal
                    && str != "true"
                    && str != "false"
                    && str != "null"
                    && !(str?.Contains("//") ?? false)
                    && !(str?.Contains("/*") ?? false))
                {
                    int length = buffer.Length;
                    string bufferStr = buffer.ToString();
                    if (
                        length > 0
                        && buffer[length - 1] != ' '
                        && minimalValuePattern.IsMatch(bufferStr))
                    {
                        return bufferStr;
                    }
                }
                buffer.Replace("\"", "\\\"");
                return '"' + buffer.ToString() + '"';
            }

            public string QuoteName(string value)
            {
                StringBuilder buffer = new(value);
                buffer.Replace("\\", "\\\\");
                buffer.Replace("\r", "\\r");
                buffer.Replace("\n", "\\n");
                buffer.Replace("\t", "\\t");
                string bufferStr = buffer.ToString();
                switch (type)
                {
                    case OutputType.Minimal:
                        if (!value.Contains("//")
                            && !value.Contains("/*")
                            && minimalNamePattern.IsMatch(bufferStr))
                        {
                            return bufferStr;
                        }
                        break;
                    case OutputType.Javascript:
                        if (javascriptPattern.IsMatch(bufferStr))
                        {
                            return bufferStr;
                        }
                        break;
                }
                buffer.Replace("\"", "\\\"");
                return '"' + buffer.ToString() + '"';
            }
        }

        [GeneratedRegex("^[a-zA-Z_$][a-zA-Z_$0-9]*$")]
        private static partial Regex JavascriptPattern();
        [GeneratedRegex("^[^\":,}/ ][^:]*$")]
        private static partial Regex MinimalNamePattern();
        [GeneratedRegex("^[^\":,{\\[\\]/ ][^}\\],]*$")]
        private static partial Regex MinimalValuePattern();
    }
}
