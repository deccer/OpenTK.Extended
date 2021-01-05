using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

namespace OpenTK.Extended.Graphics
{
    public sealed class InputLayout : IDisposable
    {
        public static readonly InputLayout Default = new InputLayout(); // TODO(deccer) this will leak, fix me

        private readonly int _nativeHandle;

        private InputLayout()
        {
            GL.CreateVertexArrays(1, out _nativeHandle);
        }

        internal InputLayout(IEnumerable<VertexAttribute> attributes)
            : this()
        {
            foreach (var attribute in attributes)
            {
                GL.EnableVertexArrayAttrib(_nativeHandle, attribute.Index);
                GL.VertexArrayAttribFormat(_nativeHandle, attribute.Index, attribute.Components, attribute.Type, false, attribute.Offset);
                GL.VertexArrayAttribBinding(_nativeHandle, attribute.Index, 0);
            }
        }

        public void Dispose()
        {
            GL.DeleteVertexArray(_nativeHandle);
        }

        public void Use(Mesh mesh)
        {
            GL.BindVertexArray(_nativeHandle);
            GL.VertexArrayVertexBuffer(_nativeHandle, 0, mesh.VertexBuffer, IntPtr.Zero, mesh.VertexBuffer.VertexStride);
        }
    }
}