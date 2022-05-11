using AutoMapper;
using DotNet.MiniAPI.MicroService.Business.Contract;
using DotNet.MiniAPI.MicroService.Models.Entities;
using DotNet.MiniAPI.MicroService.Models.Response;
using DotNet.MiniAPI.MicroService.Persistent.Contract;

namespace DotNet.MiniAPI.MicroService.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDataProvider _provider;
        private readonly IMapper _mapper;

        public EmployeeService(IMapper mapper, IEmployeeDataProvider provider)
        {
            this._provider = provider;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<EmployeeResponse>> GetEmployeesAsync(CancellationToken cancellationToken)
        {
            var results = await _provider.GetEmployees(cancellationToken);
            return this._mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>(results);
        }
    }
}
