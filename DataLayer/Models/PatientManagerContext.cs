using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataLayer.Models
{
    public class PatientManagerContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<ExaminationType> ExaminationTypes { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Perescription> Perescriptions { get; set; }

        private readonly string connectionString;

        public PatientManagerContext()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            connectionString = configuration.GetConnectionString("connection");
        }

        public PatientManagerContext(DbContextOptions<PatientManagerContext> options)
            : base(options)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            connectionString = configuration.GetConnectionString("connection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExaminationType>(entity =>
            {
                entity.HasData(
                    ExaminationType.GP,
                    ExaminationType.KRV,
                    ExaminationType.XRAY,
                    ExaminationType.CT,
                    ExaminationType.MR,
                    ExaminationType.ULTRA,
                    ExaminationType.ECG,
                    ExaminationType.ECHO,
                    ExaminationType.EYE,
                    ExaminationType.DERM,
                    ExaminationType.DENTA,
                    ExaminationType.MAMMO,
                    ExaminationType.NEURO
                );
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasData(
                    Gender.Male,
                    Gender.Female
                );
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
