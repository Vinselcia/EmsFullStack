using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmsFullStackApplication.Models;

namespace EmsFullStackApplication.Data
{
    public class fullprofileDbContext : DbContext
    {
        public fullprofileDbContext (DbContextOptions<fullprofileDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmsFullStackApplication.Models.DeptMaster> DeptMaster { get; set; } = default!;
    }
}
