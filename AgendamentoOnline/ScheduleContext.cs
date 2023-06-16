
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
                .Map<Patient>(m => m.Requires("Discriminator").HasValue((int)UserType.PATIENT))
                .Map<Doctor>(m => m.Requires("Discriminator").HasValue((int)UserType.DOCTOR))
                .Map<AdminUser>(m => m.Requires("Discriminator").HasValue((int)UserType.MASTER))
                .Map<Attendant>(m => m.Requires("Discriminator").HasValue((int)UserType.ATTENDANT));

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Apppointments { get; set; }
        public DbSet<Dates> Dates { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public ScheduleContext() : base("DbConnectionString")
        {
        }
    }
}