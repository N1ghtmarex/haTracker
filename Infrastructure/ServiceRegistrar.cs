using Abstractions.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceRegistrar
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IColorService, ColorService>();
        services.AddTransient<IEmojiService, EmojiService>();
        services.AddTransient<IUnitService, UnitService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ITaskService, TaskService>();
        services.AddTransient<ICompletionService, CompletionService>();

        return services;
    }
}