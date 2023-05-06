using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.FormClass
{
    public class Login
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string? Password { get; set; }
    }
}
