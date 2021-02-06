﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Patient_Record.Areas.Patient_Settings.Models;
using Patient_Record.Areas.Patient_Settings.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Record.Areas.Patient_Settings.Controllers
{
    public class Patient_RecordController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public Patient_RecordController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public IActionResult Index()
        {
            var model = _patientRepository.GetAllRecoeds();
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Patients = new SelectList(_patientRepository.GetAllPatient(), "Patient_Id", "Patient_Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient_Records patient)
        {
            if (ModelState.IsValid)
            {
                Patient_Records newPatient = _patientRepository.Add(patient);
                return RedirectToAction("details", new { id = newPatient.Patient_Id });
            }
            return RedirectToAction("Create");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _patientRepository.GetPatientRecord(id);
            ViewBag.Patients = new SelectList(_patientRepository.GetAllPatient(), "Patient_Id", "Patient_Name");
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Patient_Records patient)
        {
            if (ModelState.IsValid)
            {
                _patientRepository.Update(patient);
            }
            return RedirectToAction("Index");
        }
        public ViewResult Details(int id)
        {
            PatientDetailsViewModel patientDetailsViewModel = new PatientDetailsViewModel()
            {
                Patient_Records = _patientRepository.GetPatientRecord(id)
            };
            return View(patientDetailsViewModel);
        }

    }
}