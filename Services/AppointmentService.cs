using AppointmentScheduling.Data;
using AppointmentScheduling.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _databaseContext = null;
        public AppointmentService(ApplicationDbContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public List<DoctorViewModel> GetDoctors()
        {
            // linq query syntax
            var doctors = (from user in this._databaseContext.Users
                           join userRoles in this._databaseContext.UserRoles
                           on user.Id equals userRoles.UserId
                           join roles in this._databaseContext.Roles.Where((role) => role.Name.Equals(Helper.Helper.Doctor))
                           on userRoles.RoleId equals roles.Id
                           select new DoctorViewModel() // C# Projection
                           {
                               ID = user.Id,
                               Name = user.Name
                           }
                           ).ToList();

            return doctors;
        }
        public List<PatientViewModel> GetPatients()
        {
            var patients = (from user in this._databaseContext.Users
                           join userRoles in this._databaseContext.UserRoles
                           on user.Id equals userRoles.UserId
                           join roles in this._databaseContext.Roles.Where((role) => role.Name.Equals(Helper.Helper.Patient))
                           on userRoles.RoleId equals roles.Id
                           select new PatientViewModel() // C# Projection
                           {
                               ID = user.Id,
                               Name = user.Name
                           }
                           ).ToList();

            return patients;
        }
    }
}
