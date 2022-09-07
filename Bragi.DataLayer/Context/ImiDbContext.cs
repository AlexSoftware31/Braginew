using Bragi.DataLayer.Models.ImiEtickets;
using Microsoft.EntityFrameworkCore;

namespace Bragi.DataLayer.Context
{
    public class ImiDbContext : DbContext
    {
        public ImiDbContext(DbContextOptions<ImiDbContext> context): base(context){}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<T01_Etickets> T01_Etickets { get; set; }
    }
}
