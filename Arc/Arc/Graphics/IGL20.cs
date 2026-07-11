using System.Numerics;

namespace Arc.Graphics
{
    public interface IGL20
    {
        void GLActiveTexture(int texture);
        void GLBindTexture(int target, uint texture);
        void GLBlendFunc(int sfactor, int dfactor);
        void GLClear(uint mask);
        void GLClearColor(float red, float green, float blue, float alpha);
        void GLClearDepthf(float depth);
        void GLClearStencil(int s);
        void GLColorMask(bool red, bool green, bool blue, bool alpha);
        void GLCompressedTexImage2D(int target, int level, int internalformat, int width, int height, int border, Span<byte> data);
        void GLCompressedTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, Span<byte> data);
        void GLCopyTexImage2D(int target, int level, int internalformat, int x, int y, int width, int height, int border);
        void GLCopyTexSubImage2D(int target, int level, int xoffset, int yoffset, int x, int y, int width, int height);
        void GLCullFace(int mode);
        void GLDeleteTexture(uint texture);
        void GLDepthFunc(int func);
        void GLDepthMask(bool flag);
        void GLDepthRangef(float zNear, float zFar);
        void GLDisable(int cap);
        void GLDrawArrays(int mode, int first, int count);
        void GLDrawElements<T>(
            int mode,
            int count,
            int type,
            ReadOnlySpan<T> indices)
            where T : unmanaged, IUnsignedNumber<T>;
        void GLEnable(int cap);
        void GLFinish();
        void GLFlush();
        void GLFrontFace(int mode);
        uint GLGenTexture();
        int GLGetError();
        void GLGetIntegerv(int pname, ref int @params);
        string GLGetString(int name);
        void GLHint(int target, int mode);
        void GLLineWidth(float width);
        void GLPixelStorei(int pname, int param);
        void GLPolygonOffset(float factor, float units);
        void GLReadPixels<T>(
            int x,
            int y,
            int width,
            int height,
            int format,
            int type,
            Span<T> pixels)
            where T : unmanaged;
        void GLScissor(int x, int y, int width, int height);
        void GLStencilFunc(int func, int @ref, uint mask);
        void GLStencilMask(uint mask);
        void GLStencilOp(int fail, int zfail, int zpass);
        void GLTexImage2D<T>(
            int target,
            int level,
            int internalformat,
            int width,
            int height,
            int border,
            int format,
            int type,
            ReadOnlySpan<T> pixels)
            where T : unmanaged;
        void GLTexParameterf(int target, int pname, float param);
        public void GLTexSubImage2D<T>(
            int target,
            int level,
            int xoffset,
            int yoffset,
            int width,
            int height,
            int format,
            int type,
            ReadOnlySpan<T> pixels)
            where T : unmanaged;
        void GLViewport(int x, int y, int width, int height);
        void GLAttachShader(uint program, uint shader);
        void GLBindAttribLocation(uint program, uint index, string name);
        void GLBindBuffer(int target, uint buffer);
        void GLBindFramebuffer(int target, uint framebuffer);
        void GLBindRenderbuffer(int target, uint renderbuffer);
        void GLBlendColor(float red, float green, float blue, float alpha);
        void GLBlendEquation(int mode);
        void GLBlendEquationSeparate(int modeRGB, int modeAlpha);
        void GLBlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha);
        void GLBufferData<T>(int target, Span<T> data, int usage) where T : unmanaged;
        void GLBufferSubData<T>(int target, int offset, Span<T> data) where T : unmanaged;
        int GLCheckFramebufferStatus(int target);
        void GLCompileShader(uint shader);
        uint GLCreateProgram();
        uint GLCreateShader(int type);
        void GLDeleteBuffer(uint buffer);
        void GLDeleteFramebuffer(uint framebuffer);
        void GLDeleteProgram(uint program);
        void GLDeleteRenderbuffer(uint renderbuffer);
        void GLDeleteShader(uint shader);
        void GLDetachShader(uint program, uint shader);
        void GLDisableVertexAttribArray(uint index);
        void GLDrawElements(int mode, int count, int type, IntPtr indices);
        void GLEnableVertexAttribArray(uint index);
        void GLFramebufferRenderbuffer(
            int target,
            int attachment,
            int renderbuffertarget,
            uint renderbuffer);
        void GLFramebufferTexture2D(
            int target,
            int attachment,
            int textarget,
            uint texture,
            int level);
        uint GLGenBuffer();
        void GLGenerateMipmap(int target);
        uint GLGenFramebuffer();
        uint GLGenRenderbuffer();
        string GLGetActiveAttrib(uint program, uint index, int bufSize, out int size, out int type);
        string GLGetActiveUniform(uint program, uint index, int bufSize, out int size, out int type);
        int GLGetAttribLocation(uint program, string name);
        void GLGetBooleanv(int pname, ref bool @params);
        void GLGetBufferParameteriv(int target, int pname, ref int @params);
        void GLGetFloatv(int pname, ref float @params);
        void GLGetFramebufferAttachmentParameteriv(
            int target,
            int attachment,
            int pname,
            ref int @params);
        void GLGetProgramiv(uint program, int pname, ref int @params);
        string GLGetProgramInfoLog(uint program);
        void GLGetRenderbufferParameteriv(
            int target,
            int pname,
            ref int @params);
        void GLGetShaderiv(uint shader, int pname, ref int @params);
        string GLGetShaderInfoLog(uint shader);
        void GLGetShaderPrecisionFormat(
            int shadertype,
            int precisiontype,
            ref (int, int) range,
            ref int precision);
        void GLGetTexParameterfv(int target, int pname, ref float @params);
        void GLGetTexParameteriv(int target, int pname, ref int @params);
        void GLGetUniformfv(uint program, int location, ref float @params);
        void GLGetUniformiv(uint program, int location, ref int @params);
        int GLGetUniformLocation(uint program, string name);
        void GLGetVertexAttribfv(uint index, int pname, ref float @params);
        void GLGetVertexAttribiv(uint index, int pname, ref int @params);
        bool GLIsBuffer(uint buffer);
        bool GLIsEnabled(int cap);
        bool GLIsFramebuffer(uint framebuffer);
        bool GLIsProgram(uint program);
        bool GLIsRenderbuffer(uint renderbuffer);
        bool GLIsShader(uint shader);
        bool GLIsTexture(uint texture);
        void GLLinkProgram(uint program);
        void GLReleaseShaderCompiler();
        void GLRenderbufferStorage(int target, int internalformat, int width, int height);
        void GLSampleCoverage(float value, bool invert);
        void GLShaderSource(uint shader, string @string);
        void GLStencilFuncSeparate(int face, int func, int @ref, uint mask);
        void GLStencilMaskSeparate(int face, uint mask);
        void GLStencilOpSeparate(int face, int fail, int zfail, int zpass);
        void GLTexParameterfv(int target, int pname, ReadOnlySpan<float> @params);
        void GLTexParameteri(int target, int pname, int param);
        void GLTexParameteriv(int target, int pname, ReadOnlySpan<int> @params);
        void GLUniform1f(int location, float x);
        void GLUniform1fv(int location, params ReadOnlySpan<float> v);
        void GLUniform1i(int location, int x);
        void GLUniform1iv(int location, params ReadOnlySpan<int> v);
        void GLUniform2f(int location, float x, float y);
        void GLUniform2fv(int location, params ReadOnlySpan<float> v);
        void GLUniform2i(int location, int x, int y);
        void GLUniform2iv(int location, params ReadOnlySpan<int> v);
        void GLUniform3f(int location, float x, float y, float z);
        void GLUniform3fv(int location, params ReadOnlySpan<float> v);
        void GLUniform3i(int location, int x, int y, int z);
        void GLUniform3iv(int location, params ReadOnlySpan<int> v);
        void GLUniform4f(int location, float x, float y, float z, float w);
        void GLUniform4fv(int location, ReadOnlySpan<float> v);
        void GLUniform4i(int location, int x, int y, int z, int w);
        void GLUniform4iv(int location, params ReadOnlySpan<int> v);
        void GLUniformMatrix2fv(int location, bool transpose, params ReadOnlySpan<float> value);
        void GLUniformMatrix3fv(int location, bool transpose, params ReadOnlySpan<float> value);
        void GLUniformMatrix4fv(int location, bool transpose, params ReadOnlySpan<float> value);
        void GLUseProgram(uint program);
        void GLValidateProgram(uint program);
        void GLVertexAttrib1f(uint indx, float x);
        void GLVertexAttrib1fv(uint indx, params ReadOnlySpan<float> values);
        void GLVertexAttrib2f(uint indx, float x, float y);
        void GLVertexAttrib2fv(uint indx, params ReadOnlySpan<float> values);
        void GLVertexAttrib3f(uint indx, float x, float y, float z);
        void GLVertexAttrib3fv(uint indx, params ReadOnlySpan<float> values);
        void GLVertexAttrib4f(uint indx, float x, float y, float z, float w);
        void GLVertexAttrib4fv(uint indx, params ReadOnlySpan<float> values);
        /**
         * In OpenGl core profiles (3.1+), passing a pointer to client memory is not valid.
         * In 3.0 and later, use the other version of this function instead, pass a zero-based
         * offset which references the buffer currently bound to GL_ARRAY_BUFFER.
         */
        unsafe void GLVertexAttribPointer(
            uint indx,
            int size,
            int type,
            bool normalized,
            int stride,
            void* ptr);
        void GLVertexAttribPointer(
            uint indx,
            int size,
            int type,
            bool normalized,
            int stride,
            IntPtr ptr);
    }
}
