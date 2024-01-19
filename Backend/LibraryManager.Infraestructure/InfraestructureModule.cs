using LibraryManager.Core.Repositories;
using LibraryManager.Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Infraestructure;
public static class InfraestructureModule
{
    public static void AddInfraestructure(this IServiceCollection services)
    {
        var connectonString = Environment.GetEnvironmentVariable("CS_SQL_SERVER_LOCALHOST_LIBRARY_MANAGER");
        services
            .AddDb(connectonString)
            .AddRepositories();
    }

    private static IServiceCollection AddDb(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<LibraryManagerDbContext>(options => options.UseSqlServer(connectionString));
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<IBookRepository, BookRepository>();
        return services;
    }
}
