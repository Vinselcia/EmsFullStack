using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmsFullStackApplication.Models;

namespace EmsFullStackApplication.Data
{
    public class DeptMasterContext : DbContext
    {
        public DeptMasterContext (DbContextOptions<DeptMasterContext> options)
            : base(options)
        {
        }

        public DbSet<EmsFullStackApplication.Models.DeptMaster> DeptMaster { get; set; } = default!;
    }
}
