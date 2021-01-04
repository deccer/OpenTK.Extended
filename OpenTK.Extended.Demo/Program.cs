using System;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddSingleton<GameSettings>(new GameSettings(1280, 720, false));
            services.AddSingleton<DemoGame>();
            return services.BuildServiceProvider();
        }
    }
}