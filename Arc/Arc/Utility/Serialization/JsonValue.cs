using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;

namespace Arc.Utility.Serialization
{
    /// <summary>
    /// Container for a JSON object, array, string, double, long, Boolean, or null.
    /// <para>
    /// JsonValue children are a linked list. Iteration of arrays or objects is easily done using a for loop, either with the enhanced
    /// for loop syntactic sugar or like the example below. This is much more efficient than accessing children by index when there are
    /// many children.
    /// </para>
    /// 
    /// <code>
    /// JsonValue map = ...;
    /// for (JsonValue entry = map.child; entry != null; entry = entry.next)
    /// 	System.out.println(entry.name + " = " + entry.asString());
    /// </code>
    /// </summary>
    public class JsonValue: IEnumerable<JsonValue>
    {
        public string? name;
        public JsonValue? child, next, prev, parent;
        public int size;
        private JsonValueType type;
        private string? stringValue;
        private double doubleValue;
        private long longValue;

        public JsonValue(JsonValueType type)
        {
            this.type = type;
        }

        public JsonValue(string? value)
        {
            Set(value);
        }

        public JsonValue(double value)
        {
            Set(value, null);
        }

        public JsonValue(long value)
        {
            Set(value, null);
        }

        public JsonValue(double value, string stringValue)
        {
            Set(value, stringValue);
        }

        public JsonValue(long value, string stringValue)
        {
            Set(value, stringValue);
        }

        public JsonValue(bool value)
        {
            Set(value);
        }

        public JsonValue(JsonDocument document) : this(document.RootElement)
        {
        }

        public JsonValue(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Undefined:
                    throw new InvalidDataException();
                case JsonValueKind.Object:
                    this.type = JsonValueType.ObjectValue;
                    foreach (JsonProperty child in element.EnumerateObject())
                    {
                        this.AddChild(child.Name, new(child.Value));
                    }
                    break;
                case JsonValueKind.Array:
                    this.type = JsonValueType.ArrayValue;
                    foreach (JsonElement child in element.EnumerateArray())
                    {
                        this.AddChild(new(child));
                    }
                    break;
                case JsonValueKind.String:
                    Set(element.GetString());
                    break;
                case JsonValueKind.Number:
                    if (element.TryGetInt64(out long lVal))
                    {
                        Set(lVal, null);
                    } else
                    {
                        double val = element.GetDouble();
                        Set(val, null);
                    }
                    break;
                case JsonValueKind.True:
                    longValue = 1;
                    type = JsonValueType.BooleanValue;
                    break;
                case JsonValueKind.False:
                    longValue = 0;
                    type = JsonValueType.BooleanValue;
                    break;
                case JsonValueKind.Null:
                    stringValue = null;
                    type = JsonValueType.NullValue;
                    break;
            }
        }

