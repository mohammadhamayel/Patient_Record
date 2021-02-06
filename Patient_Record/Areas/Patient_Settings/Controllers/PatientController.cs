using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Patient_Record.Areas.Patient_Settings.Models;
using Patient_Record.Areas.Patient_Settings.ViewModel;

namespace Patient_Record.Areas.Patient_Settings.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public ViewResult Index()
        {
            var model = _patientRepository.GetAllPatient();
            return View(model);
        }

         public ViewResult Details(int id)
        {
            PatientDetailsViewModel patientDetailsViewModel = new PatientDetailsViewModel()
            {
                Patient = _patientRepository.GetPatient(id)
            };
            return View(patientDetailsViewModel);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                Patient newPatient = _patientRepository.Add(patient);
            }
            return View();
        }


    }
}
