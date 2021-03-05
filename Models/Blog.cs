using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication_Mcsf19a002.Models
{
    public class Blog
    {
        //public HttpPostedFileBase File { get; set; }
        public int ID { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Please enter the name!")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Age!")]
        [Range(1, 100)]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please Enter email!")]
        [EmailAddress]
        public string Email { get; set; }
        //[NotMapped]
        //[Required(ErrorMessage = "Please upload image!")]
        //public string Image { get; set; }
        [Required(ErrorMessage = "Please Enter Password!")]
        [StringLength(20)]
        public string Password { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Confirm Password required")]
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }
       

    }
}
