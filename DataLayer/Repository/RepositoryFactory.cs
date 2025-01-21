using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public static class RepositoryFactory
    {
        public static IRepository<T> CreateRepository<T>() where T : class
        {
            if (typeof(T) == typeof(Patient))
            {
                return new PatientRepository(new PatientManagerContext()) as IRepository<T>
                    ?? throw new NotImplementedException("No repository found for the given type.");
            }

            throw new NotImplementedException("No repository found for the given type.");
        }
    }
}
