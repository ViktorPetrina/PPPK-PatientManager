using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ExaminationRepository : IRepository<Examination>
    {
        private const string NON_EXISTING_EXAMINATION_ERROR = "The examination with provided id does not exist.";

        private readonly PatientManagerContext _context;

        public ExaminationRepository(PatientManagerContext context)
        {
            _context = context;
        }

        public void Add(Examination entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public Examination Get(long id)
        {
            var examination = _context.Examinations?
                .Include(e => e.Type)
                .Include(e => e.Patient)
                .FirstOrDefault(e => e.Id == id);

            if (examination == null)
            {
                throw new Exception(NON_EXISTING_EXAMINATION_ERROR);
            }

            return examination;
        }

        public IEnumerable<Examination> GetAll()
        {
            return _context.Examinations ?? Enumerable.Empty<Examination>();
        }

        public void Update(long id, Examination entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
