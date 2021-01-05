using System;
using Microsoft.Extensions.Logging;
using OpenTK.Extended.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenTK.Extended.Demo
{
    public class DemoGame : Game
    {
        private InputLayout _positionColorInputLayout;
        private ShaderProgram _simpleShaderProgram;
        private Mesh _simpleMesh;
        private ConstantBuffer _constantBuffer;
        private bool _firstMove = true;
        private Vector2 _mouseLastPosition;

        public DemoGame(ILogger<DemoGame> logger, IServiceProvider serviceProvider, GameSettings gameSettings)
            : base(logger, serviceProvider, gameSettings)
        {
            Window.Title = "OpenTK.Extended.Demo";
        }

        protected override void Load()
        {
            _positionColorInputLayout = InputLayoutFactory.CreateInputLayout(VertexType.PositionColor);

            var vs = @"
#version 430 core

out gl_PerVertex
{ 
    vec4 gl_Position; 
};

layout (location = 0) in vec3 i_position;
layout (location = 1) in vec3 i_color;

layout (std140, binding = 0) uniform Matrices
{
	mat4 u_mvp;
};
  
out vec4 ps_vertex_color;

void main()
{
    gl_Position = u_mvp * vec4(i_position, 1.0);
    ps_vertex_color = vec4(i_color, 1.0);
}";
            var fs = @"
#version 430 core

out vec4 o_frag_color;
  
in vec4 ps_vertex_color;

void main()
{
    o_frag_color = ps_vertex_color;
}";
            Logger.LogDebug("Create Shader...");
            _simpleShaderProgram = ShaderFactory.CreateFromString(vs, fs, out var acceptedVertexType);
            Logger.LogDebug("Create Shader...Done");
            _simpleMesh = MeshFactory.CreateUnitCubeMesh();
            _constantBuffer = ConstantBuffer.Create(Matrix4.Identity);

            Camera = new Camera(Vector3.UnitZ * 10, Window.Size.X / (float)Window.Size.Y);

            GL.Viewport(0, 0, Window.Size.X, Window.Size.Y);
            GL.Enable(EnableCap.DepthTest);
            GL.FrontFace(FrontFaceDirection.Ccw);
            GL.CullFace(CullFaceMode.Back);
        }

        protected override void Render(FrameEventArgs e)
        {
            GL.ClearColor(0.25f, 0.5f, 0.5f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            _positionColorInputLayout.Use(_simpleMesh);
            _simpleShaderProgram.Use();
            //_simpleShaderProgram.SetUniform("test", new Vector4(0.5f, 00.1f, 1.1f, 0.5f));

            GL.BindBufferBase(BufferRangeTarget.UniformBuffer, 0, _constantBuffer);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            base.Render(e);
        }

        protected override void Update(FrameEventArgs e)
        {
            float cameraSpeed = 4f;
            const float sensitivity = 0.15f;

            if (Window.IsKeyDown(Keys.Escape))
            {
                Window.Close();
            }

            if (Window.IsKeyDown(Keys.LeftShift) || Window.IsKeyDown(Keys.RightShift))
            {
                cameraSpeed *= 4;
            }
            if (Window.IsKeyDown(Keys.W))
            {
                Camera.Position += Camera.Front * cameraSpeed * (float)e.Time;
            }
            if (Window.IsKeyDown(Keys.S))
            {
                Camera.Position -= Camera.Front * cameraSpeed * (float)e.Time;
            }
            if (Window.IsKeyDown(Keys.A))
            {
                Camera.Position -= Camera.Right * cameraSpeed * (float)e.Time;
            }
            if (Window.IsKeyDown(Keys.D))
            {
                Camera.Position += Camera.Right * cameraSpeed * (float)e.Time;
            }
            if (Window.IsKeyDown(Keys.Q))
            {
                Camera.Position += Camera.Up * cameraSpeed * (float)e.Time;
            }
            if (Window.IsKeyDown(Keys.Z))
            {
                Camera.Position -= Camera.Up * cameraSpeed * (float)e.Time; // Down
            }

            var mouse = Window.MouseState;

            if (_firstMove)
            {
                _mouseLastPosition = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _mouseLastPosition.X;
                var deltaY = mouse.Y - _mouseLastPosition.Y;
                _mouseLastPosition = new Vector2(mouse.X, mouse.Y);

                Camera.Yaw += deltaX * sensitivity;
                Camera.Pitch -= deltaY * sensitivity;
            }

            var mvp = Camera.GetViewMatrix() * Camera.GetProjectionMatrix();
            _constantBuffer.UpdateBuffer(mvp);

            base.Update(e);
        }

        protected override void Unload()
        {
            _simpleMesh.Dispose();
            _simpleShaderProgram.Dispose();
            _positionColorInputLayout.Dispose();
            base.Unload();
        }
    }
}