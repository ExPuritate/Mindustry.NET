using Arc.Files;
using System.Buffers.Binary;
using System.Text;

namespace Arc.Utility.Serialization
{
    /// <summary>
    /// Lightweight UBJSON parser.
    /// 
    /// <para>
    /// The default behavior is to parse the JSON into a DOM containing <see cref="JsonValue"/> objects. Extend this class and override
    /// methods to perform event driven parsing.When this is done, the parse methods will return null.
    /// </para>
    /// </summary>
    /// 
    /// <remarks>
    /// It does not seem to be very standard, see code below
    /// </remarks>
    public class UBJsonReader: IBaseJsonReader
    {
        public JsonValue Parse(Stream input)
        {
            using Stream stream = input;
            BinaryReader reader = new(stream);
            return Parse(reader);
        }

        public JsonValue Parse(Fi file) => Parse(file.Read(8192));

        public JsonValue Parse(BinaryReader reader)
        {
            using BinaryReader reader1 = reader;
            return Parse(reader1, reader1.ReadByte());
        }

        public JsonValue ParseWithoutClosing(BinaryReader reader) => Parse(reader, reader.ReadByte());

        protected JsonValue Parse(BinaryReader reader, byte type) => type switch
        {
            (byte) '[' => ParseArray(reader),
            (byte) '{' => ParseObject(reader),
            (byte) 'Z' => new(JsonValueType.NullValue),
            (byte) 'T' => new(true),
            (byte) 'F' => new(false),
            // B is not standard
            (byte) 'B' or (byte) 'U' => new(ReadUChar(reader)),
            (byte) 'i' => new((sbyte) reader.ReadByte()),
            (byte) 'I' => new(ReadShort(reader)),
            (byte) 'l' => new(ReadInt(reader)),
            (byte) 'L' => new(ReadLong(reader)),
            (byte) 'd' => new(reader.ReadSingle()),
            (byte) 'D' => new(reader.ReadDouble()),
            // s is not standard
            (byte) 's' or (byte) 'S' => new(ParseString(reader, type)),
            (byte) 'a' or (byte) 'A' => ParseData(reader, type),
            (byte) 'C' => new(ReadChar(reader)),
            _ => throw new InvalidDataException("Unrecognized data type"),
        };

        protected JsonValue ParseArray(BinaryReader reader)
        {
            JsonValue result = new(JsonValueType.ArrayValue);
            byte type = reader.ReadByte();
            byte valueType = 0;
            if (type == (byte) '$')
            {
                valueType = reader.ReadByte();
                type = reader.ReadByte();
            }
            long size = -1;
            if (type == (byte) '#')
            {
                size = ParseSize(reader, false, -1);
                if (size < 0)
                {
                    throw new InvalidDataException("Unrecognized data type");
                }
                if (size == 0)
                {
                    return result;
                }
                type = valueType == 0 ? reader.ReadByte() : valueType;
            }
            JsonValue? prev = null;
            long c = 0;
            while (reader.BaseStream.Length > reader.BaseStream.Position && type != (byte) ']')
            {
                JsonValue val = Parse(reader, type);
                val.parent = result;
                if (prev is not null)
                {
                    val.prev = prev;
                    prev.next = val;
                    result.size++;
                } else
                {
                    result.child = val;
                    result.size = 1;
                }
                prev = val;
                if (size > 0 && ++c >= size)
                {
                    break;
                }
                type = valueType == 0 ? reader.ReadByte() : valueType;
            }
            return result;
        }

        protected JsonValue ParseObject(BinaryReader reader)
        {
            JsonValue result = new(JsonValueType.ObjectValue);
            byte type = reader.ReadByte();
            byte valueType = 0;
            if (type == (byte) '$')
            {
                valueType = reader.ReadByte();
                type = reader.ReadByte();
            }
            long size = -1;
            if (type == (byte) '#')
            {
                size = ParseSize(reader, false, -1);
                if (size < 0)
                {
                    throw new InvalidDataException("Unrecognized data type");
                }
                if (size == 0)
                {
                    return result;
                }
                type = reader.ReadByte();
            }
            JsonValue? prev = null;
            long c = 0;
            while (reader.BaseStream.Length > reader.BaseStream.Position && type != (byte) '}')
            {
                string key = ParseString(reader, true, type);
                JsonValue child = Parse(reader, valueType == 0 ? reader.ReadByte() : valueType);
                child.Name = key;
                child.parent = result;
                if (prev is not null)
                {
                    child.Prev = prev;
                    prev.next = child;
                    result.size++;
                } else
                {
                    result.child = child;
                    result.size = 1;
                }
                prev = child;
                if (size > 0 && ++c >= size)
                {
                    break;
                }
                type = reader.ReadByte();
            }
            return result;
        }

