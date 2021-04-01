using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }


        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
         

        [Required(AllowEmptyStrings = false)]
        [StringLength(30, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "The password confirmation and the password must be equal!")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm your password")]
        public string PasswordConfirmation { get; set; }


        [Required(AllowEmptyStrings = false)]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }
    }
}
