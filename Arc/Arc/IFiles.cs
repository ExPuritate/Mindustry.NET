using Arc.Files;
using Arc.Utility;

namespace Arc
{
    /// <summary>
    /// Provides standard access to the filesystem, classpath, Android SD card, and Android assets directory.
    /// </summary>
    public interface IFiles
    {
        /// <summary>
        /// Returns a handle representing a file or directory.
        /// Throws <see cref="ArcRuntimeException"/> if the type is classpath or internal and the file does not exist..
        /// </summary>
        /// <param name="path">Determines how the path is resolved.</param>
        /// <param name="type"></param>
        /// <returns></returns>
        Fi Get(FilePath path, FileType type);

        Fi Internal(FilePath path) => Get(path, FileType.Internal);

        Fi External(FilePath path) => Get(path, FileType.External);

        Fi Absolute(FilePath path) => Get(path, FileType.Absolute);

        Fi Local(FilePath path) => Get(path, FileType.Local);

        Fi Cache(string path) => Get(CachePath, FileType.Absolute).Child(path);

        FilePath CachePath
        {
            get => new(Local(new("cache")).PathString!);
        }

        string? InternalStoragePath => null;

        /// <summary>
        /// the external storage path directory. This is the SD card on Android and the home directory of the current user on
        /// the desktop.
        /// </summary>
        FilePath ExternalStoragePath
        {
            get;
        }

        /// <summary>
        /// true if the external storage is ready for file IO. Eg, on Android, the SD card is not available when mounted for use
        /// with a PC.
        /// </summary>
        bool IsExternalStorageAvailable
        {
            get;
        }

        /// <summary>
        /// the local storage path directory. This is the private files directory on Android and the directory of the jar on the
        /// desktop.
        /// </summary>
        FilePath LocalStoragePath
        {
            get;
        }

        /// <summary>
        /// true if the local storage is ready for file IO.
        /// </summary>
        bool IsLocalStorageAvailable
        {
            get;
        }

        public enum FileType
        {
            // No classpath
            /// <summary>
            /// Path relative to the asset directory on Android and to the application's root directory on the desktop.
            /// Internal files are always readonly.
            /// </summary>
            Internal,
            /// <summary>
            /// Path relative to the root of the SD card on Android and to the home directory of the current user on the desktop.
            /// </summary>
            External,
            /// <summary>
            /// Path that is a fully qualified, absolute filesystem path. To ensure portability across platforms use absolute files only when absolutely (heh) necessary.
            /// </summary>
            Absolute,
            /// <summary>
            /// Path relative to the private files directory on Android and to the application's root directory on the desktop.
            /// </summary>
            Local,
        }
    }
}
