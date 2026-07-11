using Arc.Files;

namespace Arc.Utility.Serialization
{
    public interface IBaseJsonReader
    {
        JsonValue Parse(Stream input);

        JsonValue Parse(Fi file) => Parse(file.Read());
    }
}
