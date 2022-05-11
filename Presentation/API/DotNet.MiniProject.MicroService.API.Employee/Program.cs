using DotNet.MiniAPI.MicroService.Framework.ExceptionHandler.Middleware;
using DotNet.MiniAPI.MicroService.API.Employee.Configuration;
using Autofac.Extensions.DependencyInjection;
using Autofac;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutoFacConfigModule());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseGlobalExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.ApiMapping();

app.Run();
