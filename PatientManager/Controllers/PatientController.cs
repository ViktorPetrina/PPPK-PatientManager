﻿using AutoMapper;
using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatientManager.Utilities;
using PatientManager.ViewModels;
using System.Text;

// TODO:
// popravi postojeci oib

namespace PatientManager.Controllers
{
    public class PatientController : Controller
    {
        private const string INVALID_OIB_ERROR_KEY = "Invalid OIB";
        private const string EXISTING_OIB_ERROR = "Patient with the same OIB already exists.";

        private readonly IRepository<Patient> _patientRepo;
        private readonly IRepository<Diagnosis> _diagnosisRepo;
        private readonly IMapper _mapper;

        public PatientController(IMapper mapper, IRepository<Patient> patientRepo, IRepository<Diagnosis> diagnosisRepo)
        {
            //_patientRepo = RepositoryFactory.CreateRepository<Patient>();
            //_diagnosisRepo = RepositoryFactory.CreateRepository<Diagnosis>();

            _patientRepo = patientRepo;
            _diagnosisRepo = diagnosisRepo;

            _mapper = mapper;
        }

        public ActionResult Index(SearchVM search)
        {
            search.Patients = _mapper.Map<IEnumerable<PatientVM>>(_patientRepo.GetAll());

            if (!string.IsNullOrEmpty(search.Filter))
            {
                switch (search.OrderBy)
                {
                    case "lastName":
                        search.Patients = search.Patients
                            .Where(p => p.LastName.ToLower()
                                .Contains(search.Filter.ToLower()));
                        break;

                    case "oib":
                        search.Patients = search.Patients
                            .Where(p => p.Oib.ToString()
                                .Contains(search.Filter));
                        break;
                }
            }

            return View(search);
        }

        public ActionResult Details(long id)
        {
            var patient = _patientRepo.Get(id);
            var patientVm = _mapper.Map<PatientVM>(patient);

            return View(patientVm);
        }

        public ActionResult ExportData(long id)
        {
            var content = ExportUtils.PatientToCsv(_patientRepo.Get(id));
            byte[] byteArray = Encoding.UTF8.GetBytes(content);
            MemoryStream stream = new MemoryStream(byteArray);

            return File(stream, "application/octet-stream", "patient_data.csv");
        }

        public ActionResult Examinations(long id)
        {
            var patient = _patientRepo.Get(id);

            var examinatios = patient.Examinations;
            ViewBag.PatientName = patient.FirstName + " " + patient.LastName;
            ViewBag.PatientId = id;

            return View(examinatios);
        }

        public ActionResult Perescriptions(long id)
        {
            var patient = _patientRepo.Get(id);

            var perescriptions = patient.Perescriptions;
            ViewBag.PatientName = patient.FirstName + " " + patient.LastName;
            ViewBag.PatientId = id;

            return View(perescriptions);
        }

        public ActionResult MedicalHistory(long id)
        {
            var patient = _patientRepo.Get(id);

            var medicalHistory = patient.MedicalHistory;
            ViewBag.PatientName = patient.FirstName + " " + patient.LastName;
            ViewBag.PatientId = id;

            return View(medicalHistory);
        }

        public ActionResult DiagnosisFinished(long id)
        {
            var diagnosis = _diagnosisRepo.Get(id);
            diagnosis.End = DateOnly.FromDateTime(DateTime.Now);
            _diagnosisRepo.Update(id, diagnosis);

            return RedirectToAction(nameof(MedicalHistory), new { id = diagnosis.PatientId } );
        }

        public ActionResult Create()
        {
            ViewBag.GenderListItems = ViewUtils.GetGenderListItems();

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

        public ActionResult Edit(long id)
        {
            var patient = _mapper.Map<PatientVM>(_patientRepo.Get(id));
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, PatientVM patientVm)
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

        public ActionResult Delete(long id)
        {
            var patient = _mapper.Map<PatientVM>(_patientRepo.Get(id));

            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id, PatientVM patient)
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
