
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient_Record.Areas.Patient_Settings.Models;
using Patient_Record.Areas.Patient_Settings.ViewModel;
using Patient_Record.Models;

namespace Patient_Record.Areas.Patient_Settings.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatientController(IPatientRepository patientRepository, IHttpContextAccessor httpContextAccessor)
        {
            _patientRepository = patientRepository;
            _httpContextAccessor = httpContextAccessor;
            new PermissionsAttribute(_httpContextAccessor);

        }
        public ViewResult Index()
        {
            //ViewBag.PatientList
             ViewBag.patientList = _patientRepository.PatientList();
            
            return View();
        }

         public ViewResult Details(int id)
         {
            PatientDetailsViewModel patientDetailsViewModel = new PatientDetailsViewModel()
            {
                Patient = _patientRepository.GetPatient(id)
            };
            return View(patientDetailsViewModel);
         }


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
                return RedirectToAction("details", new { id = newPatient.Patient_Id });
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Patient newPatient = _patientRepository.Delete(id);
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _patientRepository.GetPatient(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientRepository.Update(patient);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Statistics()
        {
            //ViewBag.PatientList
            ViewBag.statisticsList = _patientRepository.PatientStatistics();

            return View();
        }

    }
}
