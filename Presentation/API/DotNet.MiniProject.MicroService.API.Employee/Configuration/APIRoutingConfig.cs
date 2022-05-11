using DotNet.MiniAPI.MicroService.Business.Contract;
using DotNet.MiniAPI.MicroService.Business.Feature;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.MiniAPI.MicroService.API.Employee.Configuration
{
    public static class APIRoutingConfig
    {
        public static void ApiMapping(this WebApplication app)
        {
            app.MapGet("/employees", async ([FromServices] ServiceResolver resolver, CancellationToken cancellationToken) =>
            {
                var data = await resolver.GetEmployees(cancellationToken);
                return data;
            });
        }
    }
}
