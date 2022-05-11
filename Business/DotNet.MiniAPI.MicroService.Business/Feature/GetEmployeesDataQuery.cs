using DotNet.MiniAPI.MicroService.Business.Contract;
using DotNet.MiniAPI.MicroService.Models.Response;
using MediatR;

namespace DotNet.MiniAPI.MicroService.Business.Feature
{
    public class GetEmployeesDataQuery: IRequest<IEnumerable<EmployeeResponse>>
    {

    }

    public class GetEmployeesRequestHandler: IRequestHandler<GetEmployeesDataQuery, IEnumerable<EmployeeResponse>>
    {
        private readonly IEmployeeService _service;
        public GetEmployeesRequestHandler(IEmployeeService service) => _service = service;
        
        public async Task<IEnumerable<EmployeeResponse>> Handle(GetEmployeesDataQuery request, CancellationToken cancellationToken)
        {
            var data = await this._service.GetEmployeesAsync(cancellationToken);
            return data;
        }
    }
}
