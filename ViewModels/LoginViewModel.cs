using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

         
        [Required(AllowEmptyStrings = false)]
        [StringLength(30, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }
    }
}
