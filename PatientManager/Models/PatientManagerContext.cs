using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;

namespace PatientManager.Models
{
    public class PatientManagerContext : DbContext
    {
        public DbSet<Patient>? Patients { get; set; }

        // makni iz koda, referenciraj appsettings
        private readonly string CONNECTION_STRING = @"
            Host=faultily-neat-amphibian.data-1.use1.tembo.io;
            Port=5432;
            Username=postgres;
            Password=mC1tqbpFh1kWLf9m;
            Database=patient_manager;
            SslMode=Disable;
        ";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(CONNECTION_STRING);
        }
    }
}
