using Arc.Files;
using Arc.Utility;
using Arc.Utility.Serialization;
using System.Runtime.CompilerServices;

namespace Arc
{
    public class Settings
    {
        protected static byte typeBool = 0, typeInt = 1, typeLong = 2, typeFloat = 3, typeString = 4, typeBinary = 5;
        protected static int maxBackups = 10, minBackupIntervalMs = 1000 * 60 * 2;

        Lock _lock = new();

        //general state data
        protected Fi? dataDirectory;
        protected string appName = "app";
        protected Dictionary<string, object> defaults = [];
        protected Dictionary<string, object> values = [];
        protected bool modified;
        public event EventHandler<Exception>? ErrorHandler;
        protected bool hasErrored;
        protected bool shouldAutosave = true;
        protected bool loaded = false;
        protected bool writeCompressed = false;
        private long lastBackupTime;

        protected BufferedStream ByteStream = new(new MemoryStream());
        protected MemoryStream InputStream = new();
        protected UBJsonReader ureader = new();

        public bool Compressed
        {
            set => writeCompressed = value;
        }

        public string AppName
        {
            get => appName;
            set => appName = value;
        }

        public bool ShouldAutosave
        {
            set => shouldAutosave = value;
        }

        public bool Modified => modified;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Load()
        {
            try
            {
            } catch (Exception ex)
            {
                Logger.Instance.Err("Error loading settings", ex);
                if (!hasErrored)
                {
                    ErrorHandler?.Invoke(this, ex);
                } else
                {
                    throw;
                }
                hasErrored = true;
            }
            loaded = true;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ForceSave()
        {
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ManualSave()
        {
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Autosave()
        {
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void LoadValues()
        {
        }

        /// <summary>
        /// Returns the file used for writing settings to. Not available on all platforms!
        /// </summary>
        public Fi SettingsFile => DataDirectory.Child("settings.bin");

        public Fi BackupFolder => DataDirectory.Child("settings_backups");

        public Fi BackupSettingsFile => DataDirectory.Child("settings_backup.bin");

        public Fi DataDirectory
        {
            get => dataDirectory ?? Core.Files!.Absolute(new(OS.getAppDataDirectoryString(appName)));
            set => dataDirectory = value;
        }
    }
}
