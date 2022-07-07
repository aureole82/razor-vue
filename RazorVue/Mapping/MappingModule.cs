using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace RazorVue.Mapping;

public static class MappingModule
{
    /// <summary>
    ///     Registers <see cref="IMapper" /> for automatic object mapping. Configure it like this:
    ///     <code>services.Configure&lt;MapperConfigurationExpression&gt;(config => config.CreateMap&lt;Source, Destination&gt;());</code>
    /// </summary>
    public static IServiceCollection AddMapping(this IServiceCollection services)

    {
        // Registration (almost) like https://github.com/AutoMapper/AutoMapper.Extensions.Microsoft.DependencyInjection/blob/master/src/AutoMapper.Extensions.Microsoft.DependencyInjection/ServiceCollectionExtensions.cs.
        services.AddOptions<MapperConfigurationExpression>();
        services
            .TryAddSingleton<IConfigurationProvider>(ioc =>
                new MapperConfiguration(ioc.GetRequiredService<IOptions<MapperConfigurationExpression>>().Value)
            );
        services.TryAddTransient<IMapper, Mapper>();

        return services;
    }
}