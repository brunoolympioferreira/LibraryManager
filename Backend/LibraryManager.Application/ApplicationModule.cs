using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Application;
public static class ApplicationModule
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddServices(services);
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services;
    }

}
