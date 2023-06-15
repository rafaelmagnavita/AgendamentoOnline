
using AgendamentoOnline.Models;
using System.Data.Entity;

namespace AgendamentoOnline
{

    public class ScheduleContext : DbContext
    {
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