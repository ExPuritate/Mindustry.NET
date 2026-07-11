namespace Arc.Utility.Serialization
{
    public interface IBaseJsonWriter<TThis>: IDisposable
        where TThis : IBaseJsonWriter<TThis>
    {
        void SetOutputType(OutputType outputType);
        void SetQuoteLongValues(bool quoteLongValues);
        TThis Name(string name);
        TThis Object();
        TThis Array();
        TThis Value(object? value);
        TThis Object(string name);
        TThis Array(string name);
        TThis Set(string name, object? value);
        TThis Pop();
    }
}
