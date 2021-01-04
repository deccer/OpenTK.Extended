using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace OpenTK.Extended
{
    public class Game : IDisposable
    {
        protected Game(GameSettings gameSettings)
        {
            Window = new GameWindow(GameWindowSettings.Default, gameSettings._nativeWindowSettings);
            Window.Load += Load;
            Window.Unload += Unload;
            Window.UpdateFrame += Update;
            Window.RenderFrame += Render;

            var monitorHandle = Monitors.GetMonitorFromWindow(Window);
            if (Monitors.TryGetMonitorInfo(monitorHandle, out var monitorInfo))
            {
                var windowSize = monitorInfo.ClientArea.Size * 90 / 100;
                var windowLocation = monitorInfo.ClientArea.HalfSize - windowSize / 2;

                Window.Location = windowLocation;
                Window.Size = windowSize;
            }
        }

        protected GameWindow Window { get; }

        public void Dispose()
        {
            Window?.Dispose();
        }

        public void Run()
        {
            Window.Run();
        }

        protected virtual void Load()
        {
        }

        protected virtual void Unload()
        {

        }

        protected virtual void Update(FrameEventArgs e)
        {
        }

        protected virtual void Render(FrameEventArgs e)
        {
            Window.SwapBuffers();
        }

    }
}