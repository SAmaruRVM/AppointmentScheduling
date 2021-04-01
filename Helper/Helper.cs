using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Helper
{
    public static class Helper
    {
        public const string Admin = "Admin";
        public const string Patient = "Patient";
        public const string Doctor = "Doctor";

        public static SelectListItem[] GetRoles() => new SelectListItem[] 
        {
            new SelectListItem(Admin, Admin),
            new SelectListItem(Patient, Patient),
            new SelectListItem(Doctor, Doctor) 
        };
    }
}
