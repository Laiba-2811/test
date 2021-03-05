using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BlogApplication_Mcsf19a002.Models
{
    public class Post
    {
        [Required(ErrorMessage ="Please enter the title!")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
