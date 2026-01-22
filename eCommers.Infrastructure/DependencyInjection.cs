using eCommers.Domain.RepositoryContracts;
using eCommers.Infrastructure.DbContext;
using eCommers.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommers.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<DapperDbContext>();
            return services;
        }
    }
}