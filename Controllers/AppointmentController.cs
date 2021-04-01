using AppointmentScheduling.Data;
using AppointmentScheduling.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService = null;
        public AppointmentController(IAppointmentService appointmentService)
        {
            this._appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult Index() 
        {
            ViewBag.Doctors = this._appointmentService.GetDoctors();
            ViewBag.Patients = this._appointmentService.GetPatients();
            return View();
        }
    }
}
