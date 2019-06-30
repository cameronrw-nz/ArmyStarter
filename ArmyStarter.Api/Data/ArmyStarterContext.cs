using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArmyStarter.Api.Models
{
    public class ArmyStarterContext : DbContext
    {
        public ArmyStarterContext (DbContextOptions<ArmyStarterContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public object GetAllContent()
        {
            return Army.Include(e => e.ArmyUnits).ThenInclude(e => e.Options).ToList();
        }

        public DbSet<Army> Army { get; set; }

        public DbSet<ArmyUnit> ArmyUnit { get; set; }
    }
}
