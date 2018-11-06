using Microsoft.Extensions.DependencyInjection;

namespace Vehicles.Cqrs.CommandModel
{
    // ReSharper disable once UnusedMember.Global
    public static class CommandRouterRegistrar
    {
        public static IServiceCollection AddCommandRouting(this IServiceCollection services)
        {
            CommandRouter.RegisterHandlers();

            return services;
        }
    }
}