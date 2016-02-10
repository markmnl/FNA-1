using Microsoft.Xna.Framework.Graphics;
using System;

namespace Microsoft.Xna.Framework.src.Graphics
{
    internal class FakeGLEffect : IGLEffect
    {
        public IntPtr EffectData { get; private set; }
        public IntPtr GLEffectData { get; private set; }

        public FakeGLEffect(IntPtr effect, IntPtr glEffect)
        {
            EffectData = effect;
            GLEffectData = glEffect;
        }
    }

    internal class FakeGLBackBuffer : IGLBackbuffer
    {
        public DepthFormat DepthFormat { get; private set; }
        public int Height { get; private set; }
        public int MultiSampleCount { get; private set; }
        public int Width { get; private set; }

        public void ResetFramebuffer(PresentationParameters presentationParameters, bool renderTargetBound)
        {
            Width = presentationParameters.BackBufferWidth;
            Height = presentationParameters.BackBufferHeight;
        }
    }

    internal class FakeGLDevice : IGLDevice
    {
        private class FakeGLRenderbuffer : IGLRenderbuffer
        {
            public uint Handle { get; private set; }
            public FakeGLRenderbuffer(uint handle)
            {
                Handle = handle;
            }
        }

        private class FakeGLBuffer : IGLBuffer
        {
            public static readonly FakeGLBuffer NullBuffer = new FakeGLBuffer();

            public uint Handle { get; private set; }
            public IntPtr BufferSize { get; private set; }
            public GLenum Dynamic { get; private set; }

            public FakeGLBuffer(uint handle, IntPtr bufferSize, GLenum dynamic)
            {
                Handle = handle;
                BufferSize = bufferSize;
                Dynamic = dynamic;
            }

            private FakeGLBuffer()
            {
                Handle = 0;
            }
        }

        private class FakeGLTexture : IGLTexture
        {
            public static readonly FakeGLTexture NullTexture = new FakeGLTexture();

            public uint Handle { get; private set; }
            public GLenum Target { get; private set; }
            public bool HasMipmaps { get; private set; }

            public TextureAddressMode WrapS;
            public TextureAddressMode WrapT;
            public TextureAddressMode WrapR;
            public TextureFilter Filter;
            public float Anistropy;
            public int MaxMipmapLevel;
            public float LODBias;

            public FakeGLTexture(uint handle, GLenum target, int levelCount)
            {
                Handle = handle;
                Target = target;
                HasMipmaps = levelCount > 1;

                WrapS = TextureAddressMode.Wrap;
                WrapT = TextureAddressMode.Wrap;
                WrapR = TextureAddressMode.Wrap;
                Filter = TextureFilter.Linear;
                Anistropy = 4.0f;
                MaxMipmapLevel = 0;
                LODBias = 0.0f;
            }

            private FakeGLTexture()
            {
                Handle = 0;
                Target = GLenum.GL_TEXTURE_2D;
            }
        }

        private class FakeGLQuery : IGLQuery
        {
            public uint Handle { get; private set; }
            public FakeGLQuery(uint handle) { Handle = handle; }
        }

        private PresentationParameters presentationParameters;

        public FakeGLDevice(PresentationParameters presentationParams)
        {
            this.presentationParameters = presentationParams;
        }

        public IGLBackbuffer Backbuffer { get; private set; }
        public Color BlendFactor { get; set; }
        public int MaxMultiSampleCount { get; private set; }
        public int MaxTextureSlots { get; private set; }
        public int MultiSampleMask { get; set; }
        public int ReferenceStencil { get; set; }
        public bool SupportsDxt1 { get; private set; }
        public bool SupportsHardwareInstancing { get; private set; }
        public bool SupportsS3tc { get; private set; }

