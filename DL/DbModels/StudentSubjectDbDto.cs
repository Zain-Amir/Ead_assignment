using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels

{
    public class StudentSubjectDbDto
    {
        [Key]
        public int Id { get; set; }
        public int SID { get; set;}
        public StudentDbDto studentDbDto { get; set; }
        public SubjectDbDto SubjectDbDto { get; set; }
        public int SubjectId { get; set; }
        public double GPA { get; set; }

    }
}
