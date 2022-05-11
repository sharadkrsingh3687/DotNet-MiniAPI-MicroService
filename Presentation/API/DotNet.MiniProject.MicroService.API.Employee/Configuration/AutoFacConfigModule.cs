using Autofac;
using AutoMapper;
using DotNet.MiniAPI.MicroService.Business.Contract;
using DotNet.MiniAPI.MicroService.Business.Feature;
using DotNet.MiniAPI.MicroService.Business.Services;
using DotNet.MiniAPI.MicroService.Persistent;
using DotNet.MiniAPI.MicroService.Persistent.Contract;
using DotNet.MiniAPI.MicroService.Persistent.Provider;
using MediatR;
using MediatR.Pipeline;

namespace DotNet.MiniAPI.MicroService.API.Employee.Configuration
{
    public class AutoFacConfigModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new AutoMapperConfiguration().Configure()).As<IMapper>();
            builder.Register((c) => new ServiceResolver(c.Resolve<IMediator>())).InstancePerLifetimeScope();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerLifetimeScope();
            builder.Register((c)=> new EmployeeDataProvider(c.Resolve<IEmployeeDbContext>())).As<IEmployeeDataProvider>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeDbContext>().As<IEmployeeDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>)
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder.RegisterAssemblyTypes(typeof(GetEmployeesDataQuery).Assembly)
                .AsClosedTypesOf(mediatrOpenType)
                .AsImplementedInterfaces();
            }

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
        }
    }
}