        protected JsonValue ParseData(BinaryReader reader, byte blockType)
        {
            // FIXME: a/A is currently not following the specs because it lacks strong typed, fixed sized containers,
            // see: https://github.com/thebuzzmedia/universal-binary-json/issues/27
            byte dataType = reader.ReadByte();
            long size = blockType == (byte) 'A' ? ReadUInt(reader) : ReadUChar(reader);
            JsonValue result = new(JsonValueType.ArrayValue);
            JsonValue? prev = null;
            for (long i = 0; i < size; i++)
            {
                JsonValue val = Parse(reader, dataType);
                val.parent = result;
                if (prev is not null)
                {
                    prev.next = val;
                    result.size++;
                } else
                {
                    result.child = val;
                    result.size = 1;
                }
                prev = val;
            }
            return result;
        }

        protected string ParseString(BinaryReader reader, byte type) => ParseString(reader, false, type);

        protected string ParseString(BinaryReader reader, bool sOptional, byte type)
        {
            long size = -1;
            if (type == (byte) 'S')
            {
                size = ParseSize(reader, true, -1);
            } else if (type == (byte) 's')
            {
                size = ReadUChar(reader);
            } else if (sOptional)
            {
                size = ParseSize(reader, type, false, -1);
            }
            return size < 0 ? throw new InvalidDataException("Unrecognized data type, string expected") : ReadString(reader, size);
        }

        protected long ParseSize(BinaryReader reader, bool useIntOnError, long defaultValue) =>
            ParseSize(reader, reader.ReadByte(), useIntOnError, defaultValue);

        protected long ParseSize(BinaryReader reader, byte type, bool useIntOnError, long defaultValue)
        {
            if (type == 'i')
            {
                return ReadUChar(reader);
            }
            if (type == 'I')
            {
                return ReadUShort(reader);
            }
            if (type == 'l')
            {
                return ReadUInt(reader);
            }
            if (type == 'L')
            {
                return ReadLong(reader);
            }

            if (useIntOnError)
            {
                long result = (long) type << 24;
                result |= (long) reader.ReadByte() << 16;
                result |= (long) reader.ReadByte() << 8;
                result |= reader.ReadByte();
                return result;
            }
            return defaultValue;
        }

        protected char ReadChar(BinaryReader reader)
        {
            Span<byte> buffer = stackalloc byte[sizeof(char)];
            reader.ReadExactly(buffer);
            return (char) BinaryPrimitives.ReadUInt16BigEndian(buffer);
        }
        protected byte ReadUChar(BinaryReader reader) => reader.ReadByte();
        protected short ReadShort(BinaryReader reader)
        {
            Span<byte> buffer = stackalloc byte[sizeof(short)];
            reader.ReadExactly(buffer);
            return BinaryPrimitives.ReadInt16BigEndian(buffer);
        }
        protected ushort ReadUShort(BinaryReader reader)
        {
            Span<byte> buffer = stackalloc byte[sizeof(ushort)];
            reader.ReadExactly(buffer);
            return BinaryPrimitives.ReadUInt16BigEndian(buffer);
        }
        protected int ReadInt(BinaryReader reader)
        {
            Span<byte> buffer = stackalloc byte[sizeof(int)];
            reader.ReadExactly(buffer);
            return BinaryPrimitives.ReadInt32BigEndian(buffer);
        }
        protected uint ReadUInt(BinaryReader reader)
        {
            Span<byte> buffer = stackalloc byte[sizeof(uint)];
            reader.ReadExactly(buffer);
            return BinaryPrimitives.ReadUInt32BigEndian(buffer);
        }
        protected long ReadLong(BinaryReader reader)
        {
            Span<byte> buffer = stackalloc byte[sizeof(long)];
            reader.ReadExactly(buffer);
            return BinaryPrimitives.ReadInt64BigEndian(buffer);
        }
        protected string ReadString(BinaryReader reader, long size)
        {
            Span<byte> data = stackalloc byte[(int) size];
            reader.ReadExactly(data);
            return Encoding.UTF8.GetString(data);
        }
    }
}
