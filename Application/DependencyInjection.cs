using Application.UseCases.Customers.CreateCustomer;
using Application.UseCases.Customers.GetAllCustomers;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Use Cases
        services.AddScoped<CreateCustomerUseCase>();
        services.AddScoped<GetAllCustomersUseCase>();

        return services;
    }
}