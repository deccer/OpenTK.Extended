using System.Collections.Generic;
using System.Linq;
using OpenTK.Mathematics;

namespace OpenTK.Extended.Graphics
{
    public sealed class MeshFactory : IMeshFactory
    {
        public Mesh CreateUnitCubeMesh()
        {
            var cubeColor0 = new Vector4(112 / 256f, 53 / 256f, 63 / 256f, 1.0f);
            var cubeColor1 = new Vector4(132 / 256f, 53 / 256f, 63 / 256f, 1.0f);
            var cubeColor2 = new Vector4(152 / 256f, 53 / 256f, 63 / 256f, 1.0f);
            var cubeColor3 = new Vector4(172 / 256f, 53 / 256f, 63 / 256f, 1.0f);
            var cubeColor4 = new Vector4(192 / 256f, 53 / 256f, 63 / 256f, 1.0f);
            var cubeColor5 = new Vector4(212 / 256f, 53 / 256f, 63 / 256f, 1.0f);
            var cubeVertices = new List<VertexPositionColor>
            {
                new VertexPositionColor(new Vector3(-1.0f, -1.0f, -1.0f), cubeColor0), // Front
                new VertexPositionColor(new Vector3(-1.0f, 1.0f, -1.0f), cubeColor0),
                new VertexPositionColor(new Vector3(1.0f, 1.0f, -1.0f), cubeColor0),
                new VertexPositionColor(new Vector3(-1.0f, -1.0f, -1.0f), cubeColor0),
                new VertexPositionColor(new Vector3(1.0f, 1.0f, -1.0f), cubeColor0),
                new VertexPositionColor(new Vector3(1.0f, -1.0f, -1.0f), cubeColor0),

                new VertexPositionColor(new Vector3(-1.0f, -1.0f, 1.0f), cubeColor1), // BACK
                new VertexPositionColor(new Vector3(1.0f, 1.0f, 1.0f), cubeColor1),
                new VertexPositionColor(new Vector3(-1.0f, 1.0f, 1.0f), cubeColor1),
                new VertexPositionColor(new Vector3(-1.0f, -1.0f, 1.0f), cubeColor1),
                new VertexPositionColor(new Vector3(1.0f, -1.0f, 1.0f), cubeColor1),
                new VertexPositionColor(new Vector3(1.0f, 1.0f, 1.0f), cubeColor1),

                new VertexPositionColor(new Vector3(-1.0f, 1.0f, -1.0f), cubeColor2), // Top
                new VertexPositionColor(new Vector3(-1.0f, 1.0f, 1.0f), cubeColor2),
                new VertexPositionColor(new Vector3(1.0f, 1.0f, 1.0f), cubeColor2),
                new VertexPositionColor(new Vector3(-1.0f, 1.0f, -1.0f), cubeColor2),
                new VertexPositionColor(new Vector3(1.0f, 1.0f, 1.0f), cubeColor2),
                new VertexPositionColor(new Vector3(1.0f, 1.0f, -1.0f), cubeColor2),

                new VertexPositionColor(new Vector3(-1.0f, -1.0f, -1.0f), cubeColor3), // Bottom
                new VertexPositionColor(new Vector3(1.0f, -1.0f, 1.0f), cubeColor3),
                new VertexPositionColor(new Vector3(-1.0f, -1.0f, 1.0f), cubeColor3),
                new VertexPositionColor(new Vector3(-1.0f, -1.0f, -1.0f), cubeColor3),
                new VertexPositionColor(new Vector3(1.0f, -1.0f, -1.0f), cubeColor3),
                new VertexPositionColor(new Vector3(1.0f, -1.0f, 1.0f), cubeColor3),

                new VertexPositionColor(new Vector3(-1.0f, -1.0f, -1.0f), cubeColor4), // Left
                new VertexPositionColor(new Vector3(-1.0f, -1.0f, 1.0f), cubeColor4),
                new VertexPositionColor(new Vector3(-1.0f, 1.0f, 1.0f), cubeColor4),
                new VertexPositionColor(new Vector3(-1.0f, -1.0f, -1.0f), cubeColor4),
                new VertexPositionColor(new Vector3(-1.0f, 1.0f, 1.0f), cubeColor4),
                new VertexPositionColor(new Vector3(-1.0f, 1.0f, -1.0f), cubeColor4),

                new VertexPositionColor(new Vector3(1.0f, -1.0f, -1.0f), cubeColor5), // Right
                new VertexPositionColor(new Vector3(1.0f, 1.0f, 1.0f), cubeColor5),
                new VertexPositionColor(new Vector3(1.0f, -1.0f, 1.0f), cubeColor5),
                new VertexPositionColor(new Vector3(1.0f, -1.0f, -1.0f), cubeColor5),
                new VertexPositionColor(new Vector3(1.0f, 1.0f, -1.0f), cubeColor5),
                new VertexPositionColor(new Vector3(1.0f, 1.0f, 1.0f), cubeColor5)
            };

            var cubeVertexBuffer = VertexBuffer.Create(cubeVertices.ToArray());

            return new Mesh(cubeVertexBuffer, Enumerable.Empty<MeshPart>().ToArray(), Enumerable.Empty<Material>().ToArray());
        }
    }
}