using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class StudentSubjectMarksDto
    {
        public int SID { get; set; }
        public int SubjectId { get; set; }
        public int Marks { get; set; }
    }
}
