using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmsFullStackApplication.Models;

namespace EmsFullStackApplication.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext (DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmsFullStackApplication.Models.Employee> Employee { get; set; } = default!;
    }
}
