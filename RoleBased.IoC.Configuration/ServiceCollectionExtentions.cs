using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoleBased.Infrastructure.Persistance;
using FluentValidation;
using RoleBased.Core;
using MediatR;
using RoleBased.Core.Behavior;
using RoleBased.Core.Mapping;
using RoleBased.Repository.Concrete;
using RoleBased.Repository.Interface;

namespace RoleBased.IoC.Configuration;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection MapCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ReoleBasedDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("default")));

        services.AddDbContext<ReoleBasedDbContext>(option => option.UseSqlServer
        (configuration.GetConnectionString("default")));
        services.AddAutoMapper(typeof(MappingExtension).Assembly);
        services.AddTransient<IStudentInfoRepository, StudentInfoRepository>();

        services.AddTransient<ILoginDbRepository, LoginDbRepository>();


        services.AddValidatorsFromAssembly(typeof(ICore).Assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });
        return services;
    }
}
