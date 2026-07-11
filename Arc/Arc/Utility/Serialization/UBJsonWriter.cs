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
            if (current is not null)
            {
                if (!current.array)
                {
                    if (!named)
                    {
                        throw new InvalidOperationException("Name must be set");
                    }
                    named = false;
                }
            }
            stack.Push(current = new(false, writer));
            return this;
        }
        public UBJsonWriter Object(string name) => Name(name).Object();

        public UBJsonWriter Array()
        {
            if (current is not null)
            {
                if (!current.array)
                {
                    if (!named)
                    {
                        throw new InvalidOperationException("Name must be set");
                    }
                    named = false;
                }
            }
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
            byte[] bytes = Encoding.UTF8.GetBytes(name);
            if (bytes.Length <= byte.MaxValue)
            {
                writer.Write((byte) 'i');
                writer.Write((byte) bytes.Length);
            }
        }

        public void Dispose() => throw new NotImplementedException();

        void WriteShort(short value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(short)];
            BinaryPrimitives.WriteInt16BigEndian(buffer, value);
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
        }
    }
}
