using DotNet.MiniAPI.MicroService.Models.Entities;
using DotNet.MiniAPI.MicroService.Persistent.Contract;
using Microsoft.EntityFrameworkCore;


namespace DotNet.MiniAPI.MicroService.Persistent.Provider
{
    public class EmployeeDataProvider : IEmployeeDataProvider
    {
        private readonly IEmployeeDbContext _dbContext = null!;
        public EmployeeDataProvider(IEmployeeDbContext dbContext)
            => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<Employee> GetEmployee(string id, CancellationToken cancellationToken)
         => await this._dbContext.Employee.FirstOrDefaultAsync(x => x.EmployeeId.ToString().ToLower() == id.ToLower(), cancellationToken);

        public async Task<IEnumerable<Employee>> GetEmployees(CancellationToken cancellationToken)
            => await this._dbContext.Employee.ToListAsync(cancellationToken);

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
