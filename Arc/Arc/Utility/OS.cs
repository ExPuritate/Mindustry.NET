using Arc.Files;

namespace Arc.Utility
{
    public class OS
    {
        public static readonly FilePath UserHome = new(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
        public static string getAppDataDirectoryString(string appname)
        {
            if (OperatingSystem.IsWindows())
            {
                return Environment.GetEnvironmentVariable("AppData") + "\\\\" + appname;
            } else if (OperatingSystem.IsIOS() || OperatingSystem.IsAndroid())
            {
                return Core.Files!.LocalStoragePath.Value;
            } else if (OperatingSystem.IsLinux())
            {
                if (Environment.GetEnvironmentVariable("XDG_DATA_HOME") is string dir)
                {
                    if (!dir.EndsWith('/'))
                    {
                        dir += "/";
                    }

                    return dir + appname + "/";
                }
                return UserHome.Value + "/.local/share/" + appname + "/";
            } else if (OperatingSystem.IsMacOS())
            {
                return UserHome.Value + "/Library/Application Support/" + appname + "/";
            } else
            { //else, probably web
                return "";
            }
        }
    }
}
