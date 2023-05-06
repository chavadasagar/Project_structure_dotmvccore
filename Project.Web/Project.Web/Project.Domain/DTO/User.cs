using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common.Models
{
    public class User:BaseModel
    {
        [Key]
        public int id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Mobile { get; set; }
        public string? Image { get; set; }  
        public int RoleidFk { get; set; }
    }
}
