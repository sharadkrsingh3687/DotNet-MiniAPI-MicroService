using DotNet.MiniAPI.MicroService.Models.Entities;

namespace DotNet.MiniAPI.MicroService.Persistent.Contract
{
    public interface IEmployeeDataProvider
    {
        Task<IEnumerable<Employee>> GetEmployees (CancellationToken cancellationToken);
        Task<Employee> GetEmployee (string id, CancellationToken cancellationToken);
        Task<Employee> RemoveEmployee(string id, CancellationToken cancellationToken);
        Task<Employee> SaveOrUpdateEmployee(Employee employee, CancellationToken cancellationToken);
    }
}
