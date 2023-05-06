using Project.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models
{
    public class Error:BaseModel
    {
        [Key]
        public int id { get; set; }
        public string? Name { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
    }
}
