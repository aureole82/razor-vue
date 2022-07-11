using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RazorVue.Data.Models;
using RazorVue.Mapping;

namespace RazorVue.Controllers;

public static class ApiModule
{
    /// <summary> Add data persistence layer to the application interfacing by EntityFrameworkCore. </summary>
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddMapping();
        services.Configure<MapperConfigurationExpression>(Map);

        return services;
    }

    private static void Map(MapperConfigurationExpression config)
    {
        config
            .CreateMap<EditDecisionList, ListResponse>()
            ;
        config
            .CreateMap<Segment, SegmentResponse>()
            ;

        config
            .CreateMap<SegmentRequest, Segment>()
            ;
    }
}