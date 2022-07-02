using DashboardPanel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardPanel.Contexts
{
    public class GrafikDbContext:DbContext
    {
        public GrafikDbContext(DbContextOptions<GrafikDbContext> options):base(options)
        {

        }
        public DbSet<Grafik> Grafiks { get; set; }

        public DbSet<GrafikData> GrafikDatas { get; set; }

    }
}
