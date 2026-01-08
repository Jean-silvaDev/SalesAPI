using Application.Helper;
using Infrastructure.Helper;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options => options
        .WithTitle("Sales API - Monolítico")
        .WithTheme(ScalarTheme.Moon)
        .WithDefaultHttpClient(target: ScalarTarget.CSharp, client: ScalarClient.AsyncHttp)
        .WithBaseServerUrl("https://localhost:7237")  // define server externo
    );

}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();