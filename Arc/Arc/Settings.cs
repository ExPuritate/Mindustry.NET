using Arc.Files;

namespace Arc
{
    public class Settings
    {
        protected static byte typeBool = 0, typeInt = 1, typeLong = 2, typeFloat = 3, typeString = 4, typeBinary = 5;
        protected static int maxBackups = 10, minBackupIntervalMs = 1000 * 60 * 2;

        //general state data
        protected Fi dataDirectory;
        protected string appName = "app";
        protected Dictionary<string, object> defaults = new();
        protected Dictionary<string, object> values = new();
        protected bool modified;
        protected Action<Exception> errorHandler;
        protected bool hasErrored;
        protected bool shouldAutosave = true;
        protected bool loaded = false;
        protected bool writeCompressed = false;
        private long lastBackupTime;
    }
}
