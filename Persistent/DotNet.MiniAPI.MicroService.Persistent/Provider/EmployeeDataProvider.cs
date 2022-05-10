using DotNet.MiniAPI.MicroService.Models.Entities;
using DotNet.MiniAPI.MicroService.Persistent.Contract;

namespace DotNet.MiniAPI.MicroService.Persistent.Provider
{
    public class EmployeeDataProvider : IEmployeeDataProvider
    {
        public Task<Employee> GetEmployee(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployees(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> RemoveEmployee(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> SaveOrUpdateEmployee(Employee employee, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
