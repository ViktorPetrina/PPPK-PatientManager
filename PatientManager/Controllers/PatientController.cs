using AutoMapper;
using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManager.ViewModels;

// TODO:
// popravi postojeci oib

namespace PatientManager.Controllers
{
    public class PatientController : Controller
    {
        private const string INVALID_OIB_ERROR_KEY = "Invalid OIB";
        private const string EXISTING_OIB_ERROR = "Patient with the same OIB already exists.";

        private readonly IRepository<Patient> _patientRepo;
        private readonly IMapper _mapper;

        public PatientController(IMapper mapper)
        {
            _patientRepo = RepositoryFactory.CreateRepository<Patient>();
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var patientVms = _mapper.Map<IEnumerable<PatientVM>>(_patientRepo.GetAll());

            return View(patientVms);
        }

        public ActionResult Details(int id)
        {
            var patient = _patientRepo.Get(id);
            var patientVm = _mapper.Map<PatientVM>(patient);

            return View(patientVm);
        }

        public ActionResult Create()
        {
            var patient = new PatientVM();
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientVM patientVm)
        {
            try
            {
                CheckOib(patientVm);

                var patient = _mapper.Map<Patient>(patientVm);
                _patientRepo.Add(patient);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var patient = _mapper.Map<PatientVM>(_patientRepo.Get(id));
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PatientVM patientVm)
        {
            try
            {
                CheckOib(patientVm);

                var patient = _mapper.Map<Patient>(patientVm);
                _patientRepo.Update(id, patient);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var patient = _mapper.Map<PatientVM>(_patientRepo.Get(id));

            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PatientVM patient)
        {
            try
            {
                _patientRepo.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private void CheckOib(PatientVM patient)
        {
            #pragma warning disable CS8602
            if (_patientRepo.GetAll().Any(p => patient.Oib.Equals(p.Oib)))
            {
                ModelState.AddModelError(INVALID_OIB_ERROR_KEY, EXISTING_OIB_ERROR);
            }
            #pragma warning restore CS8602
        }
    }
}
