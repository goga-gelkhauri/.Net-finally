using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class CreatePostViewModel
    {
        [Display(Name = "Enter Title")]
        [Required]
        [MaxLength(50), MinLength(4)]
        public string Name { get; set; }


        [Required]
        [MaxLength(500), MinLength(10)]
        public string Description { get; set; }
        public int Id { get; set; }
    }
}
