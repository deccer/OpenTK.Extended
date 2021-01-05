namespace OpenTK.Extended.Graphics
{
    public interface IInputLayoutFactory
    {
        InputLayout CreateInputLayout(VertexType vertexType);
    }
}