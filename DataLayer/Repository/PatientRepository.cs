using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    internal class PatientRepository : IRepository<Patient>
    {
        private const string NON_EXISTING_PATIENT_ERROR = "The patient with provided id does not exist.";

        private readonly PatientManagerContext _context;

        public PatientRepository(PatientManagerContext context)
        {
            _context = context;
        }

        public void Add(Patient entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var patient = _context.Patients?.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                throw new Exception(NON_EXISTING_PATIENT_ERROR);
            }
            _context.Patients?.Remove(patient);
            _context.SaveChanges();
        }

        public Patient Get(long id)
        {
            var patient = _context.Patients?
                .Include(p => p.Examinations)
                .Include(p => p.Sex)
                .Include(p => p.MedicalHistory)
                .FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                throw new Exception(NON_EXISTING_PATIENT_ERROR);
            }

            return patient;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients ?? Enumerable.Empty<Patient>();
        }

        public void Update(long id, Patient entity)
        {
            var patient = Get(id);

            patient.FirstName = entity.FirstName;
            patient.LastName = entity.LastName;
            patient.DateOfBirth = entity.DateOfBirth;
            patient.Oib = entity.Oib;
            patient.Examinations = entity.Examinations;
            patient.MedicalHistory = entity.MedicalHistory;
            
            _context.SaveChanges();
        }
    }
}
