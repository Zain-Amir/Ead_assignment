using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.RequestModels
{
    public class StudentRequestDto : IStudent
    {
        public string? Name { get; set; }
        public string? RollNo { get; set; }
        public string PhoneNumber { get ; set ; }
    }
}
