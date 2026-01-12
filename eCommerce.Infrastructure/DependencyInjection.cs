using eCommerce.Core.RepositoryContrast;
using eCommerce.Infrastructure.DBContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;
public static class DependencyInjection
  {
    public static IServiceCollection
        AddInfrastruction(this IServiceCollection services)
    {
        services.AddTransient<IUsersRepository, UserRepository>();

        services.AddTransient<DapperDbContext>();
        return services;

    }
  }
