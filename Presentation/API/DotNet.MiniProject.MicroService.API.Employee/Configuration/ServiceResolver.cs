using DotNet.MiniAPI.MicroService.Business.Feature;
using DotNet.MiniAPI.MicroService.Models.Response;
using MediatR;

namespace DotNet.MiniAPI.MicroService.API.Employee.Configuration
{
    public class ServiceResolver
    {
        private readonly IMediator _mediator;

        public ServiceResolver(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IEnumerable<EmployeeResponse>> GetEmployees(CancellationToken cancellationToken)
         => await _mediator.Send(new GetEmployeesDataQuery(), cancellationToken);
    }
}
