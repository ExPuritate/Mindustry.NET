using System.Buffers.Binary;
using System.Text;

namespace Arc.Utility.Serialization
{
    public class UBJsonWriter(BinaryWriter writer): IDisposable, IBaseJsonWriter<UBJsonWriter>
    {
        BinaryWriter writer = writer;
        Stack<JsonObject> stack = new();
        JsonObject? current;
        bool named;

        public void Reset()
        {
            stack.Clear();
            current = null;
            named = false;
        }

        public UBJsonWriter Object()
        {
            CheckName();
            stack.Push(current = new(false, writer));
            return this;
        }
        public UBJsonWriter Object(string name) => Name(name).Object();

        public UBJsonWriter Array()
        {
            CheckName();
            stack.Push(current = new(true, writer));
            return this;
        }
        public UBJsonWriter Array(string name) => Name(name).Array();

        public UBJsonWriter Name(string name)
        {
            if (current == null || current.array)
            {
                throw new InvalidOperationException("Current item must be an object.");
            }
            Span<byte> bytes = stackalloc byte[Encoding.UTF8.GetByteCount(name)];
            int byteCount = Encoding.UTF8.GetBytes(name, bytes);
            if (byteCount <= byte.MaxValue)
            {
                writer.Write((byte) 'i');
                writer.Write((byte) byteCount);
            } else if (byteCount <= short.MaxValue)
            {
                writer.Write((byte) 'I');
                WriteShort((short) byteCount);
            } else if (byteCount <= int.MaxValue)
            {
                writer.Write((byte) 'l');
                WriteInt(byteCount);
            }
            writer.Write(bytes[..byteCount]);
            named = true;
            return this;
        }

