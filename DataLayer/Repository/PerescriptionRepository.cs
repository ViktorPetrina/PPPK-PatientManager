using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class PerescriptionRepository : IRepository<Perescription>
    {
        private readonly PatientManagerContext _context;

        public PerescriptionRepository(PatientManagerContext context)
        {
            _context = context;
        }

        public void Add(Perescription entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Perescription Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Perescription> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(long id, Perescription entity)
        {
            throw new NotImplementedException();
        }
    }
}