        private static bool IsFlat(JsonValue @object)
        {
            for (JsonValue? child = @object.child; child != null; child = child.next)
            {
                if (child.IsObject() || child.IsArray())
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsNumeric(JsonValue @object)
        {
            for (JsonValue? child = @object.child; child != null; child = child.next)
            {
                if (!child.IsNumber())
                {
                    return false;
                }
            }

            return true;
        }

        private static void Indent(int count, StringBuilder buffer)
        {
            for (int i = 0; i < count; i++)
            {
                buffer.Append('\t');
            }
        }

        private static void Indent(int count, TextWriter buffer)
        {
            for (int i = 0; i < count; i++)
            {
                buffer.Write('\t');
            }
        }

        /**
         * Returns the child at the specified index. This requires walking the linked list to the specified entry, see
         * {@link JsonValue} for how to iterate efficiently.
         * @return May be null.
         */
        public JsonValue? Get(int index)
        {
            JsonValue? current = child;
            while (current != null && index > 0)
            {
                index--;
                current = current.next;
            }
            return current;
        }

        /**
         * Returns the child with the specified name.
         * @return May be null.
         */
        public JsonValue? Get(string name)
        {
            JsonValue? current = child;
            while (
                current != null
                && (
                    current.name == null
                    || current.name.CompareTo(name, StringComparison.OrdinalIgnoreCase) != 0))
            {
                current = current.next;
            }

            return current;
        }

        /** Returns true if a child with the specified name exists. */
        public bool Has(string name) => Get(name) != null;

        /**
         * Returns the child at the specified index. This requires walking the linked list to the specified entry, see
         * {@link JsonValue} for how to iterate efficiently.
         * @throws InvalidDataException if the child was not found.
         */
        public JsonValue Require(int index)
        {
            JsonValue? current = child;
            while (current != null && index > 0)
            {
                index--;
                current = current.next;
            }
            return current ?? throw new InvalidDataException("Child not found with index: " + index);
        }

        /**
         * Returns the child with the specified name.
         * @throws InvalidDataException if the child was not found.
         */
        public JsonValue Require(string name)
        {
            JsonValue? current = child;
            while (
                current != null
                && (
                    current.name == null
                    || current.name.CompareTo(name, StringComparison.OrdinalIgnoreCase) != 0))
            {
                current = current.next;
            }

            return current ?? throw new InvalidDataException("Child not found with name: " + name);
        }

        /// <summary>
        /// Removes the child with the specified index. This requires walking the linked list to the specified entry, see
        /// <see cref="JsonValue" /> for how to iterate efficiently.
        /// </summary>
        public JsonValue? Remove(int index)
        {
            JsonValue? child = Get(index);
            if (child == null)
            {
                return null;
            }

            if (child.prev == null)
            {
                this.child = child.next;
                this.child?.prev = null;
            } else
            {
                child.prev.next = child.next;
                child.next?.prev = child.prev;
            }
            size--;
            return child;
        }

        /// <summary>
        /// Removes the child with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public JsonValue? Remove(string name)
        {
            JsonValue? child = Get(name);
            if (child == null)
            {
                return null;
            }

            if (child.prev == null)
            {
                this.child = child.next;
                this.child?.prev = null;
            } else
            {
                child.prev.next = child.next;
                child.next?.prev = child.prev;
            }
            size--;
            return child;
        }

        /// <summary>
        /// Returns this value as a <see cref="string"/>.
        /// </summary>
        /// <exception cref="InvalidDataException">if this an array or object.</exception>
        public string? AsString() => type switch
        {
            JsonValueType.StringValue => stringValue,
            JsonValueType.DoubleValue => stringValue ?? doubleValue.ToString(),
            JsonValueType.LongValue => stringValue ?? longValue.ToString(),
            JsonValueType.BooleanValue => longValue != 0 ? "true" : "false",
            JsonValueType.NullValue => null,
            _ => throw TypeMismatch("string"),
        };

        /// <summary>
        /// Returns this value as a <see cref="float"/>.
        /// </summary>
        /// <exception cref="InvalidDataException">if this an array or object.</exception>
        public float AsFloat() => type switch
        {
            JsonValueType.StringValue => float.Parse(stringValue!),
            JsonValueType.DoubleValue => (float) doubleValue,
            JsonValueType.LongValue => longValue,
            JsonValueType.BooleanValue => longValue != 0 ? 1 : 0,
            _ => throw TypeMismatch("float"),
        };

        /// <summary>
        /// Returns this value as a <see cref="double"/>.
        /// </summary>
        /// <exception cref="InvalidDataException">if this an array or object.</exception>
        public double AsDouble() => type switch
        {
            JsonValueType.StringValue => double.Parse(stringValue!),
            JsonValueType.DoubleValue => doubleValue,
            JsonValueType.LongValue => longValue,
            JsonValueType.BooleanValue => longValue != 0 ? 1 : 0,
            _ => throw TypeMismatch("double"),
        };

        /// <summary>
        /// Returns this value as a <see cref="long"/>.
        /// </summary>
        /// <exception cref="InvalidDataException">if this an array or object.</exception>
        public long AsLong() => type switch
        {
            JsonValueType.StringValue => long.Parse(stringValue!),
            JsonValueType.DoubleValue => (long) doubleValue,
            JsonValueType.LongValue => longValue,
            JsonValueType.BooleanValue => longValue != 0 ? 1 : 0,
            _ => throw TypeMismatch("long"),
        };

        /// <summary>
        /// Returns this value as a <see cref="int"/>.
        /// </summary>
        /// <exception cref="InvalidDataException">if this an array or object.</exception>
        public int AsInt() => type switch
        {
            JsonValueType.StringValue => int.Parse(stringValue!),
            JsonValueType.DoubleValue => (int) doubleValue,
            JsonValueType.LongValue => (int) longValue,
            JsonValueType.BooleanValue => longValue != 0 ? 1 : 0,
            _ => throw TypeMismatch("int"),
        };

        /// <summary>
        /// Returns this value as a <see cref="bool"/>.
        /// </summary>
        /// <exception cref="InvalidDataException">if this an array or object.</exception>
        public bool AsBoolean() => type switch
        {
            JsonValueType.StringValue => bool.Parse(stringValue!),
            JsonValueType.DoubleValue => doubleValue != 0,
            JsonValueType.LongValue => longValue != 0,
            JsonValueType.BooleanValue => longValue != 0,
            _ => throw TypeMismatch("Boolean"),
        };

        /// <summary>
        /// Returns this value as a <see cref="byte"/>.
        /// </summary>
        /// <exception cref="InvalidDataException">if this an array or object.</exception>
        public byte AsByte() => type switch
        {
            JsonValueType.StringValue => byte.Parse(stringValue!),
            JsonValueType.DoubleValue => (byte) doubleValue,
            JsonValueType.LongValue => (byte) longValue,
            JsonValueType.BooleanValue => (byte) (longValue != 0 ? 1 : 0),
            _ => throw TypeMismatch("byte"),
        };

        /// <summary>
        /// Returns this value as a <see cref="short"/>.
        /// </summary>
        /// <exception cref="InvalidDataException">if this an array or object.</exception>
        public short AsShort() => type switch
        {
            JsonValueType.StringValue => short.Parse(stringValue!),
            JsonValueType.DoubleValue => (short) doubleValue,
            JsonValueType.LongValue => (short) longValue,
            JsonValueType.BooleanValue => (short) (longValue != 0 ? 1 : 0),
            _ => throw TypeMismatch("short"),
        };

        /// <summary>
        /// Returns this value as a <see cref="char"/>.
        /// </summary>
        /// <exception cref="InvalidDataException">if this an array or object.</exception>
        public char AsChar() => type switch
        {
            JsonValueType.StringValue => stringValue!.Length == 0 ? '\0' : stringValue[0],
            JsonValueType.DoubleValue => (char) doubleValue,
            JsonValueType.LongValue => (char) longValue,
            JsonValueType.BooleanValue => longValue != 0 ? (char) 1 : '\0',
            _ => throw TypeMismatch("char"),
        };

        /// <summary>
        /// Returns the children of this value as a newly allocated <typeparamref name="T"/> array.
        /// </summary>
        /// <exception cref="InvalidDataException">if this is not an array.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private T[] ToArrayGeneric<T>(Func<JsonValue, T> factory)
        {
            if (type != JsonValueType.ArrayValue)
            {
                throw new InvalidDataException("Value is not an array: " + type);
            }

            T[] array = new T[size];
            int i = 0;
            for (JsonValue? value = child; value != null; value = value.next, i++)
            {
                array[i] = factory(value);
            }
            return array;
        }

        /// <summary>
        /// Returns the children of this value as a newly allocated <see cref="string"/> array.
        /// </summary>
        /// <exception cref="InvalidDataException">if this is not an array.</exception>
        public string?[] ToStringArray() => ToArrayGeneric(value => value.AsString());

        /// <summary>
        /// Returns the children of this value as a newly allocated <see cref="float"/> array.
        /// </summary>
        /// <exception cref="InvalidDataException">if this is not an array.</exception>
        public float[] ToFloatArray() => ToArrayGeneric(value => value.AsFloat());

        /// <summary>
        /// Returns the children of this value as a newly allocated <see cref="double"/> array.
        /// </summary>
        /// <exception cref="InvalidDataException">if this is not an array.</exception>
        public double[] ToDoubleArray() => ToArrayGeneric(value => value.AsDouble());

        /// <summary>
        /// Returns the children of this value as a newly allocated <see cref="long"/> array.
        /// </summary>
        /// <exception cref="InvalidDataException">if this is not an array.</exception>
        public long[] ToLongArray() => ToArrayGeneric(value => value.AsLong());

        /// <summary>
        /// Returns the children of this value as a newly allocated <see cref="int"/> array.
        /// </summary>
        /// <exception cref="InvalidDataException">if this is not an array.</exception>
        public int[] ToIntArray() => ToArrayGeneric(value => value.AsInt());

        /// <summary>
        /// Returns the children of this value as a newly allocated <see cref="bool"/> array.
        /// </summary>
        /// <exception cref="InvalidDataException">if this is not an array.</exception>
        public bool[] ToBooleanArray() => ToArrayGeneric(value => value.AsBoolean());

        /// <summary>
        /// Returns the children of this value as a newly allocated <see cref="byte"/> array.
        /// </summary>
        /// <exception cref="InvalidDataException">if this is not an array.</exception>
        public byte[] ToByteArray() => ToArrayGeneric(value => value.AsByte());

        /// <summary>
        /// Returns the children of this value as a newly allocated <see cref="short"/> array.
        /// </summary>
        /// <exception cref="InvalidDataException">if this is not an array.</exception>
        public short[] ToShortArray() => ToArrayGeneric(value => value.AsShort());

        private void Mismatch(string type) => throw TypeMismatch(type);

        private InvalidDataException TypeMismatch(string type) =>
            new("\"" + (name ?? "value") + "\" should be a " + type + ", but it is a " + this.type + ".");

        /// <summary>
        /// Returns the children of this value as a newly allocated <see cref="char"/> array.
        /// </summary>
        /// <exception cref="InvalidDataException">if this is not an array.</exception>
        public char[] ToCharArray() => ToArrayGeneric(value => value.AsChar());

        /// <summary>
        /// Returns true if a child with the specified name exists and has a child.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool HasChild(string name) => GetChild(name) is not null;

        /// <summary>
        /// Finds the child with the specified name and returns its first child.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public JsonValue? GetChild(string name)
        {
            JsonValue? child = Get(name);
            return child?.child;
        }

        /// <summary>
        /// Finds the child with the specified name and returns it as a <typeparamref name="T"/>. Returns <paramref name="defaultValue"/> if not found.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private T GenericGet<T>(string name, T defaultValue, Func<JsonValue, T> factory)
        {
            JsonValue? child = Get(name);
            return (child == null || !child.IsValue() || child.IsNull()) ? defaultValue : factory(child);
        }

        /// <inheritdoc cref="GenericGet{T}(string, T, Func{JsonValue, T})"/>
        public string GetString(string name, string defaultValue) =>
            GenericGet(name, defaultValue, child => child.AsString() ?? throw new NullReferenceException());

        /// <inheritdoc cref="GenericGet{T}(string, T, Func{JsonValue, T})"/>
        public float GetFloat(string name, float defaultValue) =>
            GenericGet(name, defaultValue, child => child.AsFloat());

        /// <inheritdoc cref="GenericGet{T}(string, T, Func{JsonValue, T})"/>
        public double GetDouble(string name, double defaultValue) =>
            GenericGet(name, defaultValue, child => child.AsDouble());

        /// <inheritdoc cref="GenericGet{T}(string, T, Func{JsonValue, T})"/>
        public long GetLong(string name, long defaultValue) =>
            GenericGet(name, defaultValue, child => child.AsLong());

        /// <inheritdoc cref="GenericGet{T}(string, T, Func{JsonValue, T})"/>
        public int GetInt(string name, int defaultValue) =>
            GenericGet(name, defaultValue, child => child.AsInt());

        /// <inheritdoc cref="GenericGet{T}(string, T, Func{JsonValue, T})"/>
        public bool GetBoolean(string name, bool defaultValue) =>
            GenericGet(name, defaultValue, child => child.AsBoolean());

        /// <inheritdoc cref="GenericGet{T}(string, T, Func{JsonValue, T})"/>
        public byte GetByte(string name, byte defaultValue) =>
            GenericGet(name, defaultValue, child => child.AsByte());

        /// <inheritdoc cref="GenericGet{T}(string, T, Func{JsonValue, T})"/>
        public short GetShort(string name, short defaultValue) =>
            GenericGet(name, defaultValue, child => child.AsShort());

        /// <inheritdoc cref="GenericGet{T}(string, T, Func{JsonValue, T})"/>
        public char GetChar(string name, char defaultValue) =>
            GenericGet(name, defaultValue, child => child.AsChar());

        /// <summary>
        /// Finds the child with the specified name and returns it as a <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException">if the child was not found.</exception>
        private T GenericGet<T>(string name, Func<JsonValue, T> factory) => factory(
            Get(name) ?? throw new InvalidDataException("Named value not found: " + name));

        /// <inheritdoc cref="GenericGet{T}(string, Func{JsonValue, T})"/>
        public string GetString(string name) => GenericGet(name, child => child.AsString() ?? throw new NullReferenceException());

        /// <inheritdoc cref="GenericGet{T}(string, Func{JsonValue, T})"/>
        public float GetFloat(string name) => GenericGet(name, child => child.AsFloat());

        /// <inheritdoc cref="GenericGet{T}(string, Func{JsonValue, T})"/>
        public double GetDouble(string name) => GenericGet(name, child => child.AsDouble());

        /// <inheritdoc cref="GenericGet{T}(string, Func{JsonValue, T})"/>
        public long GetLong(string name) => GenericGet(name, child => child.AsLong());

        /// <inheritdoc cref="GenericGet{T}(string, Func{JsonValue, T})"/>
        public int GetInt(string name) => GenericGet(name, child => child.AsInt());

        /// <inheritdoc cref="GenericGet{T}(string, Func{JsonValue, T})"/>
        public bool GetBoolean(string name) => GenericGet(name, child => child.AsBoolean());

        /// <inheritdoc cref="GenericGet{T}(string, Func{JsonValue, T})"/>
        public byte GetByte(string name) => GenericGet(name, child => child.AsByte());

        /// <inheritdoc cref="GenericGet{T}(string, Func{JsonValue, T})"/>
        public short GetShort(string name) => GenericGet(name, child => child.AsShort());

        /// <inheritdoc cref="GenericGet{T}(string, Func{JsonValue, T})"/>
        public char GetChar(string name) => GenericGet(name, child => child.AsChar());

        /// <summary>
        /// Finds the child with the specified <paramref name="index"/> and returns it as a <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <param name="factory">if the child was not found.</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        private T GenericGet<T>(int index, Func<JsonValue, T> factory) => factory(
            Get(index) ?? throw new InvalidDataException("Indexed value not found: " + name));

        /// <inheritdoc cref="GenericGet{T}(int, Func{JsonValue, T})"/>
        public string GetString(int index) => GenericGet(index, child => child.AsString() ?? throw new NullReferenceException());

        /// <inheritdoc cref="GenericGet{T}(int, Func{JsonValue, T})"/>
        public float GetFloat(int index) => GenericGet(index, child => child.AsFloat());

        /// <inheritdoc cref="GenericGet{T}(int, Func{JsonValue, T})"/>
        public double GetDouble(int index) => GenericGet(index, child => child.AsDouble());

        /// <inheritdoc cref="GenericGet{T}(int, Func{JsonValue, T})"/>
        public long GetLong(int index) => GenericGet(index, child => child.AsLong());

        /// <inheritdoc cref="GenericGet{T}(int, Func{JsonValue, T})"/>
        public int GetInt(int index) => GenericGet(index, child => child.AsInt());

        /// <inheritdoc cref="GenericGet{T}(int, Func{JsonValue, T})"/>
        public bool GetBoolean(int index) => GenericGet(index, child => child.AsBoolean());

        /// <inheritdoc cref="GenericGet{T}(int, Func{JsonValue, T})"/>
        public byte GetByte(int index) => GenericGet(index, child => child.AsByte());

        /// <inheritdoc cref="GenericGet{T}(int, Func{JsonValue, T})"/>
        public short GetShort(int index) => GenericGet(index, child => child.AsShort());

        /// <inheritdoc cref="GenericGet{T}(int, Func{JsonValue, T})"/>
        public char GetChar(int index) => GenericGet(index, child => child.AsChar());

        public JsonValueType Type
        {
            get => type;
            set => type = value;
        }

        public bool IsArray() => type == JsonValueType.ArrayValue;

        public bool IsObject() => type == JsonValueType.ObjectValue;

        public bool IsString() => type == JsonValueType.StringValue;

        /** Returns true if this is a double or long value. */
        public bool IsNumber() => type is JsonValueType.DoubleValue or JsonValueType.LongValue;

        public bool IsDouble() => type == JsonValueType.DoubleValue;

        public bool IsLong() => type == JsonValueType.LongValue;

        public bool IsBoolean() => type == JsonValueType.BooleanValue;

        public bool IsNull() => type == JsonValueType.NullValue;

        /// <summary>
        /// </summary>
        /// 
        /// <returns>true if this is not an array or object.</returns>
        public bool IsValue() => type switch
        {
            JsonValueType.ArrayValue or JsonValueType.ObjectValue => false,
            _ => true,
        };

        public string? Name
        {
            get => name;
            set => name = value;
        }

        public JsonValue? Parent => parent;

        public JsonValue? Child => child;

        /** Sets the name of the specified value and adds it after the last child. */
        public void AddChild(string name, JsonValue value)
        {
            value.name = name;
            AddChild(value);
        }

        /** Adds the specified value after the last child. */
        public void AddChild(JsonValue value)
        {
            value.parent = this;
            JsonValue? current = child;
            if (current == null)
            {
                child = value;
            } else
            {
                while (true)
                {
                    if (current.next == null)
                    {
                        current.next = value;
                        value.prev = current;
                        return;
                    }
                    current = current.next;
                }
            }
        }

        /**
         * Returns the next sibling of this value.
         */
        public JsonValue? Next() => next;

        public void SetNext(JsonValue next) => this.next = next;

        public JsonValue? Prev
        {
            get => prev;
            set => prev = value;
        }

        public void Set(string? value)
        {
            stringValue = value;
            type = value == null ? JsonValueType.NullValue : JsonValueType.StringValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="stringValue">be null if the string representation is the string value of the <see cref="double"/> (eg, no leading zeros).</param>
        public void Set(double value, string? stringValue)
        {
            doubleValue = value;
            longValue = (long) value;
            this.stringValue = stringValue;
            type = JsonValueType.DoubleValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="stringValue">be null if the string representation is the string value of the <see cref="long"/> (eg, no leading zeros).</param>
        public void Set(long value, string? stringValue)
        {
            longValue = value;
            doubleValue = (double) value;
            this.stringValue = stringValue;
            type = JsonValueType.LongValue;
        }

        public void Set(bool value)
        {
            longValue = value ? 1 : 0;
            type = JsonValueType.BooleanValue;
        }

        public string ToJson(OutputType outputType)
        {
            if (IsValue())
            {
                return AsString() ?? throw new NullReferenceException();
            }

            StringBuilder buffer = new(512);
            Json(this, buffer, outputType);
            return buffer.ToString();
        }

        private void Json(JsonValue @object, StringBuilder buffer, OutputType outputType)
        {
            if (@object.IsObject())
            {
                if (@object.child == null)
                {
                    buffer.Append("{}");
                } else
                {
                    int start = buffer.Length;
                    while (true)
                    {
                        buffer.Append('{');
                        for (JsonValue? child = @object.child; child != null; child = child.next)
                        {
                            buffer.Append(outputType.QuoteName(child.name ?? throw new NullReferenceException()));
                            buffer.Append(':');
                            Json(child, buffer, outputType);
                            if (child.next != null)
                            {
                                buffer.Append(',');
                            }
                        }
                        break;
                    }
                    buffer.Append('}');
                }
            } else if (@object.IsArray())
            {
                if (@object.child == null)
                {
                    buffer.Append("[]");
                } else
                {
                    int start = buffer.Length;
                    while (true)
                    {
                        buffer.Append('[');
                        for (JsonValue? child = @object.child; child != null; child = child.next)
                        {
                            Json(child, buffer, outputType);
                            if (child.next != null)
                            {
                                buffer.Append(',');
                            }
                        }
                        break;
                    }
                    buffer.Append(']');
                }
            } else if (@object.IsString())
            {
                buffer.Append(outputType.QuoteValue(@object.AsString()));
            } else if (@object.IsDouble())
            {
                double doubleValue = @object.AsDouble();
                long longValue = @object.AsLong();
                buffer.Append(doubleValue);
            } else if (@object.IsLong())
            {
                buffer.Append(@object.AsLong());
            } else if (@object.IsBoolean())
            {
                buffer.Append(@object.AsBoolean());
            } else if (@object.IsNull())
            {
                buffer.Append("null");
            } else
            {
                throw new SerializationException("Unknown object type: " + @object);
            }
        }

        public override string ToString() => IsValue()
                ? name == null ? (AsString() ?? throw new NullReferenceException()) : name + ": " + AsString()
                : (name == null ? "" : name + ": ") + PrettyPrint(OutputType.Minimal, 0);

        public string PrettyPrint(OutputType outputType, int singleLineColumns)
        {
            PrettyPrintSettings settings = new()
            {
                outputType = outputType,
                singleLineColumns = singleLineColumns
            };
            return PrettyPrint(settings);
        }

        public string PrettyPrint(PrettyPrintSettings settings)
        {
            StringBuilder buffer = new(512);
            PrettyPrint(this, buffer, 0, settings);
            return buffer.ToString();
        }

        private void PrettyPrint(JsonValue @object, StringBuilder buffer, int indent, PrettyPrintSettings settings)
        {
            OutputType outputType = settings.outputType;
            if (@object.IsObject())
            {
                if (@object.child is null)
                {
                    buffer.Append("{}");
                } else
                {
                    bool newLines = !IsFlat(@object);
                    int start = buffer.Length;
                    buffer.Append(newLines ? "{\n" : "{ ");
                begin:
                    for (JsonValue? child = @object.Child; child != null; child = child.next)
                    {
                        if (newLines)
                        {
                            Indent(indent, buffer);
                        }

                        buffer.Append(outputType.QuoteName(child.name ?? throw new NullReferenceException()));
                        buffer.Append(": ");
                        PrettyPrint(child, buffer, indent + 1, settings);
                        if ((!newLines || outputType != OutputType.Minimal) && child.next != null)
                        {
                            buffer.Append(',');
                        }

                        buffer.Append(newLines ? '\n' : ' ');
                        if (!newLines && buffer.Length - start > settings.singleLineColumns)
                        {
                            buffer.Length = start;
                            newLines = true;
                            goto begin;
                        }
                    }
                    if (newLines)
                    {
                        Indent(indent - 1, buffer);
                    }

                    buffer.Append('}');
                }
            } else if (@object.IsArray())
            {
                if (@object.child == null)
                {
                    buffer.Append("[]");
                } else
                {
                    bool newLines = !IsFlat(@object);
                    bool wrap = settings.wrapNumericArrays || !IsNumeric(@object);
                    int start = buffer.Length;
                outer:
                    buffer.Append(newLines ? "[\n" : "[ ");
                    for (JsonValue? child = @object.child; child != null; child = child.next)
                    {
                        if (newLines)
                        {
                            Indent(indent, buffer);
                        }

                        PrettyPrint(child, buffer, indent + 1, settings);
                        if ((!newLines || outputType != OutputType.Minimal) && child.next != null)
                        {
                            buffer.Append(',');
                        }

                        buffer.Append(newLines ? '\n' : ' ');
                        if (wrap && !newLines && buffer.Length - start > settings.singleLineColumns)
                        {
                            buffer.Length = start;
                            newLines = true;
                            goto outer;
                        }
                    }
                    if (newLines)
                    {
                        Indent(indent - 1, buffer);
                    }

                    buffer.Append(']');
                }
            } else if (@object.IsString())
            {
                buffer.Append(outputType.QuoteValue(@object.AsString() ?? throw new NullReferenceException()));
            } else if (@object.IsDouble())
            {
                double doubleValue = @object.AsDouble();
                long longValue = @object.AsLong();
                buffer.Append(doubleValue);
            } else if (@object.IsLong())
            {
                buffer.Append(@object.AsLong());
            } else if (@object.IsBoolean())
            {
                buffer.Append(@object.AsBoolean());
            } else if (@object.IsNull())
            {
                buffer.Append("null");
            } else
            {
                throw new SerializationException("Unknown object type: " + @object);
            }
        }

        /**
         * More efficient than {@link #prettyPrint(PrettyPrintSettings)} but {@link PrettyPrintSettings#singleLineColumns} and
         * {@link PrettyPrintSettings#wrapNumericArrays} are not supported.
         */
        public void PrettyPrint(OutputType outputType, TextWriter writer)
        {
            PrettyPrintSettings settings = new()
            {
                outputType = outputType
            };
            PrettyPrint(this, writer, 0, settings);
        }

        private void PrettyPrint(JsonValue @object, TextWriter writer, int indent, PrettyPrintSettings settings)
        {
            OutputType outputType = settings.outputType;
            if (@object.IsObject())
            {
                if (@object.child == null)
                {
                    writer.Write("{}");
                } else
                {
                    bool newLines = !IsFlat(@object) || @object.size > 6;
                    writer.Write(newLines ? "{\n" : "{ ");
                    for (JsonValue? child = @object.child; child != null; child = child.next)
                    {
                        if (newLines)
                        {
                            Indent(indent, writer);
                        }

                        writer.Write(outputType.QuoteName(child.name ?? throw new NullReferenceException()));
                        writer.Write(": ");
                        PrettyPrint(child, writer, indent + 1, settings);
                        if ((!newLines || outputType != OutputType.Minimal) && child.next != null)
                        {
                            writer.Write(',');
                        }

                        writer.Write(newLines ? '\n' : ' ');
                    }
                    if (newLines)
                    {
                        Indent(indent - 1, writer);
                    }

                    writer.Write('}');
                }
            } else if (@object.IsArray())
            {
                if (@object.child == null)
                {
                    writer.Write("[]");
                } else
                {
                    bool newLines = !IsFlat(@object);
                    writer.Write(newLines ? "[\n" : "[ ");
                    for (JsonValue? child = @object.child; child != null; child = child.next)
                    {
                        if (newLines)
                        {
                            Indent(indent, writer);
                        }

                        PrettyPrint(child, writer, indent + 1, settings);
                        if ((!newLines || outputType != OutputType.Minimal) && child.next != null)
                        {
                            writer.Write(',');
                        }

                        writer.Write(newLines ? '\n' : ' ');
                    }
                    if (newLines)
                    {
                        Indent(indent - 1, writer);
                    }

                    writer.Write(']');
                }
            } else if (@object.IsString())
            {
                writer.Write(outputType.QuoteValue(@object.AsString() ?? throw new NullReferenceException()));
            } else if (@object.IsDouble())
            {
                double doubleValue = @object.AsDouble();
                long longValue = @object.AsLong();
                writer.Write(doubleValue.ToString());
            } else if (@object.IsLong())
            {
                writer.Write(@object.AsLong().ToString());
            } else if (@object.IsBoolean())
            {
                writer.Write(@object.AsBoolean().ToString());
            } else if (@object.IsNull())
            {
                writer.Write("null");
            } else
            {
                throw new SerializationException("Unknown object type: " + @object);
            }
        }

        public IEnumerator<JsonValue> GetEnumerator() => new JsonEnumerator(this);

        /** Returns a human readable string representing the path from the root of the JSON object graph to this value. */
        public string Trace()
        {
            if (parent == null)
            {
                return type switch
                {
                    JsonValueType.ArrayValue => "[]",
                    JsonValueType.ObjectValue => "{}",
                    _ => "",
                };
            }
            string trace;
            if (parent.type == JsonValueType.ArrayValue)
            {
                trace = "[]";
                int i = 0;
                for (JsonValue? child = parent.child; child != null; child = child.next, i++)
                {
                    if (child == this)
                    {
                        trace = "[" + i + "]";
                        break;
                    }
                }
            } else
            {
                trace = name?.Contains('.') ?? false ? ".\"" + name.Replace("\"", "\\\"") + "\"" : '.' + name;
            }

            return parent.Trace() + trace;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public class JsonEnumerator: IEnumerator<JsonValue>
        {
            public JsonEnumerator(JsonValue val)
            {
                that = val;
                current = val;
                entry = val.child;
            }
            JsonValue that;
            JsonValue? entry;
            JsonValue current;

            public JsonValue Current => current;

            object IEnumerator.Current => this.Current;

            public bool HasNext() => entry != null;

            public void Remove()
            {
                if (current.prev == null)
                {
                    that.child = current.next;
                    that.child?.prev = null;
                } else
                {
                    current.prev.next = current.next;
                    current.next?.prev = current.prev;
                }
                that.size--;
            }

            public bool MoveNext()
            {
                if (entry is null)
                {
                    return false;
                }
                current = entry;
                entry = current.next;
                return true;
            }
            public void Reset()
            {
            }
            public void Dispose()
            {
            }
        }
    }
    public record PrettyPrintSettings
    {
        public OutputType outputType;

        /// <summary>
        /// If an object on a single line fits this many columns, it won't wrap.
        /// </summary>
        public int singleLineColumns;

        /// <summary>
        /// Arrays of floats won't wrap.
        /// </summary>
        public bool wrapNumericArrays;
    }

    public enum JsonValueType
    {
        ObjectValue,
        ArrayValue,
        StringValue,
        DoubleValue,
        LongValue,
        BooleanValue,
        NullValue,
    }
}
