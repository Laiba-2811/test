using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication_Mcsf19a002.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public string Image { get; set; }
        //[NotMapped]
        //[Required(ErrorMessage = "Confirm Password required")]
        //[CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
