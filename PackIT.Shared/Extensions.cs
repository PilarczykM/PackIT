using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstractions.Commands;
using System.Reflection;

namespace PackIT.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();
            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
            services.Scan(s => s.FromAssemblies(assemblies: assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsSelfWithInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
