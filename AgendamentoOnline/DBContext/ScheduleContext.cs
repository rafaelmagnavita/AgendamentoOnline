
using AgendamentoOnline.Models;
using AgendamentoOnline.Utils.Enums;
using System.Data.Entity;

namespace AgendamentoOnline
{

    public class ScheduleContext : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Map<Client>(m => m.Requires("Discriminator").HasValue((int)UserType.Client))
                .Map<Coach>(m => m.Requires("Discriminator").HasValue((int)UserType.Coach))
                .Map<AdminUser>(m => m.Requires("Discriminator").HasValue((int)UserType.MASTER))
                .Map<Attendant>(m => m.Requires("Discriminator").HasValue((int)UserType.ATTENDANT));

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Plan> Plans { get; set; }

        public ScheduleContext() : base("DbConnectionString")
        {
        }
    }
}