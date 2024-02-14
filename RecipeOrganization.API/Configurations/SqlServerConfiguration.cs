using Microsoft.EntityFrameworkCore;
using RecipeOrganization.Infrastructure.Contract;
using RecipeOrganization.Infrastructure.Domain;
using RecipeOrganization.Infrastructure.Repositories;

namespace RecipeOrganization.API.Configurations;

public static class SqlServerConfiguration
{
    public static void AddSqlServer(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddDbContext<RecipeContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], x => x.MigrationsAssembly("RecipeOrganization.Infrastructure.Domain")));
    }
}
