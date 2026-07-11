using Arc.Graphics;
using DotGL;
using System.Numerics;

namespace Arc.Backend.SDL
{
    public class SdlGL20: IGL20
    {
        public void GLActiveTexture(int texture) => GL.GLActiveTexture(texture);
        public void GLBindTexture(int target, uint texture) => GL.GLBindTexture(target, texture);
        public void GLBlendFunc(int sfactor, int dfactor) => GL.GLBlendFunc(sfactor, dfactor);
        public void GLClear(uint mask) => GL.GLClear(mask);
        public void GLClearColor(float red, float green, float blue, float alpha) => GL.GLClearColor(red, green, blue, alpha);
        public void GLClearDepthf(float depth) => GL.GLClearDepth(depth);
        public void GLClearStencil(int s) => GL.GLClearStencil(s);
        public void GLColorMask(bool red, bool green, bool blue, bool alpha) => GL.GLColorMask(red, green, blue, alpha);
        public void GLCompressedTexImage2D(
            int target,
            int level,
            int internalformat,
            int width,
            int height,
            int border,
            Span<byte> data)
        {
            unsafe
            {
                fixed (byte* lpData = data)
                {
                    GL.GLCompressedTexImage2D(
                    target,
                    level,
                    internalformat,
                    width,
                    height,
                    border,
                    data.Length,
                    lpData);
                }
            }
        }
        /// <summary>
        /// Specify a two-dimensional texture subimage in a compressed format
        /// </summary>
        /// 
        /// <param name="target">
        /// Specifies the target texture. Must be
        /// <see cref="GL.GL_TEXTURE_1D_ARRAY" />,
        /// <see cref="GL.GL_TEXTURE_2D" />,
        /// <see cref="GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X" />,
        /// <see cref="GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_X" />,
        /// <see cref="GL.GL_TEXTURE_CUBE_MAP_POSITIVE_Y" />,
        /// <see cref="GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Y" />,
        /// <see cref="GL.GL_TEXTURE_CUBE_MAP_POSITIVE_Z" /> or
        /// <see cref="GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Z" />.
        /// </param>
        /// 
        /// <param name="level">
        /// Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.
        /// </param>
        /// 
        /// <param name="xoffset">
        /// Specifies a texel offset in the x direction within the texture array.
        /// </param>
        /// 
        /// <param name="yoffset">
        /// Specifies a texel offset in the y direction within the texture array.
        /// </param>
        /// 
        /// <param name="width">
        /// Specifies the width of the texture subimage. All implementations support 2D texture subimages that are at least 16 texels wide.
        /// </param>
        /// 
        /// <param name="height">
        /// Specifies the height of the texture subimage. All implementations support 2D texture subimages that are at least 16 texels high.
        /// </param>
        /// 
        /// <param name="format">
        /// Specifies the color components in the texture. Must be one of
        /// <see cref="GL.GL_COMPRESSED_RED" />,
        /// <see cref="GL.GL_COMPRESSED_RG" />,
        /// <see cref="GL.GL_COMPRESSED_RGB" />,
        /// <see cref="GL.GL_COMPRESSED_RGBA" />,
        /// <see cref="GL.GL_COMPRESSED_SRGB" />,
        /// <see cref="GL.GL_COMPRESSED_SRGB_ALPHA" />.
        /// </param>
        /// <param name="data">Specifies a pointer to the compressed image data in memory.</param>
        public void GLCompressedTexSubImage2D(
            int target,
            int level,
            int xoffset,
            int yoffset,
            int width,
            int height,
            int format,
            Span<byte> data)
        {
            unsafe
            {
                fixed (byte* lpData = data)
                {
                    GL.GLCompressedTexSubImage2D(
                        target,
                        level,
                        xoffset,
                        yoffset,
                        width,
                        height,
                        format,
                        data.Length,
                        lpData);
                }
            }
        }
        public void GLCopyTexImage2D(
            int target,
            int level,
            int internalformat,
            int x,
            int y,
            int width,
            int height,
            int border) => GL.GLCopyTexImage2D(target, level, internalformat, x, y, width, height, border);
        public void GLCopyTexSubImage2D(
            int target,
            int level,
            int xoffset,
            int yoffset,
            int x,
            int y,
            int width,
            int height) => GL.GLCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
        public void GLCullFace(int mode) => GL.GLCullFace(mode);
        public void GLDeleteTexture(uint texture) => GL.GLDeleteTextures(texture);
        public void GLDepthFunc(int func) => GL.GLDepthFunc(func);
        public void GLDepthMask(bool flag) => GL.GLDepthMask(flag);
        public void GLDepthRangef(float zNear, float zFar) => GL.GLDepthRange(zNear, zFar);
        public void GLDisable(int cap) => GL.GLDisable(cap);
        public void GLDrawArrays(int mode, int first, int count) => GL.GLDrawArrays(mode, first, count);
        public void GLDrawElements<T>(int mode, int count, int type, ReadOnlySpan<T> indices)
            where T : unmanaged, IUnsignedNumber<T> => GL.GLDrawElements(mode, count, type, indices);
        public void GLEnable(int cap) => GL.GLEnable(cap);
        public void GLFinish() => GL.GLFinish();
        public void GLFlush() => GL.GLFlush();
        public void GLFrontFace(int mode) => GL.GLFrontFace(mode);
        public uint GLGenTexture() => GL.GLGenTexture();
        public int GLGetError() => GL.GLGetError();
        public void GLGetIntegerv(int pname, ref int @params) => GL.GLGetIntegerv(pname, ref @params);
        public string GLGetString(int name)
        {
            unsafe
            {
                return new((sbyte*) GL.GLGetString(name));
            }
        }
        public void GLHint(int target, int mode) => GL.GLHint(target, mode);
        public void GLLineWidth(float width) => GL.GLLineWidth(width);
        public void GLPixelStorei(int pname, int param) => GL.GLPixelStorei(pname, param);
        public void GLPolygonOffset(float factor, float units) => GL.GLPolygonOffset(factor, units);
        public void GLReadPixels<T>(
            int x,
            int y,
            int width,
            int height,
            int format,
            int type,
            Span<T> pixels)
            where T : unmanaged => GL.GLReadPixels<T>(
                x,
                y,
                width,
                height,
                format,
                type,
                pixels);
        public void GLScissor(int x, int y, int width, int height) => GL.GLScissor(x, y, width, height);
        public void GLStencilFunc(int func, int @ref, uint mask) => GL.GLStencilFunc(func, @ref, mask);
        public void GLStencilMask(uint mask) => GL.GLStencilMask(mask);
        public void GLStencilOp(int fail, int zfail, int zpass) => GL.GLStencilOp(fail, zfail, zpass);
        public void GLTexImage2D<T>(
            int target,
            int level,
            int internalformat,
            int width,
            int height,
            int border,
            int format,
            int type,
            ReadOnlySpan<T> pixels)
            where T : unmanaged => GL.GLTexImage2D(
                target,
                level,
                internalformat,
                width,
                height,
                border,
                format,
                type,
                pixels);
        public void GLTexParameterf(int target, int pname, float param) =>
            GL.GLTexParameterf(target, pname, param);
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
            where T : unmanaged => GL.GLTexSubImage2D(
                target,
                level,
                xoffset,
                yoffset,
                width,
                height,
                format,
                type,
                pixels);
        public void GLViewport(int x, int y, int width, int height) =>
            GL.GLViewport(x, y, width, height);
        public void GLAttachShader(uint program, uint shader) =>
            GL.GLAttachShader(program, shader);
        public void GLBindAttribLocation(uint program, uint index, string name) =>
            GL.GLBindAttribLocation(program, index, name);
        public void GLBindBuffer(int target, uint buffer) =>
            GL.GLBindBuffer(target, buffer);
        public void GLBindFramebuffer(int target, uint framebuffer) =>
            GL.GLBindFramebuffer(target, framebuffer);
        public void GLBindRenderbuffer(int target, uint renderbuffer) =>
            GL.GLBindRenderbuffer(target, renderbuffer);
        public void GLBlendColor(float red, float green, float blue, float alpha) =>
            GL.GLBlendColor(red, green, blue, alpha);
        public void GLBlendEquation(int mode) => GL.GLBlendEquation(mode);
        public void GLBlendEquationSeparate(int modeRGB, int modeAlpha) =>
            GL.GLBlendEquationSeparate(modeRGB, modeAlpha);
        public void GLBlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha) =>
            GL.GLBlendFuncSeparate(srcRGB, dstRGB, srcAlpha, dstAlpha);
        public void GLBufferData<T>(int target, Span<T> data, int usage) where T : unmanaged =>
            GL.GLBufferData(target, data, usage);
        public void GLBufferSubData<T>(int target, int offset, Span<T> data) where T : unmanaged
        {
            unsafe
            {
                fixed (T* lpData = data)
                {
                    GL.GLBufferSubData(target, offset, data.Length * sizeof(T), lpData);
                }
            }
        }
        public int GLCheckFramebufferStatus(int target) => GL.GLCheckFramebufferStatus(target);
        public void GLCompileShader(uint shader) => GL.GLCompileShader(shader);
        public uint GLCreateProgram() => GL.GLCreateProgram();
        public uint GLCreateShader(int type) => GL.GLCreateShader(type);
        public void GLDeleteBuffer(uint buffer) => GL.GLDeleteBuffers(buffer);
        public void GLDeleteFramebuffer(uint framebuffer) => GL.GLDeleteFramebuffers(framebuffer);
        public void GLDeleteProgram(uint program) => GL.GLDeleteProgram(program);
        public void GLDeleteRenderbuffer(uint renderbuffer) => GL.GLDeleteRenderbuffers(renderbuffer);
        public void GLDeleteShader(uint shader) => GL.GLDeleteShader(shader);
        public void GLDetachShader(uint program, uint shader) => GL.GLDetachShader(program, shader);
        public void GLDisableVertexAttribArray(uint index) => GL.GLDisableVertexAttribArray(index);
        public void GLDrawElements(int mode, int count, int type, IntPtr indices)
        {
            unsafe
            {
                GL.GLDrawElements(mode, count, type, indices.ToPointer());
            }
        }
        public void GLEnableVertexAttribArray(uint index) => GL.GLEnableVertexAttribArray(index);
        public void GLFramebufferRenderbuffer(
            int target,
            int attachment,
            int renderbuffertarget,
            uint renderbuffer) => GL.GLFramebufferRenderbuffer(
                target,
                attachment,
                renderbuffertarget,
                renderbuffer);
        public void GLFramebufferTexture2D(
            int target,
            int attachment,
            int textarget,
            uint texture,
            int level) => GL.GLFramebufferTexture2D(
                target,
                attachment,
                textarget,
                texture,
                level);
        public uint GLGenBuffer() => GL.GLGenBuffer();
        public void GLGenerateMipmap(int target) => GL.GLGenerateMipmap(target);
        public uint GLGenFramebuffer() => GL.GLGenFramebuffer();
        public uint GLGenRenderbuffer() => GL.GLGenRenderbuffer();
        public string GLGetActiveAttrib(
            uint program,
            uint index,
            int bufSize,
            out int size,
            out int type) =>
            GL.GLGetActiveAttrib(program, index, bufSize, out size, out type);
        public string GLGetActiveUniform(
            uint program,
            uint index,
            int bufSize,
            out int size,
            out int type) =>
            GL.GLGetActiveUniform(program, index, bufSize, out size, out type);
        public int GLGetAttribLocation(uint program, string name) => GL.GLGetAttribLocation(program, name);
        public void GLGetBooleanv(int pname, ref bool @params) => GL.GLGetBooleanv(pname, ref @params);
        public void GLGetBufferParameteriv(int target, int pname, ref int @params) =>
            GL.GLGetBufferParameteriv(target, pname, ref @params);
        public void GLGetFloatv(int pname, ref float @params) => GL.GLGetFloatv(pname, ref @params);
        public void GLGetFramebufferAttachmentParameteriv(
            int target,
            int attachment,
            int pname,
            ref int @params) => GL.GLGetFramebufferAttachmentParameteriv(
                target,
                attachment,
                pname,
                ref @params);
        public void GLGetProgramiv(uint program, int pname, ref int @params) =>
            GL.GLGetProgramiv(program, pname, ref @params);
        public string GLGetProgramInfoLog(uint program) => GL.GLGetProgramInfoLog(program, 10 << 10);
        public void GLGetRenderbufferParameteriv(int target, int pname, ref int @params)
            => GL.GLGetRenderbufferParameteriv(target, pname, ref @params);
        public void GLGetShaderiv(uint shader, int pname, ref int @params)
            => GL.GLGetShaderiv(shader, pname, ref @params);
        public string GLGetShaderInfoLog(uint shader) => GL.GLGetShaderInfoLog(shader, 10 << 10);
        public void GLGetShaderPrecisionFormat(
            int shadertype,
            int precisiontype,
            ref (int, int) range,
            ref int precision) => GL.GLGetShaderPrecisionFormat(
                shadertype,
                precisiontype,
                ref range,
                ref precision);
        public void GLGetTexParameterfv(int target, int pname, ref float @params) =>
            GL.GLGetTexParameterfv(target, pname, ref @params);
        public void GLGetTexParameteriv(int target, int pname, ref int @params) =>
            GL.GLGetTexParameteriv(target, pname, ref @params);
        public void GLGetUniformfv(uint program, int location, ref float @params) =>
            GL.GLGetUniformfv(program, location, ref @params);
        public void GLGetUniformiv(uint program, int location, ref int @params) =>
            GL.GLGetUniformiv(program, location, ref @params);
        public int GLGetUniformLocation(uint program, string name) =>
            GL.GLGetUniformLocation(program, name);
        public void GLGetVertexAttribfv(uint index, int pname, ref float @params) =>
            GL.GLGetVertexAttribfv(index, pname, ref @params);
        public void GLGetVertexAttribiv(uint index, int pname, ref int @params) =>
            GL.GLGetVertexAttribiv(index, pname, ref @params);
        public bool GLIsBuffer(uint buffer) => GL.GLIsBuffer(buffer);
        public bool GLIsEnabled(int cap) => GL.GLIsEnabled(cap);
        public bool GLIsFramebuffer(uint framebuffer) => GL.GLIsFramebuffer(framebuffer);
        public bool GLIsProgram(uint program) => GL.GLIsProgram(program);
        public bool GLIsRenderbuffer(uint renderbuffer) => GL.GLIsRenderbuffer(renderbuffer);
        public bool GLIsShader(uint shader) => GL.GLIsShader(shader);
        public bool GLIsTexture(uint texture) => GL.GLIsTexture(texture);
        public void GLLinkProgram(uint program) => GL.GLLinkProgram(program);
        public void GLReleaseShaderCompiler() => GL.GLReleaseShaderCompiler();
        public void GLRenderbufferStorage(
            int target,
            int internalformat,
            int width,
            int height) => GL.GLRenderbufferStorage(
                target,
                internalformat,
                width,
                height);
        public void GLSampleCoverage(float value, bool invert) => GL.GLSampleCoverage(value, invert);
        public void GLShaderSource(uint shader, string @string) => GL.GLShaderSource(shader, @string);
        public void GLStencilFuncSeparate(int face, int func, int @ref, uint mask) =>
            GL.GLStencilFuncSeparate(face, func, @ref, mask);
        public void GLStencilMaskSeparate(int face, uint mask) => GL.GLStencilMaskSeparate(face, mask);
        public void GLStencilOpSeparate(int face, int fail, int zfail, int zpass) =>
            GL.GLStencilOpSeparate(face, fail, zfail, zpass);
        public void GLTexParameterfv(int target, int pname, ReadOnlySpan<float> @params) =>
            GL.GLTexParameterfv(target, pname, @params);
        public void GLTexParameteri(int target, int pname, int param) =>
            GL.GLTexParameteri(target, pname, param);
        public void GLTexParameteriv(int target, int pname, ReadOnlySpan<int> @params) =>
            GL.GLTexParameteriv(target, pname, @params);
        public void GLUniform1f(int location, float x) => GL.GLUniform1f(location, x);
        public void GLUniform1fv(int location, params ReadOnlySpan<float> v) =>
            GL.GLUniform1fv(location, v);
        public void GLUniform1i(int location, int x) => GL.GLUniform1i(location, x);
        public void GLUniform1iv(int location, params ReadOnlySpan<int> v) =>
            GL.GLUniform1iv(location, v);
        public void GLUniform2f(int location, float x, float y) =>
            GL.GLUniform2f(location, x, y);
        public void GLUniform2fv(int location, params ReadOnlySpan<float> v) =>
            GL.GLUniform2fv(location, v);
        public void GLUniform2i(int location, int x, int y) =>
            GL.GLUniform2i(location, x, y);
        public void GLUniform2iv(int location, params ReadOnlySpan<int> v) =>
            GL.GLUniform2iv(location, v);
        public void GLUniform3f(int location, float x, float y, float z) =>
            GL.GLUniform3f(location, x, y, z);
        public void GLUniform3fv(int location, params ReadOnlySpan<float> v) =>
            GL.GLUniform3fv(location, v);
        public void GLUniform3i(int location, int x, int y, int z) =>
            GL.GLUniform3i(location, x, y, z);
        public void GLUniform3iv(int location, params ReadOnlySpan<int> v) =>
            GL.GLUniform3iv(location, v);
        public void GLUniform4f(int location, float x, float y, float z, float w) =>
            GL.GLUniform4f(location, x, y, z, w);
        public void GLUniform4fv(int location, ReadOnlySpan<float> v) =>
            GL.GLUniform4fv(location, v);
        public void GLUniform4i(int location, int x, int y, int z, int w) =>
            GL.GLUniform4i(location, x, y, z, w);
        public void GLUniform4iv(int location, params ReadOnlySpan<int> v) =>
            GL.GLUniform4iv(location, v);
        public void GLUniformMatrix2fv(int location, bool transpose, params ReadOnlySpan<float> value) =>
            GL.GLUniformMatrix2fv(location, transpose, value);
        public void GLUniformMatrix3fv(int location, bool transpose, params ReadOnlySpan<float> value) =>
            GL.GLUniformMatrix3fv(location, transpose, value);
        public void GLUniformMatrix4fv(int location, bool transpose, params ReadOnlySpan<float> value) =>
            GL.GLUniformMatrix4fv(location, transpose, value);
        public void GLUseProgram(uint program) => GL.GLUseProgram(program);
        public void GLValidateProgram(uint program) => GL.GLValidateProgram(program);
        public void GLVertexAttrib1f(uint indx, float x) => GL.GLVertexAttrib1f(indx, x);
        public void GLVertexAttrib1fv(uint indx, params ReadOnlySpan<float> values) =>
            GL.GLVertexAttrib1fv(indx, values);
        public void GLVertexAttrib2f(uint indx, float x, float y) =>
            GL.GLVertexAttrib2f(indx, x, y);
        public void GLVertexAttrib2fv(uint indx, params ReadOnlySpan<float> values) =>
            GL.GLVertexAttrib2fv(indx, values);
        public void GLVertexAttrib3f(uint indx, float x, float y, float z) =>
            GL.GLVertexAttrib3f(indx, x, y, z);
        public void GLVertexAttrib3fv(uint indx, params ReadOnlySpan<float> values) =>
            GL.GLVertexAttrib3fv(indx, values);
        public void GLVertexAttrib4f(uint indx, float x, float y, float z, float w) =>
            GL.GLVertexAttrib4f(indx, x, y, z, w);
        public void GLVertexAttrib4fv(uint indx, params ReadOnlySpan<float> values) =>
            GL.GLVertexAttrib4fv(indx, values);
        /**
         * In OpenGl core profiles (3.1+), passing a pointer to client memory is not valid.
         * In 3.0 and later, use the other version of this function instead, pass a zero-based
         * offset which references the buffer currently bound to GL_ARRAY_BUFFER.
         */
        public unsafe void GLVertexAttribPointer(
            uint indx,
            int size,
            int type,
            bool normalized,
            int stride,
            void* ptr) => GL.GLVertexAttribPointer(indx, size, type, normalized, stride, ptr);
        public unsafe void GLVertexAttribPointer(
            uint indx,
            int size,
            int type,
            bool normalized,
            int stride,
            IntPtr ptr) => GL.GLVertexAttribPointer(indx, size, type, normalized, stride, ptr.ToPointer());
    }
}
