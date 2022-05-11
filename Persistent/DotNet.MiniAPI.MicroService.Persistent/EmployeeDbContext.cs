using DotNet.MiniAPI.MicroService.Models.Entities;
using DotNet.MiniAPI.MicroService.Persistent.Contract;
using Microsoft.EntityFrameworkCore;


namespace DotNet.MiniAPI.MicroService.Persistent
{
    public class EmployeeDbContext : DbContext, IEmployeeDbContext
    {
        public DbSet<Employee> Employee => Set<Employee>();        
    }
}
