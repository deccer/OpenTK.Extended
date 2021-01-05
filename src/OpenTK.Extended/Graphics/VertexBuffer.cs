using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL4;

namespace OpenTK.Extended.Graphics
{
    public class VertexBuffer : IDisposable
    {
        private readonly int _nativeHandle;

        public static VertexBuffer Create<T>(T[] vertices)
            where T : struct
        {
            var buffer = new VertexBuffer();
            buffer.Initialize(vertices);
            return buffer;
        }

        public static implicit operator int(VertexBuffer vertexBuffer)
        {
            return vertexBuffer._nativeHandle;
        }

        public int VertexStride { get; private set; }

        public void Dispose()
        {
            GL.DeleteBuffer(_nativeHandle);
        }

        private VertexBuffer()
        {
            GL.GenBuffers(1, out _nativeHandle);
        }

        private void Initialize<T>(T[] vertices) where T : struct
        {
            VertexStride = Marshal.SizeOf<T>();
            var size = vertices.Length * VertexStride;
            GL.BindBuffer(BufferTarget.ArrayBuffer, _nativeHandle);
            GL.BufferData(BufferTarget.ArrayBuffer, size, vertices, BufferUsageHint.StaticDraw);
        }
    }
}