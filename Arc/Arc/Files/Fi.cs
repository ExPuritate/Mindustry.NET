using Arc.Utility;
using System.Security.Cryptography;
using System.Text;

namespace Arc.Files
{
    public struct FilePath
    {
        public string Value;

        public FilePath(string val, bool shouldAbsolute = true)
        {
            if (shouldAbsolute)
            {
                val = Path.GetFullPath(val);
            }
            Value = val;
        }

        public void ChangeExtension(string? extension) =>
            Value = Path.ChangeExtension(Value, extension);
        public readonly bool EndsInDirectorySeparator() => Path.EndsInDirectorySeparator(Value);
        public readonly bool Exists() => Path.Exists(Value);
        public readonly FilePath? DirectoryName => Path.GetDirectoryName(Value) switch
        {
            null => null,
            var x => new(x),
        };
        public readonly FilePath FullPath => new(Path.GetFullPath(Value), false);
        public readonly string Extension => Path.GetExtension(Value);
        public readonly string FileName => Path.GetFileName(Value);
        public readonly string FileNameWithoutExtension => Path.GetFileNameWithoutExtension(Value);
        public readonly FilePath? PathRoot => Path.GetPathRoot(Value) switch
        {
            null => null,
            var x => new(x),
        };
        public static FilePath GetTempFileName() => new(Path.GetTempFileName(), false);
        public static FilePath GetTempPath() => new(Path.GetTempPath(), false);
        public readonly bool HasExtension() => Path.HasExtension(Value);
        public readonly bool IsFullyQualified() => Path.IsPathFullyQualified(Value);
        public readonly bool IsRoot() => Path.IsPathRooted(Value);
        public readonly FilePath TrimEndingDirectorySeparator() => new(Path.TrimEndingDirectorySeparator(Value), false);

        public static explicit operator string(FilePath file) => file.Value;
    }
    public class Fi: IComparable<Fi>
    {
        protected FilePath? file;
        protected IFiles.FileType type;

        protected Fi()
        {
        }

        /// <summary>
        /// Creates a new absolute FileHandle for the file name. Use this for tools on the desktop that don't need any of the backends.
        /// Do not use this constructor in case you write something cross-platform. Use the <see cref="IFiles" /> interface instead.
        /// </summary>
        public Fi(string fileName)
        {
            file = new(fileName);
            type = IFiles.FileType.Absolute;
        }

        /// <summary>
        /// Creates a new absolute FileHandle for the {@link FilePath}. Use this for tools on the desktop that don't need any of the
        /// backends.Do not use this constructor in case you write something cross-platform.Use the <see cref="IFiles" />
        /// interface instead.
        /// </summary>
        /// <param name="file"></param>
        public Fi(FilePath file)
        {
            this.file = file;
            type = IFiles.FileType.Absolute;
        }

        public Fi(string fileName, IFiles.FileType type)
        {
            this.type = type;
            file = new(fileName);
        }

        protected Fi(FilePath file, IFiles.FileType type)
        {
            this.file = file;
            this.type = type;
        }

        public static Fi Get(string path) => new(path);

        public static Fi TempFile(string prefix)
        {
            string directory = Path.GetTempPath();
            string filePath;
            do
            {
                string randomName = Path.GetRandomFileName().Replace(".", "");
                string fileName = $"{prefix}{randomName}.tmp";
                filePath = Path.Combine(directory, fileName);
            }
            while (File.Exists(filePath));

            try
            {
                File.Create(filePath).Dispose();
                return new(filePath);
            } catch (IOException ex)
            {
                throw new ArcRuntimeException("Unable to create temp file.", ex);
            }
        }

        public static Fi TempDirectory(string prefix)
        {
            string directory = Path.GetTempPath();
            string filePath;
            do
            {
                string randomName = Path.GetRandomFileName().Replace(".", "");
                string fileName = $"{prefix}{randomName}.tmp";
                filePath = Path.Combine(directory, fileName);
            }
            while (File.Exists(filePath));

            try
            {
                File.Delete(filePath);
                Directory.CreateDirectory(filePath);
                return new(filePath);
            } catch (IOException ex)
            {
                throw new ArcRuntimeException("Unable to create temp file.", ex);
            }
        }

        /// <summary>
        /// emptyDirectory in java
        /// </summary>
        private static void ClearDirectory(FilePath file, bool preserveTree)
        {
            if (Directory.Exists(file.Value))
            {
                foreach (string value in Directory.EnumerateFileSystemEntries(file.Value))
                {
                    if (!Directory.Exists(value))
                    {
                        File.Delete(value);
                    } else if (preserveTree)
                    {
                        ClearDirectory(new(value), true);
                    } else
                    {
                        DeleteDirectory(new(value));
                    }
                }
            }
        }

