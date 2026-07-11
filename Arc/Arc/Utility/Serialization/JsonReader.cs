using Arc.Files;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;

namespace Arc.Utility.Serialization
{
    public class JsonReader: IBaseJsonReader
    {
        public JsonValue Parse(string json) => Parse(new MemoryStream(Encoding.UTF8.GetBytes(json)));

        /// <summary>
        /// It will close <c>reader</c>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        public JsonValue Parse(TextReader reader)
        {
            try
            {
                return Parse(reader.ReadToEnd());
            } catch (IOException ex)
            {
                throw new SerializationException(null, ex);
            } finally
            {
                reader.Close();
            }
        }

        // line 337 "JsonReader.rl"

        /// <summary>
        /// It will close <c>input</c>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonValue Parse(Stream input)
        {
            using (Stream stream = input)
            {
                return new(JsonDocument.Parse(stream));
            }
        }

        public JsonValue Parse(Fi file)
        {
            try
            {
                return Parse(file.Reader(Encoding.UTF8));
            } catch (Exception ex)
            {
                throw new SerializationException("Error parsing file: " + file, ex);
            }
        }
    }
}
