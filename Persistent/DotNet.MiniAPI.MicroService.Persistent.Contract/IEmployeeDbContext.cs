using DotNet.MiniAPI.MicroService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.MiniAPI.MicroService.Persistent.Contract
{
    public interface IEmployeeDbContext
    {
        DbSet<Employee> Employee { get; }
    }
}
