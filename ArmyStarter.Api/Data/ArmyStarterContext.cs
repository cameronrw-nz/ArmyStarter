using System.Linq;
using ArmyStarter.Models;
using Microsoft.EntityFrameworkCore;

namespace ArmyStarter.Api.Data
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
            return PlanArmy.Include(e => e.PlanUnits).ThenInclude(e => e.Options).ToList();
        }

        public object GetAllArmyContent()
        {
            return Army.Include(e => e.AvailableUnits).ThenInclude(e => e.Models).ToList();
        }

        public DbSet<PlanArmy> PlanArmy { get; set; }

        public DbSet<PlanUnit> PlanArmyUnit { get; set; }

        public DbSet<Army> Army { get; set; }
    }
}
