using System.Collections.Generic;
using System.Linq;

namespace OpenTK.Extended.Graphics
{
    public static class InputLayoutMapper
    {
        private static readonly IDictionary<VertexType, string[]> _inputLayouts;

        static InputLayoutMapper()
        {
            _inputLayouts = new Dictionary<VertexType, string[]>
            {
                {
                    VertexType.Unknown, new string[] { }
                },
                {
                    VertexType.Position, new[]
                    {
                        "i_position"
                    }
                },
                {
                    VertexType.PositionColor, new[]
                    {
                        "i_position",
                        "i_color"
                    }
                },
                {
                    VertexType.PositionTexture, new[]
                    {
                        "i_position",
                        "i_uv"
                    }
                },
                {
                    VertexType.PositionTextureNormalTangent, new[]
                    {
                        "i_position",
                        "i_uv",
                        "i_normal",
                        "i_tangent"
                    }
                }
            };
        }

        public static VertexType Match(string[] attributeNames)
        {
            var attributeNamesSorted = attributeNames.OrderBy(attributeName => attributeName);
            foreach (var semanticMap in _inputLayouts)
            {
                var semanticNames = semanticMap.Value.OrderBy(attributeName => attributeName);
                if ( semanticNames.SequenceEqual(attributeNamesSorted))
                {
                    return semanticMap.Key;
                }
            }

            return VertexType.Unknown;
        }
    }
}