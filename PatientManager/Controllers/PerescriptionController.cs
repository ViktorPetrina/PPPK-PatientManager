using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace PatientManager.Controllers
{
    public class PerescriptionController : Controller
    {
        private readonly IRepository<Patient> _patientRepo;
        private readonly IRepository<Perescription> _perescriptionRepo;

        public PerescriptionController(IRepository<Perescription> perescriptionRepo, IRepository<Patient> patientRepo)
        {
            _perescriptionRepo = perescriptionRepo;
            _patientRepo = patientRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            var p = new Perescription();
            p.PatientId = id;
            p.Start = DateOnly.FromDateTime(DateTime.Now);

            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Perescription perescription)
        {
            try
            {
                var patient = _patientRepo.Get(perescription.PatientId);
                perescription.Id = 0;
                _perescriptionRepo.Add(perescription);

                return RedirectToAction("Perescriptions", "Patient", new { id = perescription.PatientId });
            }
            catch
            {
                return View();
            }
        }
    }
}
