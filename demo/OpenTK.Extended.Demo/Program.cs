using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTK.Extended.Graphics;

namespace OpenTK.Extended.Demo
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = CreateServiceProvider();

            var game = serviceProvider.GetService<DemoGame>();
            game!.Run();
        }

        private static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddLogging(ConfigureLogging);
            services.AddSingleton(new GameSettings(1280, 720, false));
            services.AddSingleton<DemoGame>();
            services.AddSingleton<IShaderFactory, ShaderFactory>();
            services.AddSingleton<IInputLayoutFactory, InputLayoutFactory>();
            services.AddSingleton<IMeshFactory, MeshFactory>();
            return services.BuildServiceProvider();
        }

        private static void ConfigureLogging(ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            loggingBuilder.AddConsole();
        }
    }
}