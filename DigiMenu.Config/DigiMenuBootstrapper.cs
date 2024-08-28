using DigiMenu.Application._Helpers;
using DigiMenu.Application.Users;
using DigiMenu.Domain.UserAgg.Services;
using DigiMenu.Infrastracture;
using DigiMenu.Query.Categories.GetById;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DigiMenu.Config
{
    public static class DigiMenuBootstrapper
    {
        public static void RegisterDigiMenuDependency(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Initialaize(services, connectionString);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Directories).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCategoryByIdQuery).Assembly));

            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddValidatorsFromAssembly(typeof(Directories).Assembly);
        }
    }
}
