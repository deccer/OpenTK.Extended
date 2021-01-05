using OpenTK.Graphics.OpenGL4;

namespace OpenTK.Extended.Graphics
{
    public class ShaderAttribute
    {
        public ShaderAttribute(
            string attributeName,
            int index,
            ActiveAttribType attributeType,
            int attributeSize)
        {
            AttributeName = attributeName;
            Index = index;
            AttributeType = attributeType;
            AttributeSize = attributeSize;
        }

        public string AttributeName { get; }

        public int Index { get; }

        public ActiveAttribType AttributeType { get; }

        public int AttributeSize { get; }
    }
}