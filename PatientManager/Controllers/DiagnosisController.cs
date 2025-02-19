﻿using AutoMapper;
using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatientManager.Controllers
{
    public class DiagnosisController : Controller
    {
        private readonly IRepository<Diagnosis> _diagnosisRepo;
        private readonly IRepository<Patient> _patientRepo;

        //public DiagnosisController()
        //{
        //    _diagnosisRepo = RepositoryFactory.CreateRepository<Diagnosis>();
        //    _patientRepo = RepositoryFactory.CreateRepository<Patient>();
        //}

        public DiagnosisController(IRepository<Diagnosis> diagnosisRepo, IRepository<Patient> patientRepo)
        {
            _diagnosisRepo = diagnosisRepo;
            _patientRepo = patientRepo;
        }

        public ActionResult Create(int id)
        {
            var diagnosis = new Diagnosis();
            diagnosis.PatientId = id;
            diagnosis.Start = DateOnly.FromDateTime(DateTime.Now);

            return View(diagnosis);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Diagnosis diagnosis)
        {
            try
            {
                var patient = _patientRepo.Get(diagnosis.PatientId);
                diagnosis.Id = 0;
                _diagnosisRepo.Add(diagnosis);

                return RedirectToAction("MedicalHistory", "Patient", new { id = diagnosis.PatientId });
            }
            catch
            {
                return View();
            }
        }
    }
}
