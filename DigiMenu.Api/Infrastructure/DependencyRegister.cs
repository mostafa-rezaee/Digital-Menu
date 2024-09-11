using DigiMenu.Api.Infrastructure.JWT;

namespace DigiMenu.Api.Infrastructure
{
    public static class DependencyRegister
    {
        public static void RegisterApiDependency(this IServiceCollection service)
        {
            service.AddTransient<CustomJwtValidation>();

            service.AddCors(options =>
            {
                options.AddPolicy(name: "Digimenu-api",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
        }

    }
}
