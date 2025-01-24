using AutoMapper;
using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using PatientManager.Utilities;

namespace PatientManager.Controllers
{
    public class ExaminationController : Controller
    {
        private readonly IRepository<Patient> _patientRepo;
        private readonly IRepository<Examination> _examinationRepo;

        public ExaminationController(IRepository<Patient> patientRepo, IRepository<Examination> diagnosisRepo)
        {
            //_patientRepo = RepositoryFactory.CreateRepository<Patient>();
            //_examinationRepo = RepositoryFactory.CreateRepository<Examination>();

            _patientRepo = patientRepo;
            _examinationRepo = diagnosisRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var examination = _examinationRepo.Get(id);

            return View(examination);
        }

        public ActionResult Create()
        {
            ViewBag.ExaminationTypeListItems = ViewUtils.GetExaminationTypeListItems();
            ViewBag.PatientListItems = ViewUtils.GetPatientListItems(_patientRepo);

            var examination = new Examination();
            examination.Date = DateTime.Now;

            return View(examination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Examination examination, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    examination.Image = memoryStream.ToArray();
                }
            }

            try
            {
                _examinationRepo.Add(examination);

                return RedirectToAction("Index", "Patient");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
