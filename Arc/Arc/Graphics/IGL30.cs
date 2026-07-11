using System.Numerics;

namespace Arc.Graphics
{
    public interface IGL30: IGL20
    {
        void GLReadBuffer(int mode);
        void GLDrawRangeElements<T>(
            int mode,
            uint start,
            uint end,
            int count,
            int type,
            ReadOnlySpan<T> indices)
            where T : unmanaged, IUnsignedNumber<T>;
        void GLDrawRangeElements(
            int mode,
            uint start,
            uint end,
            int count,
            int type,
            IntPtr offset);
        void GLTexImage3D<T>(
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
            where T : unmanaged;
        void GLTexImage3D(
            int target,
            int level,
            int internalformat,
            int width,
            int height,
            int depth,
            int border,
            int format,
            int type,
            IntPtr offset);
        void GLTexSubImage3D<T>(
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
            where T : unmanaged;
        void GLTexSubImage3D(
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
            IntPtr offset);
        void GLCopyTexSubImage3D(
            int target,
            int level,
            int xoffset,
            int yoffset,
            int zoffset,
            int x,
            int y,
            int width,
            int height);
        uint[] GLGenQueries(int n);
        void GLDeleteQueries(params uint[] ids);
        bool GLIsQuery(uint id);
        void GLBeginQuery(int target, uint id);
        void GLEndQuery(int target);
        void GLGetQueryiv(int target, int pname, ref int @params);
        void GLGetQueryObjectuiv(uint id, int pname, ref uint @params);
        bool GLUnmapBuffer(int target);
        byte[] GLGetBufferPointerv(int target, int pname);
        void GLDrawBuffers(params ReadOnlySpan<int> bufs);
        void GLUniformMatrix2x3fv(int location, bool transpose, params ReadOnlySpan<float> value);
        void GLUniformMatrix3x2fv(int location, bool transpose, params ReadOnlySpan<float> value);
        void GLUniformMatrix2x4fv(int location, bool transpose, params ReadOnlySpan<float> value);
        void GLUniformMatrix4x2fv(int location, bool transpose, params ReadOnlySpan<float> value);
        void GLUniformMatrix3x4fv(int location, bool transpose, params ReadOnlySpan<float> value);
        void GLUniformMatrix4x3fv(int location, bool transpose, params ReadOnlySpan<float> value);
        void GLBlitFramebuffer(
            int srcX0,
            int srcY0,
            int srcX1,
            int srcY1,
            int dstX0,
            int dstY0,
            int dstX1,
            int dstY1,
            uint mask,
            int filter);
        void GLRenderbufferStorageMultisample(
            int target,
            int samples,
            int internalformat,
            int width,
            int height);
        void GLFramebufferTextureLayer(
            int target,
            int attachment,
            uint texture,
            int level,
            int layer);
        void GLFlushMappedBufferRange(int target, int offset, int length);
        void GLBindVertexArray(uint array);
        void GLDeleteVertexArrays(params ReadOnlySpan<uint> arrays);
        uint[] GLGenVertexArrays(int n);
        bool GLIsVertexArray(uint array);
        void GLBeginTransformFeedback(int primitiveMode);
        void GLEndTransformFeedback();
        void GLBindBufferRange(int target, uint index, uint buffer, int offset, int size);
        void GLBindBufferBase(int target, uint index, uint buffer);
        void GLTransformFeedbackVaryings(uint program, string[] varyings, int bufferMode);
        void GLVertexAttribIPointer(uint index, int size, int type, int stride, IntPtr offset);
        void GLGetVertexAttribIiv(uint index, int pname, ref int @params);
        void GLGetVertexAttribIuiv(uint index, int pname, ref uint @params);
        void GLVertexAttribI4i(uint index, int x, int y, int z, int w);
        void GLVertexAttribI4ui(uint index, uint x, uint y, uint z, uint w);
        void GLGetUniformuiv(uint program, int location, Span<uint> @params);
        int GLGetFragDataLocation(uint program, string name);
        void GLUniform1uiv(int location, ReadOnlySpan<uint> value);
        void GLUniform3uiv(int location, ReadOnlySpan<uint> value);
        void GLUniform4uiv(int location, ReadOnlySpan<uint> value);
        void GLClearBufferiv(int buffer, int drawbuffer, ReadOnlySpan<int> value);
        void GLClearBufferuiv(int buffer, int drawbuffer, ReadOnlySpan<uint> value);
        void GLClearBufferfv(int buffer, int drawbuffer, ReadOnlySpan<float> value);
        void GLClearBufferfi(int buffer, int drawbuffer, float depth, int stencil);
        string GLGetStringi(int name, uint index);
        void GLCopyBufferSubData(int readTarget, int writeTarget, int readOffset, int writeOffset, int size);
        uint[] GLGetUniformIndices(uint program, params string[] uniformNames);
        int[] GLGetActiveUniformsiv(
            uint program,
            int pname,
            params ReadOnlySpan<uint> uniformIndices);
        uint GLGetUniformBlockIndex(uint program, string uniformBlockName);
        void GLGetActiveUniformBlockiv(uint program, uint uniformBlockIndex, int pname, ref int @params);
        string GLGetActiveUniformBlockName(uint program, uint uniformBlockIndex);
        void GLUniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding);
        void GLDrawArraysInstanced(int mode, int first, int count, int instanceCount);
        void GLDrawElementsInstanced(int mode, int count, int type, nint indicesOffset, int instanceCount);
        void GLGetInteger64v(int pname, ref long @params);
        void GLGetBufferParameteri64v(int target, int pname, ref long @params);
        uint[] GLGenSamplers(int count);
        void GLDeleteSamplers(uint[] samplers);
        bool GLIsSampler(uint sampler);
        void GLBindSampler(uint unit, uint sampler);
        void GLSamplerParameteri(uint sampler, int pname, int param);
        void GLSamplerParameteriv(uint sampler, int pname, ReadOnlySpan<int> param);
        void GLSamplerParameterf(uint sampler, int pname, float param);
        void GLSamplerParameterfv(uint sampler, int pname, ReadOnlySpan<float> param);
        void GLGetSamplerParameteriv(uint sampler, int pname, ref int @params);
        void GLGetSamplerParameterfv(uint sampler, int pname, ref float @params);
        void GLVertexAttribDivisor(uint index, uint divisor);
        void GLBindTransformFeedback(int target, uint id);
        void GLDeleteTransformFeedbacks(params uint[] ids);
        uint[] GLGenTransformFeedbacks(int n);
        bool GLIsTransformFeedback(uint id);
        void GLPauseTransformFeedback();
        void GLResumeTransformFeedback();
        void GLProgramParameteri(uint program, int pname, int value);
        void GLInvalidateFramebuffer(int target, int numAttachments, ReadOnlySpan<int> attachments);
        void GLInvalidateSubFramebuffer(int target, int numAttachments, ReadOnlySpan<int> attachments, int x, int y, int width, int height);
    }
}
