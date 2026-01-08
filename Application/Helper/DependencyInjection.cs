using Microsoft.Extensions.DependencyInjection;

namespace Application.Helper;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Exemplo: registro de usecases e handlers
        // services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();

        return services;
    }
}