using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AddressManager.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;


services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();


builder.Services.AddControllers();

services.AddInfraStructureSwagger();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();