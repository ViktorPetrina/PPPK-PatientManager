using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class PatientManagerContext : DbContext
    {
        public DbSet<Patient>? Patients { get; set; }
        public DbSet<Examination>? Examinations { get; set; }
        public DbSet<ExaminationType>? ExaminationTypes { get; set; }
        public DbSet<Diagnosis>? Diagnoses { get; set; }
        public DbSet<Perescription>? Perescriptions { get; set; }

        // referenciraj appsettings
        private const string CONNECTION_STRING = @"
            Host=faultily-neat-amphibian.data-1.use1.tembo.io;
            Port=5432;Username=postgres;
            Password=mC1tqbpFh1kWLf9m;
            Database=patient_manager;
            Include Error Detail=true";

        public PatientManagerContext()
        {
        }

        public PatientManagerContext(DbContextOptions<PatientManagerContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Examination>(entity =>
            {
                entity.HasOne(e => e.Patient)
                      .WithMany(p => p.Examinations);

                entity.HasOne(e => e.Type);
            }); 

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