        public void AddDisposeEffect(IGLEffect effect) { }
        public void AddDisposeIndexBuffer(IGLBuffer buffer) { }
        public void AddDisposeQuery(IGLQuery query) { }
        public void AddDisposeRenderbuffer(IGLRenderbuffer renderbuffer) { }
        public void AddDisposeTexture(IGLTexture texture) { }
        public void AddDisposeVertexBuffer(IGLBuffer buffer) { }
        public void ApplyEffect(IGLEffect effect, IntPtr technique, uint pass, ref MojoShader.MOJOSHADER_effectStateChanges stateChanges) { }
        public void ApplyRasterizerState(RasterizerState rasterizerState, bool renderTargetBound) { }
        public void ApplyVertexAttributes(VertexDeclaration vertexDeclaration, IntPtr ptr, int vertexOffset) { }
        public void ApplyVertexAttributes(VertexBufferBinding[] bindings, int numBindings, bool bindingsUpdated, int baseVertex) { }
        public void BeginPassRestore(IGLEffect effect, ref MojoShader.MOJOSHADER_effectStateChanges changes) { }
        public void Clear(ClearOptions options, Vector4 color, float depth, int stencil) { }
        public IGLEffect CloneEffect(IGLEffect effect)
        {
            return new FakeGLEffect(IntPtr.Zero, IntPtr.Zero);
        }
        public IGLEffect CreateEffect(byte[] effectCode)
        {
            return new FakeGLEffect(IntPtr.Zero, IntPtr.Zero);
        }
        public IGLQuery CreateQuery()
        {
            return new FakeGLQuery(0);
        }
        public IGLTexture CreateTexture2D(SurfaceFormat format, int width, int height, int levelCount)
        {
            return FakeGLTexture.NullTexture;
        }
        public IGLTexture CreateTexture3D(SurfaceFormat format, int width, int height, int depth, int levelCount)
        {
            return FakeGLTexture.NullTexture;
        }
        public IGLTexture CreateTextureCube(SurfaceFormat format, int size, int levelCount)
        {
            return FakeGLTexture.NullTexture;
        }
        public void Dispose() { }
        public void DrawIndexedPrimitives(PrimitiveType primitiveType, int baseVertex, int minVertexIndex, int numVertices, int startIndex, int primitiveCount, IndexBuffer indices) { }
        public void DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int minVertexIndex, int numVertices, int startIndex, int primitiveCount, int instanceCount, IndexBuffer indices) { }
        public void DrawPrimitives(PrimitiveType primitiveType, int vertexStart, int primitiveCount) { }
        public void DrawUserIndexedPrimitives(PrimitiveType primitiveType, IntPtr vertexData, int vertexOffset, int numVertices, IntPtr indexData, int indexOffset, IndexElementSize indexElementSize, int primitiveCount) { }
        public void DrawUserPrimitives(PrimitiveType primitiveType, IntPtr vertexData, int vertexOffset, int primitiveCount) { }
        public void EndPassRestore(IGLEffect effect) { }
        public IGLBuffer GenIndexBuffer(bool dynamic, int indexCount, IndexElementSize indexElementSize)
        {
            return FakeGLBuffer.NullBuffer;
        }
        public IGLRenderbuffer GenRenderbuffer(int width, int height, DepthFormat format, int multiSampleCount)
        {
            return new FakeGLRenderbuffer(0);
        }
        public IGLRenderbuffer GenRenderbuffer(int width, int height, SurfaceFormat format, int multiSampleCount)
        {
            return new FakeGLRenderbuffer(0);
        }
        public IGLBuffer GenVertexBuffer(bool dynamic, int vertexCount, int vertexStride)
        {
            return new FakeGLBuffer(0, (IntPtr)(vertexStride * vertexCount), dynamic ? GLenum.GL_STREAM_DRAW: GLenum.GL_STATIC_DRAW);
        }
        public void GetIndexBufferData<T>(IGLBuffer buffer, int offsetInBytes, T[] data, int startIndex, int elementCount) where T : struct { }
        public void GetTextureData2D<T>(IGLTexture texture, SurfaceFormat format, int width, int height, int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct { }
        public void GetTextureDataCube<T>(IGLTexture texture, SurfaceFormat format, int size, CubeMapFace cubeMapFace, int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct { }
        public void GetVertexBufferData<T>(IGLBuffer buffer, int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride) where T : struct { }
        public void QueryBegin(IGLQuery query) { }
        public bool QueryComplete(IGLQuery query)
        {
            throw new NotImplementedException();
        }
        public void QueryEnd(IGLQuery query) { }
        public int QueryPixelCount(IGLQuery query)
        {
            throw new NotImplementedException();
        }
        public void ReadBackbuffer<T>(T[] data, int startIndex, int elementCount, Rectangle? rect) where T : struct { }
        public void ResetBackbuffer(PresentationParameters presentationParameters, bool renderTargetBound) { }
        public void ResolveTarget(RenderTargetBinding target) { }
        public void SetBlendState(BlendState blendState) { }
        public void SetDepthStencilState(DepthStencilState depthStencilState) { }
        public void SetIndexBufferData<T>(IGLBuffer buffer, int offsetInBytes, T[] data, int startIndex, int elementCount, SetDataOptions options) where T : struct { }
        public void SetRenderTargets(RenderTargetBinding[] renderTargets, IGLRenderbuffer renderbuffer, DepthFormat depthFormat) { }
        public void SetScissorRect(Rectangle scissorRect, bool renderTargetBound) { }
        public void SetStringMarker(string text) { }
        public void SetTextureData2D<T>(IGLTexture texture, SurfaceFormat format, int x, int y, int w, int h, int level, T[] data, int startIndex, int elementCount) where T : struct { }
        public void SetTextureData2DPointer(Texture2D texture, IntPtr ptr) { }
        public void SetTextureData3D<T>(IGLTexture texture, SurfaceFormat format, int level, int left, int top, int right, int bottom, int front, int back, T[] data, int startIndex, int elementCount) where T : struct { }
        public void SetTextureDataCube<T>(IGLTexture texture, SurfaceFormat format, int xOffset, int yOffset, int width, int height, CubeMapFace cubeMapFace, int level, T[] data, int startIndex, int elementCount) where T : struct { }
        public void SetVertexBufferData<T>(IGLBuffer buffer, int elementSizeInBytes, int offsetInBytes, T[] data, int startIndex, int elementCount, SetDataOptions options) where T : struct { }
        public void SetViewport(Viewport vp, bool renderTargetBound) { }
        public void SwapBuffers(Rectangle? sourceRectangle, Rectangle? destinationRectangle, IntPtr overrideWindowHandle) { }
        public void VerifySampler(int index, Texture texture, SamplerState sampler) { }

        internal enum GLenum : int
        {
            // Hint Enum Value
            GL_DONT_CARE = 0x1100,
            // 0/1
            GL_ZERO = 0x0000,
            GL_ONE = 0x0001,
            // Types
            GL_BYTE = 0x1400,
            GL_UNSIGNED_BYTE = 0x1401,
            GL_SHORT = 0x1402,
            GL_UNSIGNED_SHORT = 0x1403,
            GL_UNSIGNED_INT = 0x1405,
            GL_FLOAT = 0x1406,
            GL_HALF_FLOAT = 0x140B,
            GL_UNSIGNED_SHORT_4_4_4_4 = 0x8033,
            GL_UNSIGNED_SHORT_5_5_5_1 = 0x8034,
            GL_UNSIGNED_INT_10_10_10_2 = 0x8036,
            GL_UNSIGNED_SHORT_5_6_5 = 0x8363,
            GL_UNSIGNED_INT_24_8 = 0x84FA,
            // Strings
            GL_VENDOR = 0x1F00,
            GL_RENDERER = 0x1F01,
            GL_VERSION = 0x1F02,
            GL_EXTENSIONS = 0x1F03,
            // Clear Mask
            GL_COLOR_BUFFER_BIT = 0x4000,
            GL_DEPTH_BUFFER_BIT = 0x0100,
            GL_STENCIL_BUFFER_BIT = 0x0400,
            // Enable Caps
            GL_SCISSOR_TEST = 0x0C11,
            GL_DEPTH_TEST = 0x0B71,
            GL_STENCIL_TEST = 0x0B90,
            // Polygons
            GL_LINE = 0x1B01,
            GL_FILL = 0x1B02,
            GL_CW = 0x0900,
            GL_CCW = 0x0901,
            GL_FRONT = 0x0404,
            GL_BACK = 0x0405,
            GL_FRONT_AND_BACK = 0x0408,
            GL_CULL_FACE = 0x0B44,
            GL_POLYGON_OFFSET_FILL = 0x8037,
            // Texture Type
            GL_TEXTURE_2D = 0x0DE1,
            GL_TEXTURE_3D = 0x806F,
            GL_TEXTURE_CUBE_MAP = 0x8513,
            GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515,
            // Blend Mode
            GL_BLEND = 0x0BE2,
            GL_SRC_COLOR = 0x0300,
            GL_ONE_MINUS_SRC_COLOR = 0x0301,
            GL_SRC_ALPHA = 0x0302,
            GL_ONE_MINUS_SRC_ALPHA = 0x0303,
            GL_DST_ALPHA = 0x0304,
            GL_ONE_MINUS_DST_ALPHA = 0x0305,
            GL_DST_COLOR = 0x0306,
            GL_ONE_MINUS_DST_COLOR = 0x0307,
            GL_SRC_ALPHA_SATURATE = 0x0308,
            GL_CONSTANT_COLOR = 0x8001,
            GL_ONE_MINUS_CONSTANT_COLOR = 0x8002,
            // Equations
            GL_MIN = 0x8007,
            GL_MAX = 0x8008,
            GL_FUNC_ADD = 0x8006,
            GL_FUNC_SUBTRACT = 0x800A,
            GL_FUNC_REVERSE_SUBTRACT = 0x800B,
            // Comparisons
            GL_NEVER = 0x0200,
            GL_LESS = 0x0201,
            GL_EQUAL = 0x0202,
            GL_LEQUAL = 0x0203,
            GL_GREATER = 0x0204,
            GL_NOTEQUAL = 0x0205,
            GL_GEQUAL = 0x0206,
            GL_ALWAYS = 0x0207,
            // Stencil Operations
            GL_INVERT = 0x150A,
            GL_KEEP = 0x1E00,
            GL_REPLACE = 0x1E01,
            GL_INCR = 0x1E02,
            GL_DECR = 0x1E03,
            GL_INCR_WRAP = 0x8507,
            GL_DECR_WRAP = 0x8508,
            // Wrap Modes
            GL_REPEAT = 0x2901,
            GL_CLAMP_TO_EDGE = 0x812F,
            GL_MIRRORED_REPEAT = 0x8370,
            // Filters
            GL_NEAREST = 0x2600,
            GL_LINEAR = 0x2601,
            GL_NEAREST_MIPMAP_NEAREST = 0x2700,
            GL_NEAREST_MIPMAP_LINEAR = 0x2702,
            GL_LINEAR_MIPMAP_NEAREST = 0x2701,
            GL_LINEAR_MIPMAP_LINEAR = 0x2703,
            // Attachments
            GL_COLOR_ATTACHMENT0 = 0x8CE0,
            GL_DEPTH_ATTACHMENT = 0x8D00,
            GL_STENCIL_ATTACHMENT = 0x8D20,
            GL_DEPTH_STENCIL_ATTACHMENT = 0x821A,
            // Texture Formats
            GL_RED = 0x1903,
            GL_RGB = 0x1907,
            GL_RGBA = 0x1908,
            GL_LUMINANCE = 0x1909,
            GL_LUMINANCE8 = 0x8040,
            GL_RGB8 = 0x8051,
            GL_RGBA8 = 0x8058,
            GL_RGBA4 = 0x8056,
            GL_RGB5_A1 = 0x8057,
            GL_RGB10_A2_EXT = 0x8059,
            GL_RGBA16 = 0x805B,
            GL_BGRA = 0x80E1,
            GL_DEPTH_COMPONENT16 = 0x81A5,
            GL_DEPTH_COMPONENT24 = 0x81A6,
            GL_RG = 0x8227,
            GL_RG8 = 0x822B,
            GL_RG16 = 0x822C,
            GL_R16F = 0x822D,
            GL_R32F = 0x822E,
            GL_RG16F = 0x822F,
            GL_RG32F = 0x8230,
            GL_RGBA32F = 0x8814,
            GL_RGBA16F = 0x881A,
            GL_DEPTH24_STENCIL8 = 0x88F0,
            GL_COMPRESSED_TEXTURE_FORMATS = 0x86A3,
            GL_COMPRESSED_RGBA_S3TC_DXT1_EXT = 0x83F1,
            GL_COMPRESSED_RGBA_S3TC_DXT3_EXT = 0x83F2,
            GL_COMPRESSED_RGBA_S3TC_DXT5_EXT = 0x83F3,
            // Texture Internal Formats
            GL_DEPTH_COMPONENT = 0x1902,
            GL_DEPTH_STENCIL = 0x84F9,
            // Textures
            GL_TEXTURE_WRAP_S = 0x2802,
            GL_TEXTURE_WRAP_T = 0x2803,
            GL_TEXTURE_WRAP_R = 0x8072,
            GL_TEXTURE_MAG_FILTER = 0x2800,
            GL_TEXTURE_MIN_FILTER = 0x2801,
            GL_TEXTURE_MAX_ANISOTROPY_EXT = 0x84FE,
            GL_TEXTURE_BASE_LEVEL = 0x813C,
            GL_TEXTURE_MAX_LEVEL = 0x813D,
            GL_TEXTURE_LOD_BIAS = 0x8501,
            GL_UNPACK_ALIGNMENT = 0x0CF5,
            // Multitexture
            GL_TEXTURE0 = 0x84C0,
            GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872,
            GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C,
            // Buffer objects
            GL_ARRAY_BUFFER = 0x8892,
            GL_ELEMENT_ARRAY_BUFFER = 0x8893,
            GL_STREAM_DRAW = 0x88E0,
            GL_STATIC_DRAW = 0x88E4,
            GL_MAX_VERTEX_ATTRIBS = 0x8869,
            // Render targets
            GL_FRAMEBUFFER = 0x8D40,
            GL_READ_FRAMEBUFFER = 0x8CA8,
            GL_DRAW_FRAMEBUFFER = 0x8CA9,
            GL_RENDERBUFFER = 0x8D41,
            GL_MAX_DRAW_BUFFERS = 0x8824,
            // Draw Primitives
            GL_LINES = 0x0001,
            GL_LINE_STRIP = 0x0003,
            GL_TRIANGLES = 0x0004,
            GL_TRIANGLE_STRIP = 0x0005,
            // Query Objects
            GL_QUERY_RESULT = 0x8866,
            GL_QUERY_RESULT_AVAILABLE = 0x8867,
            GL_SAMPLES_PASSED = 0x8914,
            // Multisampling
            GL_MULTISAMPLE = 0x809D,
            GL_MAX_SAMPLES = 0x8D57,
            GL_SAMPLE_MASK = 0x8E51,
            // 3.2 Core Profile
            GL_NUM_EXTENSIONS = 0x821D,
            // Source Enum Values
            GL_DEBUG_SOURCE_API_ARB = 0x8246,
            GL_DEBUG_SOURCE_WINDOW_SYSTEM_ARB = 0x8247,
            GL_DEBUG_SOURCE_SHADER_COMPILER_ARB = 0x8248,
            GL_DEBUG_SOURCE_THIRD_PARTY_ARB = 0x8249,
            GL_DEBUG_SOURCE_APPLICATION_ARB = 0x824A,
            GL_DEBUG_SOURCE_OTHER_ARB = 0x824B,
            // Type Enum Values
            GL_DEBUG_TYPE_ERROR_ARB = 0x824C,
            GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR_ARB = 0x824D,
            GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR_ARB = 0x824E,
            GL_DEBUG_TYPE_PORTABILITY_ARB = 0x824F,
            GL_DEBUG_TYPE_PERFORMANCE_ARB = 0x8250,
            GL_DEBUG_TYPE_OTHER_ARB = 0x8251,
            // Severity Enum Values
            GL_DEBUG_SEVERITY_HIGH_ARB = 0x9146,
            GL_DEBUG_SEVERITY_MEDIUM_ARB = 0x9147,
            GL_DEBUG_SEVERITY_LOW_ARB = 0x9148,
            GL_DEBUG_SEVERITY_NOTIFICATION_ARB = 0x826B
        }
    }
}