        #region Value
        /**
         * Appends a {@code byte} value to the stream. This corresponds to the {@code int8} value type in the UBJSON specification.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(byte value)
        {
            CheckName();
            writer.Write((byte) 'i');
            writer.Write(value);
            return this;
        }

        /**
         * Appends a {@code short} value to the stream. This corresponds to the {@code int16} value type in the UBJSON specification.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(short value)
        {
            CheckName();
            writer.Write((byte) 'I');
            WriteShort(value);
            return this;
        }

        /**
         * Appends an {@code int} value to the stream. This corresponds to the {@code int32} value type in the UBJSON specification.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(int value)
        {
            CheckName();
            writer.Write((byte) 'l');
            WriteInt(value);
            return this;
        }

        /**
         * Appends a {@code long} value to the stream. This corresponds to the {@code int64} value type in the UBJSON specification.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(long value)
        {
            CheckName();
            writer.Write((byte) 'L');
            WriteLong(value);
            return this;
        }

        /**
         * Appends a {@code float} value to the stream. This corresponds to the {@code float32} value type in the UBJSON specification.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(float value)
        {
            CheckName();
            writer.Write((byte) 'd');
            writer.Write(value);
            return this;
        }

        /**
         * Appends a {@code double} value to the stream. This corresponds to the {@code float64} value type in the UBJSON
         * specification.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(double value)
        {
            CheckName();
            writer.Write((byte) 'D');
            WriteDouble(value);
            return this;
        }

        /**
         * Appends a {@code boolean} value to the stream. This corresponds to the {@code boolean} value type in the UBJSON
         * specification.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(bool value)
        {
            CheckName();
            writer.Write(value ? (byte) 'T' : (byte) 'F');
            return this;
        }

        /**
         * Appends a {@code char} value to the stream. Because, in Java, a {@code char} is 16 bytes, this corresponds to the
         * {@code int16} value type in the UBJSON specification.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(char value)
        {
            CheckName();
            writer.Write((byte) 'I');
            WriteChar(value);
            return this;
        }

        /**
         * Appends a {@code string} value to the stream. This corresponds to the {@code string} value type in the UBJSON specification.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(string value)
        {
            CheckName();
            int byteCount = Encoding.UTF8.GetByteCount(value);
            Span<byte> bytes = stackalloc byte[byteCount];
            Encoding.UTF8.GetBytes(value, bytes);
            writer.Write((byte) 'S');
            if (byteCount <= byte.MaxValue)
            {
                writer.Write((byte) 'i');
                writer.Write((byte) bytes.Length);
            } else if (byteCount <= short.MaxValue)
            {
                writer.Write((byte) 'I');
                WriteShort((short) byteCount);
            } else
            {
                writer.Write((byte) 'l');
                WriteInt(byteCount);
            }
            writer.Write(bytes);
            return this;
        }

        /**
         * Appends an optimized {@code byte array} value to the stream. As an optimized array, the {@code int8} value type marker and
         * element count are encoded once at the array marker instead of repeating the type marker for each element.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(ReadOnlySpan<byte> values)
        {
            Array();
            writer.Write((byte) '$');
            writer.Write((byte) 'i');
            writer.Write((byte) '#');
            Value(values.Length);
            for (int i = 0, n = values.Length; i < n; i++)
            {
                writer.Write(values[i]);
            }
            Pop(true);
            return this;
        }

        /**
         * Appends an optimized {@code short array} value to the stream. As an optimized array, the {@code int16} value type marker and
         * element count are encoded once at the array marker instead of repeating the type marker for each element.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(ReadOnlySpan<short> values)
        {
            Array();
            writer.Write((byte) '$');
            writer.Write((byte) 'I');
            writer.Write((byte) '#');
            Value(values.Length);
            for (int i = 0, n = values.Length; i < n; i++)
            {
                WriteShort(values[i]);
            }
            Pop(true);
            return this;
        }

        /**
         * Appends an optimized {@code int array} value to the stream. As an optimized array, the {@code int32} value type marker and
         * element count are encoded once at the array marker instead of repeating the type marker for each element.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(ReadOnlySpan<int> values)
        {
            Array();
            writer.Write((byte) '$');
            writer.Write((byte) 'l');
            writer.Write((byte) '#');
            Value(values.Length);
            for (int i = 0, n = values.Length; i < n; i++)
            {
                WriteInt(values[i]);
            }
            Pop(true);
            return this;
        }

        /**
         * Appends an optimized {@code long array} value to the stream. As an optimized array, the {@code int64} value type marker and
         * element count are encoded once at the array marker instead of repeating the type marker for each element.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(ReadOnlySpan<long> values)
        {
            Array();
            writer.Write((byte) '$');
            writer.Write((byte) 'L');
            writer.Write((byte) '#');
            Value(values.Length);
            for (int i = 0, n = values.Length; i < n; i++)
            {
                WriteLong(values[i]);
            }
            Pop(true);
            return this;
        }

        /**
         * Appends an optimized {@code float array} value to the stream. As an optimized array, the {@code float32} value type marker
         * and element count are encoded once at the array marker instead of repeating the type marker for each element.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(ReadOnlySpan<float> values)
        {
            Array();
            writer.Write((byte) '$');
            writer.Write((byte) 'd');
            writer.Write((byte) '#');
            Value(values.Length);
            for (int i = 0, n = values.Length; i < n; i++)
            {
                WriteFloat(values[i]);
            }
            Pop(true);
            return this;
        }

        /**
         * Appends an optimized {@code double array} value to the stream. As an optimized array, the {@code float64} value type marker
         * and element count are encoded once at the array marker instead of repeating the type marker for each element. element count
         * are encoded once at the array marker instead of for each element.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(ReadOnlySpan<double> values)
        {
            Array();
            writer.Write((byte) '$');
            writer.Write((byte) 'D');
            writer.Write((byte) '#');
            Value(values.Length);
            for (int i = 0, n = values.Length; i < n; i++)
            {
                WriteDouble(values[i]);
            }
            Pop(true);
            return this;
        }

        /**
         * Appends a {@code boolean array} value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(ReadOnlySpan<bool> values)
        {
            Array();
            for (int i = 0, n = values.Length; i < n; i++)
            {
                writer.Write(values[i] ? (byte) 'T' : (byte) 'F');
            }
            Pop();
            return this;
        }

        /**
         * Appends an optimized {@code char array} value to the stream. As an optimized array, the {@code int16} value type marker and
         * element count are encoded once at the array marker instead of repeating the type marker for each element.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(ReadOnlySpan<char> values)
        {
            Array();
            writer.Write((byte) '$');
            writer.Write((byte) 'C');
            writer.Write((byte) '#');
            Value(values.Length);
            for (int i = 0, n = values.Length; i < n; i++)
            {
                WriteChar(values[i]);
            }
            Pop(true);
            return this;
        }

        /**
         * Appends an optimized {@code string array} value to the stream. As an optimized array, the {@code string} value type marker
         * and element count are encoded once at the array marker instead of repeating the type marker for each element.
         * @return this writer, for chaining
         */
        public UBJsonWriter Value(ReadOnlySpan<string> values)
        {
            Array();
            writer.Write((byte) '$');
            writer.Write((byte) 'S');
            writer.Write((byte) '#');
            Value(values.Length);
            for (int i = 0, n = values.Length; i < n; i++)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(values[i]);
                if (bytes.Length <= byte.MaxValue)
                {
                    writer.Write((byte) 'i');
                    writer.Write((byte) bytes.Length);
                } else if (bytes.Length <= short.MaxValue)
                {
                    writer.Write((byte) 'I');
                    WriteShort((short) bytes.Length);
                } else
                {
                    writer.Write((byte) 'l');
                    WriteInt(bytes.Length);
                }
                writer.Write(bytes);
            }
            Pop(true);
            return this;
        }
        public UBJsonWriter Value(object? value) => value switch
        {
            null => NullValue(),
            byte val => Value(val),
            short val => Value(val),
            int val => Value(val),
            long val => Value(val),
            float val => Value(val),
            double val => Value(val),
            char val => Value(val),
            IEnumerable<char> val => Value(new string([.. val])),
            _ => throw new InvalidOperationException("Unknown object type"),
        };
        public UBJsonWriter NullValue()
        {
            CheckName();
            writer.Write((byte) 'Z');
            return this;
        }
        #endregion

