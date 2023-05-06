using Project.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models
{
    public class Todo : BaseModel
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public bool isactive { get; set; } = true;
    }
}
