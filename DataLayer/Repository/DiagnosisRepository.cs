using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class DiagnosisRepository : IRepository<Diagnosis>
    {
        private const string NON_EXISTING_DIAGNOSIS_ERROR = "Diagnosis with provided id does not exist.";

        private readonly PatientManagerContext _context;

        public DiagnosisRepository(PatientManagerContext context)
        {
            _context = context;
        }

        public void Add(Diagnosis entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Diagnosis Get(long id)
        {
            var diagnosis = _context.Diagnoses?
                .Include(d => d.Patient)
                .FirstOrDefault(x => x.Id == id);

            if (diagnosis == null)
            {
                throw new Exception(NON_EXISTING_DIAGNOSIS_ERROR);
            }

            return diagnosis;
        }

        public IEnumerable<Diagnosis> GetAll()
        {
            return _context.Diagnoses ?? Enumerable.Empty<Diagnosis>();
        }

        public void Update(long id, Diagnosis entity)
        {
            var diagnosis = Get(id);

            diagnosis.Name = entity.Name;
            diagnosis.Start = entity.Start;
            diagnosis.End = entity.End;

            _context.SaveChanges();
        }
    }
}
