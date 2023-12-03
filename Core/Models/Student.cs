using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public interface IStudent
    {
        public string Name { get; set; }
        public string RollNo { get; set; }  

        public string PhoneNumber { get; set; } 
    }
}
