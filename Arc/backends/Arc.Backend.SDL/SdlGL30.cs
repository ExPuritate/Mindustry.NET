using Arc.Graphics;
using DotGL;
using System.Numerics;

namespace Arc.Backend.SDL
{
    public class SdlGL30: SdlGL20, IGL20, IGL30
    {
        public void GLReadBuffer(int mode) => GL.GLReadBuffer(mode);
        public void GLDrawRangeElements<T>(
            int mode,
            uint start,
            uint end,
            int count,
            int type,
            ReadOnlySpan<T> indices)
            where T : unmanaged, IUnsignedNumber<T> => GL.GLDrawRangeElements(
                mode,
                start,
                end,
                count,
                type,
                indices);
        public unsafe void GLDrawRangeElements(
            int mode,
            uint start,
            uint end,
            int count,
            int type,
            nint offset) => GL.GLDrawRangeElements(mode, start, end, count, type, offset.ToPointer());
        public void GLTexImage3D<T>(
            int target,
            int level,
            int internalformat,
            int width,
            int height,
            int depth,
            int border,
            int format,
            int type,
            ReadOnlySpan<T> pixels)
            where T : unmanaged => GL.GLTexImage3D(
                target,
                level,
                internalformat,
                width,
                height,
                depth,
                border,
                format,
                type,
                pixels);
        public unsafe void GLTexImage3D(
            int target,
            int level,
            int internalformat,
            int width,
            int height,
            int depth,
            int border,
            int format,
            int type,
            nint offset) => GL.GLTexImage3D(
                target,
                level,
                internalformat,
                width,
                height,
                depth,
                border,
                format,
                type,
                offset.ToPointer());
        public void GLTexSubImage3D<T>(
            int target,
            int level,
            int xoffset,
            int yoffset,
            int zoffset,
            int width,
            int height,
            int depth,
            int format,
            int type,
            ReadOnlySpan<T> pixels)
            where T : unmanaged => GL.GLTexSubImage3D(
                target,
                level,
                xoffset,
                yoffset,
                zoffset,
                width,
                height,
                depth,
                format,
                type,
                pixels);
        public unsafe void GLTexSubImage3D(
            int target,
            int level,
            int xoffset,
            int yoffset,
            int zoffset,
            int width,
            int height,
            int depth,
            int format,
            int type,
            nint offset) => GL.GLTexSubImage3D(
                target,
                level,
                xoffset,
                yoffset,
                zoffset,
                width,
                height,
                depth,
                format,
                type,
                offset.ToPointer());
        public void GLCopyTexSubImage3D(
            int target,
            int level,
            int xoffset,
            int yoffset,
            int zoffset,
            int x,
            int y,
            int width,
            int height) => GL.GLCopyTexSubImage3D(
                target,
                level,
                xoffset,
                yoffset,
                zoffset,
                x,
                y,
                width,
                height);
        public uint[] GLGenQueries(int n) => GL.GLGenQueries(n);
        public void GLDeleteQueries(params uint[] ids) => GL.GLDeleteQueries(ids);
        public bool GLIsQuery(uint id) => GL.GLIsQuery(id);
        public void GLBeginQuery(int target, uint id) => GL.GLBeginQuery(target, id);
        public void GLEndQuery(int target) => GL.GLEndQuery(target);
        public void GLGetQueryiv(int target, int pname, ref int @params) =>
            GL.GLGetQueryiv(target, pname, ref @params);
        public void GLGetQueryObjectuiv(uint id, int pname, ref uint @params) =>
            GL.GLGetQueryObjectuiv(id, pname, ref @params);
        public bool GLUnmapBuffer(int target) => GL.GLUnmapBuffer(target);
        public byte[] GLGetBufferPointerv(int target, int pname) => throw new NotSupportedException();
        public void GLDrawBuffers(params ReadOnlySpan<int> bufs) => GL.GLDrawBuffers(bufs);
        public void GLUniformMatrix2x3fv(
            int location,
            bool transpose,
            params ReadOnlySpan<float> value) =>
            GL.GLUniformMatrix2x3fv(location, transpose, value);
        public void GLUniformMatrix3x2fv(
            int location,
            bool transpose,
            params ReadOnlySpan<float> value) => GL.GLUniformMatrix3x2fv(
                location,
                transpose,
                value);
        public void GLUniformMatrix2x4fv(
            int location,
            bool transpose,
            params ReadOnlySpan<float> value) => GL.GLUniformMatrix2x4fv(
                location,
                transpose,
                value);
        public void GLUniformMatrix4x2fv(
            int location,
            bool transpose,
            params ReadOnlySpan<float> value) => GL.GLUniformMatrix4x2fv(
                location,
                transpose,
                value);
        public void GLUniformMatrix3x4fv(
            int location,
            bool transpose,
            params ReadOnlySpan<float> value) => GL.GLUniformMatrix3x4fv(
                location,
                transpose,
                value);
        public void GLUniformMatrix4x3fv(
            int location,
            bool transpose,
            params ReadOnlySpan<float> value) => GL.GLUniformMatrix4x3fv(
                location,
                transpose,
                value);
        public void GLBlitFramebuffer(
            int srcX0,
            int srcY0,
            int srcX1,
            int srcY1,
            int dstX0,
            int dstY0,
            int dstX1,
            int dstY1,
            uint mask,
            int filter) => GL.GLBlitFramebuffer(
                srcX0,
                srcY0,
                srcX1,
                srcY1,
                dstX0,
                dstY0,
                dstX1,
                dstY1,
                mask,
                filter);
        public void GLRenderbufferStorageMultisample(
            int target,
            int samples,
            int internalformat,
            int width,
            int height) => GL.GLRenderbufferStorageMultisample(
                target,
                samples,
                internalformat,
                width,
                height);
        public void GLFramebufferTextureLayer(
            int target,
            int attachment,
            uint texture,
            int level,
            int layer) => GL.GLFramebufferTextureLayer(
                target,
                attachment,
                texture,
                level,
                layer);
        public void GLFlushMappedBufferRange(int target, int offset, int length) =>
            GL.GLFlushMappedBufferRange(target, offset, length);
        public void GLBindVertexArray(uint array) => GL.GLBindVertexArray(array);
        public void GLDeleteVertexArrays(params ReadOnlySpan<uint> arrays) =>
            GL.GLDeleteVertexArrays(arrays);
        public uint[] GLGenVertexArrays(int n) => GL.GLGenVertexArrays(n);
        public bool GLIsVertexArray(uint array) => GL.GLIsVertexArray(array);
        public void GLBeginTransformFeedback(int primitiveMode) =>
            GL.GLBeginTransformFeedback(primitiveMode);
        public void GLEndTransformFeedback() => GL.GLEndTransformFeedback();
        public void GLBindBufferRange(
            int target,
            uint index,
            uint buffer,
            int offset,
            int size) => GL.GLBindBufferRange(
                target,
                index,
                buffer,
                offset,
                size);
        public void GLBindBufferBase(int target, uint index, uint buffer) =>
            GL.GLBindBufferBase(target, index, buffer);
        public void GLTransformFeedbackVaryings(
            uint program,
            string[] varyings,
            int bufferMode) => GL.GLTransformFeedbackVaryings(
                program,
                varyings,
                bufferMode);
        public unsafe void GLVertexAttribIPointer(
            uint index,
            int size,
            int type,
            int stride,
            nint offset) => GL.GLVertexAttribIPointer(
                index,
                size,
                type,
                stride,
                offset.ToPointer());
        public void GLGetVertexAttribIiv(uint index, int pname, ref int @params) =>
            GL.GLGetVertexAttribIiv(index, pname, ref @params);
        public void GLGetVertexAttribIuiv(uint index, int pname, ref uint @params) =>
            GL.GLGetVertexAttribIuiv(index, pname, ref @params);
        public void GLVertexAttribI4i(uint index, int x, int y, int z, int w) =>
            GL.GLVertexAttribI4i(index, x, y, z, w);
        public void GLVertexAttribI4ui(uint index, uint x, uint y, uint z, uint w) =>
            GL.GLVertexAttribI4ui(index, x, y, z, w);
        public void GLGetUniformuiv(uint program, int location, Span<uint> @params) =>
            GL.GLGetUniformuiv(program, location, @params);
        public int GLGetFragDataLocation(uint program, string name) =>
            GL.GLGetFragDataLocation(program, name);
        public void GLUniform1uiv(int location, ReadOnlySpan<uint> value) =>
            GL.GLUniform1uiv(location, value);
        public void GLUniform3uiv(int location, ReadOnlySpan<uint> value) =>
            GL.GLUniform3uiv(location, value);
        public void GLUniform4uiv(int location, ReadOnlySpan<uint> value) =>
            GL.GLUniform4uiv(location, value);
        public void GLClearBufferiv(int buffer, int drawbuffer, ReadOnlySpan<int> value) =>
            GL.GLClearBufferiv(buffer, drawbuffer, value);
        public void GLClearBufferuiv(int buffer, int drawbuffer, ReadOnlySpan<uint> value) =>
            GL.GLClearBufferuiv(buffer, drawbuffer, value);
        public void GLClearBufferfv(int buffer, int drawbuffer, ReadOnlySpan<float> value) =>
            GL.GLClearBufferfv(buffer, drawbuffer, value);
        public void GLClearBufferfi(int buffer, int drawbuffer, float depth, int stencil) =>
            GL.GLClearBufferfi(buffer, drawbuffer, depth, stencil);
        public string GLGetStringi(int name, uint index) => GL.GLGetStringiSafe(name, index);
        public void GLCopyBufferSubData(
            int readTarget,
            int writeTarget,
            int readOffset,
            int writeOffset,
            int size) => GL.GLCopyBufferSubData(
                readTarget,
                writeTarget,
                readOffset,
                writeOffset,
                size);
        public uint[] GLGetUniformIndices(uint program, params string[] uniformNames) =>
            GL.GLGetUniformIndices(program, uniformNames);
        public int[] GLGetActiveUniformsiv(
            uint program,
            int pname,
            params ReadOnlySpan<uint> uniformIndices) => GL.GLGetActiveUniformsiv(
                program,
                pname,
                uniformIndices);
        public uint GLGetUniformBlockIndex(uint program, string uniformBlockName) =>
            GL.GLGetUniformBlockIndex(program, uniformBlockName);
        public void GLGetActiveUniformBlockiv(
            uint program,
            uint uniformBlockIndex,
            int pname,
            ref int @params) => GL.GLGetActiveUniformBlockiv(
                program,
                uniformBlockIndex,
                pname,
                ref @params);
        public string GLGetActiveUniformBlockName(uint program, uint uniformBlockIndex) =>
            GL.GLGetActiveUniformBlockName(program, uniformBlockIndex, 1 << 10);
        public void GLUniformBlockBinding(
            uint program,
            uint uniformBlockIndex,
            uint uniformBlockBinding) => GL.GLUniformBlockBinding(
                program,
                uniformBlockIndex,
                uniformBlockBinding);
        public void GLDrawArraysInstanced(int mode, int first, int count, int instanceCount) =>
            GL.GLDrawArraysInstanced(mode, first, count, instanceCount);
        public unsafe void GLDrawElementsInstanced(
            int mode,
            int count,
            int type,
            nint indicesOffset,
            int instanceCount) => GL.GLDrawElementsInstanced(
                mode,
                count,
                type,
                indicesOffset.ToPointer(),
                instanceCount);
        public void GLGetInteger64v(int pname, ref long @params) =>
            GL.GLGetInteger64v(pname, ref @params);
        public void GLGetBufferParameteri64v(int target, int pname, ref long @params) =>
            GL.GLGetBufferParameteri64v(target, pname, ref @params);
        public uint[] GLGenSamplers(int count) => GL.GLGenSamplers(count);
        public void GLDeleteSamplers(uint[] samplers) => GL.GLDeleteSamplers(samplers);
        public bool GLIsSampler(uint sampler) => GL.GLIsSampler(sampler);
        public void GLBindSampler(uint unit, uint sampler) => GL.GLBindSampler(unit, sampler);
        public void GLSamplerParameteri(uint sampler, int pname, int param) =>
            GL.GLSamplerParameteri(sampler, pname, param);
        public void GLSamplerParameteriv(uint sampler, int pname, ReadOnlySpan<int> param) =>
            GL.GLSamplerParameteriv(sampler, pname, param);
        public void GLSamplerParameterf(uint sampler, int pname, float param) =>
            GL.GLSamplerParameterf(sampler, pname, param);
        public void GLSamplerParameterfv(uint sampler, int pname, ReadOnlySpan<float> param) =>
            GL.GLSamplerParameterfv(sampler, pname, param);
        public void GLGetSamplerParameteriv(uint sampler, int pname, ref int @params) =>
            GL.GLGetSamplerParameteriv(sampler, pname, ref @params);
        public void GLGetSamplerParameterfv(uint sampler, int pname, ref float @params) =>
            GL.GLGetSamplerParameterfv(sampler, pname, ref @params);
        public void GLVertexAttribDivisor(uint index, uint divisor) =>
            GL.GLVertexAttribDivisor(index, divisor);
        public void GLBindTransformFeedback(int target, uint id) =>
            GL.GLBindTransformFeedback(target, id);
        public void GLDeleteTransformFeedbacks(params uint[] ids) =>
            GL.GLDeleteTransformFeedbacks(ids);
        public uint[] GLGenTransformFeedbacks(int n) =>
            GL.GLGenTransformFeedbacks(n);
        public bool GLIsTransformFeedback(uint id) => GL.GLIsTransformFeedback(id);
        public void GLPauseTransformFeedback() => GL.GLPauseTransformFeedback();
        public void GLResumeTransformFeedback() => GL.GLResumeTransformFeedback();
        public void GLProgramParameteri(uint program, int pname, int value) =>
            GL.GLProgramParameteri(program, pname, value);
        public void GLInvalidateFramebuffer(int target, int numAttachments, ReadOnlySpan<int> attachments) =>
            GL.GLInvalidateFramebuffer(target, numAttachments, attachments);
        public void GLInvalidateSubFramebuffer(
            int target,
            int numAttachments,
            ReadOnlySpan<int> attachments,
            int x,
            int y,
            int width,
            int height) => GL.GLInvalidateSubFramebuffer(
                target,
                numAttachments,
                attachments,
                x,
                y,
                width,
                height);
    }
}
