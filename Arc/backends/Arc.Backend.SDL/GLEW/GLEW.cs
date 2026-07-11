using System.Runtime.InteropServices;
using static Arc.Backend.SDL.GLEW.Vars;
using static DotGL.GL;

namespace Arc.Backend.SDL.GLEW
{
    public class GLEW
    {
        static unsafe class Unsafe
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate byte* GetStringProc(int name);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void GetIntegervProc(int pname, int* data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate byte* GetStringiProc(int name, uint index);
#if Windows_NT
            [DllImport(
                "OpenGL32.dll",
                CallingConvention = CallingConvention.StdCall,
                EntryPoint = "glGetString",
                ExactSpelling = true)]
            public static extern byte* GetString(int name);

            [DllImport(
                "OpenGL32.dll",
                CallingConvention = CallingConvention.StdCall,
                EntryPoint = "wglGetProcAddress",
                ExactSpelling = true,
                CharSet = CharSet.Ansi)]
            public static extern IntPtr WglGetProcAddress(
                string name
                );

            [DllImport(
                "OpenGL32.dll",
                CallingConvention = CallingConvention.StdCall,
                EntryPoint = "glGetIntegerv",
                ExactSpelling = true
                )]
            public static extern void GetIntegerv(int pname, int* data);
#endif
        }

        private static unsafe nint BsearchExtension(string name)
        {
            nint lo = 0, hi = _glewExtensionLookup.Length - 2;

            while (lo <= hi)
            {
                nint mid = (lo + hi) / 2;
                int cmp = string.Compare(name, _glewExtensionLookup[mid], StringComparison.Ordinal);
                switch (cmp)
                {
                    case < 0:
                        hi = mid - 1;
                        break;
                    case > 0:
                        lo = mid + 1;
                        break;
                    default:
                        return mid;
                }
            }

            return -1;
        }
        private static RefBool? GetExtensionString(string name)
        {
            nint n = BsearchExtension(name);
            return n >= 0 ? _glewExtensionString[n] : null;
        }
        private static RefBool? GetExtensionEnable(string name)
        {
            nint n = BsearchExtension(name);
            return n >= 0 ? _glewExtensionEnabled[n] : null;
        }

        private static unsafe void ContextInit()
        {
            Unsafe.GetStringProc getString;
#if Windows_NT
            getString = Unsafe.GetString;
#else
            getString = Marshal.GetDelegateForFunctionPointer<Unsafe.GetStringProc>(GetProcAddress("glGetString"));
            if (!getString)
            {
                throw new DotGL.GLException(GLEW_ERROR_NO_GL_VERSION);
            }
#endif
            string s = new((sbyte*) getString(GL_VERSION));
            string[] strings = s.Split('.');
            int major = int.Parse(strings[0]);
            int minor = int.Parse(strings[1]);

            if (minor is < 0 or > 9)
            {
                minor = 0;
            }
            if (major is < 0 or > 9)
            {
                throw new DotGL.GLException(GLEW_ERROR_NO_GL_VERSION);
            }
            if (major == 1 && minor == 0)
            {
                throw new DotGL.GLException(GLEW_ERROR_GL_VERSION_10_ONLY);
            } else
            {
                GLEW_VERSION_4_6 = (major > 4) || (major == 4 && minor >= 6) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_4_5 = GLEW_VERSION_4_6 == GL_TRUE || (major == 4 && minor >= 5) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_4_4 = GLEW_VERSION_4_5 == GL_TRUE || (major == 4 && minor >= 4) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_4_3 = GLEW_VERSION_4_4 == GL_TRUE || (major == 4 && minor >= 3) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_4_2 = GLEW_VERSION_4_3 == GL_TRUE || (major == 4 && minor >= 2) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_4_1 = GLEW_VERSION_4_2 == GL_TRUE || (major == 4 && minor >= 1) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_4_0 = GLEW_VERSION_4_1 == GL_TRUE || (major == 4) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_3_3 = GLEW_VERSION_4_0 == GL_TRUE || (major == 3 && minor >= 3) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_3_2 = GLEW_VERSION_3_3 == GL_TRUE || (major == 3 && minor >= 2) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_3_1 = GLEW_VERSION_3_2 == GL_TRUE || (major == 3 && minor >= 1) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_3_0 = GLEW_VERSION_3_1 == GL_TRUE || (major == 3) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_2_1 = GLEW_VERSION_3_0 == GL_TRUE || (major == 2 && minor >= 1) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_2_0 = GLEW_VERSION_2_1 == GL_TRUE || (major == 2) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_1_5 = GLEW_VERSION_2_0 == GL_TRUE || (major == 1 && minor >= 5) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_1_4 = GLEW_VERSION_1_5 == GL_TRUE || (major == 1 && minor >= 4) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_1_3 = GLEW_VERSION_1_4 == GL_TRUE || (major == 1 && minor >= 3) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_1_2_1 = GLEW_VERSION_1_3 == GL_TRUE ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_1_2 = GLEW_VERSION_1_2_1 == GL_TRUE || (major == 1 && minor >= 2) ? GL_TRUE : GL_FALSE;
                GLEW_VERSION_1_1 = GLEW_VERSION_1_2 == GL_TRUE || (major == 1 && minor >= 1) ? GL_TRUE : GL_FALSE;
            }

            Array.Fill(_glewExtensionString, new(false));

            if (GLEW_VERSION_3_0)
            {
                int n = 0;
                Unsafe.GetIntegervProc? getIntegerv = null;

#if Windows_NT
                getIntegerv = Unsafe.GetIntegerv;
#else
                if (GetProcAddress("glGetIntegerv") is IntPtr LPgetIntegerv && LPgetIntegerv != 0)
                {
                    getIntegerv = Marshal.GetDelegateForFunctionPointer<Unsafe.GetIntegervProc>(LPgetIntegerv);
                }
#endif


                getIntegerv?.Invoke(GL_NUM_EXTENSIONS, &n);

                if (GetProcAddress("glGetStringi") is IntPtr LPgetStringi && LPgetStringi != 0)
                {
                    Unsafe.GetStringiProc getStringi = Marshal.GetDelegateForFunctionPointer<Unsafe.GetStringiProc>(LPgetStringi);
                    for (uint i = 0; i < n; i++)
                    {
                        string ext = new((sbyte*) getStringi(GL_EXTENSIONS, i));

                        /* Based on extension string(s), glewGetExtension purposes */
                        RefBool? enable = GetExtensionString(ext);
                        enable?.Value = true;

                        /* Based on extension string(s), experimental mode, glewIsSupported purposes */
                        enable = GetExtensionEnable(ext);
                        enable?.Value = true;
                    }
                }
            } else
            {
                byte* szExtensions = getString(GL_EXTENSIONS);
                if (szExtensions != NULL)
                {
                    foreach (string ext in new string((sbyte*) szExtensions).Split(' '))
                    {
                        /* Based on extension string(s), glewGetExtension purposes */
                        RefBool? enable = GetExtensionString(ext);
                        enable?.Value = true;

                        /* Based on extension string(s), experimental mode, glewIsSupported purposes */
                        enable = GetExtensionEnable(ext);
                        enable?.Value = true;
                    }
                }
            }

            Import(GetProcAddress);
        }

#if Windows_NT
        public static void WglewInit()
        {
        }
#endif

        public static void Init()
        {
            ContextInit();
            WglewInit();
        }

        public static IntPtr GetProcAddress(string name) =>
#if Windows_NT
            Unsafe.WglGetProcAddress(name)
#else
            throw new NotImplementedException()
#endif
        ;
    }
}
