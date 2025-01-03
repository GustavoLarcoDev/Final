using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioMvc.Models;

namespace PortfolioMvc.Data
{
    public class PortfolioMvcContext : DbContext
    {
        public PortfolioMvcContext (DbContextOptions<PortfolioMvcContext> options)
            : base(options)
        {
        }

        public DbSet<PortfolioMvc.Models.Projects> Projects { get; set; } = default!;
        public DbSet<PortfolioMvc.Models.PowerBi> PowerBi { get; set; } = default!;
    }
}
