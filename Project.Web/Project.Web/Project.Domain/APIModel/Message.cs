using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.APIModel
{
    public class Message
    {
        public string? MessageText { get; set; }
        public string? Type { get; set; }
        public string? Result { get; set; }
    }
}
