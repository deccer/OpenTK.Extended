using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenTK.Extended.Graphics
{
    public class Mesh : IDisposable
    {
        public VertexBuffer VertexBuffer { get; }

        public ReadOnlyCollection<Material> Materials { get; }

        public ReadOnlyCollection<MeshPart> MeshParts { get; }
        
        internal Mesh(VertexBuffer vertexBuffer, IList<MeshPart> meshParts, IList<Material> materials)
        {
            Materials = new ReadOnlyCollection<Material>(materials);
            MeshParts = new ReadOnlyCollection<MeshPart>(meshParts);
            VertexBuffer = vertexBuffer;
        }

        public void Dispose()
        {
            VertexBuffer.Dispose();
        }
    }
}