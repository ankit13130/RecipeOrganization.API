using FluentValidation.AspNetCore;
using RecipeOrganization.Core.Contract;
using RecipeOrganization.Core.Services;

namespace RecipeOrganization.API.Configurations;

public static class DependencyConfiguration
{
    public static void AddDependency(this IServiceCollection services)
    {
        services.AddScoped<IValidationServices,ValidationServices>();
        services.AddScoped<IUserServices,UserServices>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidation>());
    }
}
