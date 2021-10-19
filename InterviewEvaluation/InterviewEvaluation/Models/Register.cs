using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewEvaluation.Models
{
    public class Register
    {
        [Required(ErrorMessage ="User Name required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Name required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Name required")]
        public string Password { get; set; }

    }
}
