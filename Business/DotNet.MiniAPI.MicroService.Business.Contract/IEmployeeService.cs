using DotNet.MiniAPI.MicroService.Models.Response;

namespace DotNet.MiniAPI.MicroService.Business.Contract
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponse>> GetEmployeesAsync(CancellationToken cancellationToken);
    }
}
