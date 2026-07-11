using Arc.Graphics;

namespace Arc
{
    /// <summary>
    /// Global references to all of Arc's core modules.
    /// </summary>
    public class Core
    {
        public IApplication? app;
        public IFiles? files;
        public Settings? settings;

        public IGL20? gl;
        public IGL20? gl20;
        public IGL30? gl30;

        public static readonly Core Instance = new();

        public static IApplication? Application
        {
            get
            {
                return Instance.app;
            }
            set
            {
                Instance.app = value;
            }
        }
        public static IFiles? Files
        {
            get => Instance.files;
            set => Instance.files = value;
        }
        public static Settings? Settings
        {
            get => Instance.settings;
            set => Instance.settings = value;
        }

        public static IGL20? GL
        {
            get => Instance.gl;
            set => Instance.gl = value;
        }
        public static IGL20? GL20
        {
            get => Instance.gl20;
            set => Instance.gl20 = value;
        }
        public static IGL30? GL30
        {
            get => Instance.gl30;
            set => Instance.gl30 = value;
        }
    }
}
