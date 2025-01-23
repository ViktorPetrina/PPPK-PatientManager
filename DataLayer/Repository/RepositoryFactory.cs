using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    //public static class RepositoryFactory
    //{
    //    private static readonly Exception invalid_repo_exception = new NotImplementedException("No repository found for the given type.");



    //    public static IRepository<T> CreateRepository<T>() where T : class
    //    {
    //        if (typeof(T) == typeof(Patient))
    //        {
    //            return new PatientRepository(new PatientManagerContext()) as IRepository<T> ?? throw invalid_repo_exception;
    //        }
    //        else if (typeof(T) == typeof(Diagnosis))
    //        {
    //            return new DiagnosisRepository(new PatientManagerContext()) as IRepository<T> ?? throw invalid_repo_exception;
    //        }

    //        throw invalid_repo_exception;
    //    }
    //}
}
