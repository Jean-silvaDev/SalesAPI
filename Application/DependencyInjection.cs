using System.Reflection;
using Application.UseCases.Customers.CreateCustomer;
using Application.UseCases.Customers.DeleteCustomer;
using Application.UseCases.Customers.GetAllCustomers;
using Application.UseCases.Order.DeleteOrder;
using Application.UseCases.Order.GetAllOrders;
using Application.UseCases.Order.GetOrderById;
using Application.UseCases.Order.UpdateOrder;
using Application.UseCases.Products.CreateProduct;
using Application.UseCases.Products.DeleteCustomer;
using Application.UseCases.Products.GetAllProducts;
using Application.UseCases.Products.GetProductById;
using Application.UseCases.Products.UpdateProduct;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        #endregion

        #region UseCases
        // Customers
        services.AddScoped<CreateCustomerUseCase>();
        services.AddScoped<GetCustomerByIdUseCase>();
        services.AddScoped<GetAllCustomersUseCase>();
        services.AddScoped<UpdateCustomerUseCase>();
        services.AddScoped<DeleteCustomerUseCase>();

        // Products
        services.AddScoped<CreateProductUseCase>();
        services.AddScoped<GetProductByIdUseCase>();
        services.AddScoped<GetAllProductsUseCase>();
        services.AddScoped<UpdateProductUseCase>();
        services.AddScoped<DeleteProductUseCase>();

        // Orders
        services.AddScoped<CreateOrderUseCase>();
        services.AddScoped<GetOrderByIdUseCase>();
        services.AddScoped<GetAllOrdersUseCase>();
        services.AddScoped<UpdateOrderUseCase>();
        services.AddScoped<DeleteOrderUseCase>();
        #endregion

        return services;
    }
}