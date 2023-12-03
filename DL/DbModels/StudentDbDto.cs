using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    public class StudentDbDto
    {
        [Key]
        public int Id { get; set; }
        string Name { get; set; }
        string RollNumber { get; set; }
        String PhoneNumber { get; set; }

        ICollection<StudentSubjectDbDto> studentSubjects { get; set; } = new List<StudentSubjectDbDto>();

    }
}
