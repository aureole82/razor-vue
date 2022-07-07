using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RazorVue.Data;

public static class DataModule
{
    /// <summary> Add data persistence layer to the application interfacing by EntityFrameworkCore. </summary>
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services
            .AddDbContext<EditorDbContext>(options =>
                options
                    .UseInMemoryDatabase("EditorDb")
                    //.UseSqlServer(builder.Configuration.GetConnectionString("EditorDbContext"))
                    .EnableSensitiveDataLogging()
            );
        return services;
    }
}