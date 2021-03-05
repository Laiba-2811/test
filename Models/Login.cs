using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BlogApplication_Mcsf19a002.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter email!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password!")]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