        private static void DeleteDirectory(FilePath file) => Directory.Delete(file.Value, true);

        public string? PathString => file?.Value?.Replace('\\', '/');
        public string? AbsolutePathString => file?.FullPath.Value?.Replace("\\", "/");
        public string? Name => file?.FileName switch
        {
            null => null,
            var x => x == string.Empty ? file?.Value : x,
        };
        public bool ExtEquals(string ext) => Extension?.CompareTo(ext, StringComparison.OrdinalIgnoreCase) == 0;

        /// <summary>
        /// The file extension (without the dot) or an empty string if the file name doesn't contain a dot.
        /// </summary>
        public string? Extension => (file?.FileName) switch
        {
            null => null,
            var name => name.LastIndexOf('.') switch
            {
                -1 => "",
                var dotIndex => name[(dotIndex + 1)..]
            },
        };

        /// <summary>
        /// the name of the file, without parent paths or the extension.
        /// </summary>
        public string? NameWithoutExtension => (file?.FileName) switch
        {
            null => null,
            var name => name.LastIndexOf('.') switch
            {
                -1 => name,
                var dotIndex => name[0..dotIndex],
            }
        };

        /// <summary>
        /// the path and filename without the extension, e.g. dir/dir2/file.png -> dir/dir2/file. backward slashes will be
        /// returned as forward slashes.
        /// </summary>
        public string? PathWithoutExtension => PathString switch
        {
            null => null,
            var name => name.LastIndexOf('.') switch
            {
                -1 => name,
                var dotIndex => name[0..dotIndex],
            }
        };

        public IFiles.FileType Type => type;

        public FilePath? GetFile() => type switch
        {
            IFiles.FileType.External => new(Path.Join(
                (Core.Files ?? throw new NullReferenceException())
                    .ExternalStoragePath.Value,
                file?.Value)),
            _ => file,
        };

        public byte[] Sha256()
        {
            try
            {
                return SHA256.HashData(File.ReadAllBytes(file?.Value ?? throw new NullReferenceException()));
            } catch (IOException e)
            {
                throw new ArcRuntimeException(e);
            }
        }

        public FileStream Read() => File.OpenRead((GetFile() ?? throw new NullReferenceException()).Value);
        public BufferedStream Read(int bufferSize) => new(Read(), bufferSize);
        public StreamReader Reader() => Reader(Encoding.UTF8);
        public StreamReader Reader(Encoding encoding) => new(Read(), encoding);
        public StreamReader Reader(int bufferSize) => Reader(bufferSize, Encoding.UTF8);
        public StreamReader Reader(int bufferSize, Encoding encoding) => new(Read(bufferSize), encoding);

        public string ReadString() => ReadString(Encoding.UTF8);
        public string ReadString(Encoding encoding) => Reader(encoding).ReadToEnd();

        public byte[] ReadBytes()
        {
            using (MemoryStream ms = new())
            {
                Read().CopyTo(ms);
                return ms.ToArray();
            }
        }

        public MemoryStream ReadByteStream()
        {
            MemoryStream ms = new();
            Read().CopyTo(ms);
            return ms;
        }

        private int EstimateLength => LongLength switch
        {
            0 => 512,
            var length => (int) length,
        };

        /// <summary>
        /// Reads the entire file into the byte array. The byte array must be big enough to hold the file's data.
        /// </summary>
        /// <param name="bytes">the array to load the file into</param>
        /// <param name="offset">the offset to start writing bytes</param>
        /// <param name="size">the number of bytes to read, see <see cref="LongLength"/></param>
        /// <returns>the number of read bytes</returns>
        public int ReadBytes(byte[] bytes, int offset, int size)
        {
            int position = 0;
            using (Stream stream = Read())
            {
                while (true)
                {
                    int count = stream.Read(bytes, offset + position, size - position);
                    if (count <= 0)
                    {
                        break;
                    }
                    position += count;
                }
            }

            return position - offset;
        }

        public Fi Child(string name) => file?.Value is null || file?.Value == string.Empty
                ? new(name, type)
                : new(Path.Join(Path.GetDirectoryName(file?.Value ?? string.Empty), name), type);

        public long LongLength
        {
            get
            {
                if (type == IFiles.FileType.Internal && !File.Exists(file?.Value))
                {
                    Stream input = Read();
                    try
                    {
                        return input.Length;
                    } catch (Exception) { } finally
                    {
                        input.Close();
                    }
                    return 0;
                }
                string path = GetFile()?.Value ?? throw new NullReferenceException();
                return new FileInfo(path).Length;
            }
        }

        public int CompareTo(Fi? other) => throw new NotImplementedException();
    }
}
