namespace OpenTK.Extended.Graphics
{
    public interface IShaderFactory
    {
        ShaderProgram CreateFromString(string vertexShaderSource,
            string fragmentShaderSource,
            out VertexType vertexType);
    }
}