        public void SetOutputType(OutputType outputType)
        {
            // irrelevant
        }
        public void SetQuoteLongValues(bool quoteLongValues)
        {
            // irrelevant
        }

        #region Set
        /**
         * Appends a named value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, object? value) => Name(name).Value(value);


        /**
         * Appends a named {@code byte} value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, byte value) => Name(name).Value(value);

        /**
         * Appends a named {@code short} value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, short value) => Name(name).Value(value);

        /**
         * Appends a named {@code int} value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, int value) => Name(name).Value(value);

        /**
         * Appends a named {@code long} value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, long value) => Name(name).Value(value);

        /**
         * Appends a named {@code float} value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, float value) => Name(name).Value(value);

        /**
         * Appends a named {@code double} value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, double value) => Name(name).Value(value);

        /**
         * Appends a named {@code boolean} value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, bool value) => Name(name).Value(value);

        /**
         * Appends a named {@code char} value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, char value) => Name(name).Value(value);

        /**
         * Appends a named {@code string} value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, string value) => Name(name).Value(value);

        /**
         * Appends a named {@code byte} array value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, ReadOnlySpan<byte> value) => Name(name).Value(value);

        /**
         * Appends a named {@code short} array value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, ReadOnlySpan<short> value) => Name(name).Value(value);

        /**
         * Appends a named {@code int} array value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, ReadOnlySpan<int> value) => Name(name).Value(value);

        /**
         * Appends a named {@code long} array value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, ReadOnlySpan<long> value) => Name(name).Value(value);

        /**
         * Appends a named {@code float} array value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, ReadOnlySpan<float> value) => Name(name).Value(value);

        /**
         * Appends a named {@code double} array value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, ReadOnlySpan<double> value) => Name(name).Value(value);

        /**
         * Appends a named {@code boolean} array value to the stream.
         * @return this writer, for chaining
         */
        public UBJsonWriter Set(string name, ReadOnlySpan<bool> value) => Name(name).Value(value);

        public UBJsonWriter Set(string name, ReadOnlySpan<char> value) => Name(name).Value(value);

        public UBJsonWriter Set(string name, ReadOnlySpan<string> value) => Name(name).Value(value);

        public UBJsonWriter SetNull(string name) => Name(name).NullValue();
        #endregion

        private void CheckName()
        {
            if (current is not null)
            {
                if (!current.array)
                {
                    if (!named)
                    {
                        throw new InvalidOperationException("Name must be set.");
                    }
                    named = false;
                }
            }
        }

        /// <summary>
        /// Ends the current object or array and pops it off of the element stack.
        /// </summary>
        /// <returns></returns>
        public UBJsonWriter Pop() => Pop(false);

        protected UBJsonWriter Pop(bool silent)
        {
            if (named)
            {
                throw new InvalidOperationException("Expected an object, array, or value since a name was set.");
            }
            if (silent)
            {
                stack.Pop();
            } else
            {
                stack.Pop().Close(writer);
            }
            current = stack.Count == 0 ? null : stack.Peek();
            return this;
        }

        public void Flush() => writer.Flush();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            while (stack.Count > 0)
            {
                Pop();
            }
            writer.Dispose();
        }

        void WriteShort(short value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(short)];
            BinaryPrimitives.WriteInt16BigEndian(buffer, value);
            writer.Write(buffer);
        }
        void WriteChar(char value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(ushort)];
            BinaryPrimitives.WriteUInt16BigEndian(buffer, value);
            writer.Write(buffer);
        }
        void WriteInt(int value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(int)];
            BinaryPrimitives.WriteInt32BigEndian(buffer, value);
            writer.Write(buffer);
        }
        void WriteLong(long value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(long)];
            BinaryPrimitives.WriteInt64BigEndian(buffer, value);
            writer.Write(buffer);
        }
        void WriteFloat(float value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(float)];
            BinaryPrimitives.WriteSingleBigEndian(buffer, value);
            writer.Write(buffer);
        }
        void WriteDouble(double value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(double)];
            BinaryPrimitives.WriteDoubleBigEndian(buffer, value);
            writer.Write(buffer);
        }

        private class JsonObject
        {
            public bool array;

            public JsonObject(bool array, BinaryWriter writer)
            {
                this.array = array;
                writer.Write(array ? (byte) '[' : (byte) '{');
            }

            public void Close(BinaryWriter writer)
            {
                writer.Write(array ? (byte) ']' : (byte) '}');
            }
        }
    }
}
