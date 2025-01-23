using AutoMapper;
using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.ExaminationTypeListItems = ViewUtils.GetExaminationTypeListItems();

            var examination = new Examination();
            examination.Date = DateTime.Now;

            return View(examination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Examination examination)
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

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
