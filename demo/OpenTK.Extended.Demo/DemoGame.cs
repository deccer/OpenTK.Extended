using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;

namespace OpenTK.Extended.Demo
{
    public class DemoGame : Game
    {
        public DemoGame(GameSettings gameSettings)
            : base(gameSettings)
        {
            Window.Title = "OpenTK.Extended.Demo";
        }

        protected override void Render(FrameEventArgs e)
        {
            GL.ClearColor(0.1f, 0.3f, 0.5f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            base.Render(e);
        }
    }
}