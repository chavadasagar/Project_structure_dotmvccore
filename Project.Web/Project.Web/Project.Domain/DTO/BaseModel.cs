using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common.Models
{
    public class BaseModel
    {
        public int? Createdby { get; set; }
        public int? Updatedby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? Updateddate { get; set; }
        public bool? isDeleted { get; set; }
    }
}
